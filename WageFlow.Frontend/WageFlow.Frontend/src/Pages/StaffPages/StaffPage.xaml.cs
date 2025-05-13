using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WageFlow.Frontend.src.Data.Entities.Payments;
using WageFlow.Frontend.src.Data.Entities.Post;
using WageFlow.Frontend.src.Data.Entities.Salary_Payment;
using WageFlow.Frontend.src.Data.Entities.Staff;
using WageFlow.Frontend.src.Data.Entities.User;
using WageFlow.Frontend.src.Data.Services;
using WageFlow.Frontend.src.Pages.PaymentsPages;
using WageFlow.Frontend.src.Pages.Salary_PaymentPages;
using WageFlow.Frontend.src.Pages.Work_EntryPages;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace WageFlow.Frontend.src.Pages.StaffPages
{
    /// <summary>
    /// Логика взаимодействия для StaffPage.xaml
    /// </summary>
    public partial class StaffPage : Page
    {
        private readonly ApiService _apiService;
        private List<Staff> _allStaff;
        private List<Post> _allPost;
        public StaffPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
            LoadStaff();
        }

        private async Task LoadStaff()
        {
            try
            {
                _allStaff = await _apiService.GetStaffList();
                StaffListView.ItemsSource = _allStaff.OrderBy(x => x.lastname_staff);

                _allPost = await _apiService.GetPostList();
                CmbPost.ItemsSource = _allPost.ToList();
                CmbPost.SelectedValuePath = "id_post";
                CmbPost.DisplayMemberPath = "name_post";

                string name_postUser = UserSession.CurrentUser.name_post;
                if (name_postUser != "Руководитель")
                {
                    AddButton.Visibility = Visibility.Hidden;
                    UpdateButton.Visibility = Visibility.Hidden;
                    DeleteButton.Visibility = Visibility.Hidden;
                }
                else
                {
                    AddButton.Visibility = Visibility.Visible;
                    UpdateButton.Visibility = Visibility.Visible;
                    DeleteButton.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки сотрудников: {ex.Message}");
            }
        }

        private void Work_EntryClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Work_EntryPage());
        }

        private void PaymentsClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PaymentsPage());
        }

        private void Salary_PaymentClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Salary_PaymentPage());
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StaffCommandsPage());
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            if (StaffListView.SelectedItem is Staff selectedStaff)
            {
                NavigationService.Navigate(new StaffCommandsPage(selectedStaff));
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для редактирования");
            }
        }

        private async void DeleteClick(object sender, RoutedEventArgs e)
        {
            if (StaffListView.SelectedItem is Staff selectedStaff)
            {
                var result = MessageBox.Show($"Вы уверены, что хотите удалить сотрудника {selectedStaff.lastname_staff}?", "Подтверждение удаления", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        await _apiService.DeleteStaff(selectedStaff.id_staff);
                        MessageBox.Show("Сотрудник успешно удален.");
                        await LoadStaff();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении сотрудника: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите отчет для удаления.");
            }
        }

        private void ApplyFilters()
        {
            var filtered = _allStaff.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(TbSerch.Text))
            {
                filtered = filtered.Where(x => x.lastname_staff
                    .IndexOf(TbSerch.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (CmbPost.SelectedValue is int typeId)
                filtered = filtered.Where(x => x.id_post == typeId);

            StaffListView.ItemsSource = filtered.ToList();
        }

        private void CmbPost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void TbSerch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            TbSerch.Clear();
            CmbPost.SelectedItem = null;
            ApplyFilters();
        }

        private void ExcelClick(object sender, RoutedEventArgs e)
        {
            var ExcelApp = new Excel.Application();

            Excel.Workbook wb = ExcelApp.Workbooks.Add();

            Excel.Worksheet worksheet = (Excel.Worksheet)ExcelApp.Worksheets.Item[1];

            int indexRows = 1;

            worksheet.Cells[indexRows, 1] = "№";
            worksheet.Cells[indexRows, 2] = "Фамилия";
            worksheet.Cells[indexRows, 3] = "Имя";
            worksheet.Cells[indexRows, 4] = "Отчество";
            worksheet.Cells[indexRows, 5] = "Почта";
            worksheet.Cells[indexRows, 6] = "Должность";

            var printItems = StaffListView.Items;

            foreach (Staff item in printItems)
            {
                worksheet.Cells[indexRows, 1] = indexRows - 1;
                worksheet.Cells[indexRows, 2] = item.lastname_staff;
                worksheet.Cells[indexRows, 3] = item.name_staff;
                worksheet.Cells[indexRows, 4] = item.patronymic_staff;
                worksheet.Cells[indexRows, 5] = item.email_staff;
                worksheet.Cells[indexRows, 6] = item.name_post;

                indexRows++;
            }
            Excel.Range range = worksheet.Range[
                worksheet.Cells[1, 1],
                    worksheet.Cells[indexRows, 6]];

            range.ColumnWidth = 20;

            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            ExcelApp.Visible = true;
        }

        private async void WordClick(object sender, RoutedEventArgs e)
        {
            _allStaff = await _apiService.GetStaffList();
            var StaffInPDF = _allStaff;

            var StaffApplicationPDF = new Word.Application();

            Word.Document document = StaffApplicationPDF.Documents.Add();

            Word.Paragraph empParagraph = document.Paragraphs.Add();
            Word.Range empRange = empParagraph.Range;
            empRange.Text = "Staff";
            empRange.Font.Bold = 4;
            empRange.Font.Italic = 4;
            empRange.Font.Color = Word.WdColor.wdColorBlack;
            empRange.InsertParagraphAfter();

            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table paymentsTable = document.Tables.Add(tableRange, StaffInPDF.Count() + 1, 5);
            paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Word.Range cellRange;

            cellRange = paymentsTable.Cell(1, 1).Range;
            cellRange.Text = "Фамилия";
            cellRange = paymentsTable.Cell(1, 2).Range;
            cellRange.Text = "Имя";
            cellRange = paymentsTable.Cell(1, 3).Range;
            cellRange.Text = "Отчество";
            cellRange = paymentsTable.Cell(1, 4).Range;
            cellRange.Text = "Почта";
            cellRange = paymentsTable.Cell(1, 5).Range;
            cellRange.Text = "Должность";


            paymentsTable.Rows[1].Range.Bold = 1;
            paymentsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int i = 0; i < StaffInPDF.Count(); i++)
            {
                var ProductCurrent = StaffInPDF[i];

                cellRange = paymentsTable.Cell(i + 2, 1).Range;
                cellRange.Text = ProductCurrent.lastname_staff;

                cellRange = paymentsTable.Cell(i + 2, 2).Range;
                cellRange.Text = ProductCurrent.name_staff;

                cellRange = paymentsTable.Cell(i + 2, 3).Range;
                cellRange.Text = ProductCurrent.patronymic_staff;

                cellRange = paymentsTable.Cell(i + 2, 4).Range;
                cellRange.Text = ProductCurrent.email_staff;

                cellRange = paymentsTable.Cell(i + 2, 5).Range;
                cellRange.Text = ProductCurrent.name_post;
            }

            StaffApplicationPDF.Visible = true;

            document.SaveAs2(@"C:\Users\User\OneDrive\Desktop\WageFlow_Fullstack\WageFlow.Frontend\WageFlow.Frontend\src\Files\Staff.docx");
        }

        private async void PDFClick(object sender, RoutedEventArgs e)
        {
            _allStaff = await _apiService.GetStaffList();
            var StaffInPDF = _allStaff;

            var StaffApplicationPDF = new Word.Application();

            Word.Document document = StaffApplicationPDF.Documents.Add();

            Word.Paragraph empParagraph = document.Paragraphs.Add();
            Word.Range empRange = empParagraph.Range;
            empRange.Text = "Staff";
            empRange.Font.Bold = 4;
            empRange.Font.Italic = 4;
            empRange.Font.Color = Word.WdColor.wdColorBlack;
            empRange.InsertParagraphAfter();

            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table paymentsTable = document.Tables.Add(tableRange, StaffInPDF.Count() + 1, 5);
            paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Word.Range cellRange;

            cellRange = paymentsTable.Cell(1, 1).Range;
            cellRange.Text = "Фамилия";
            cellRange = paymentsTable.Cell(1, 2).Range;
            cellRange.Text = "Имя";
            cellRange = paymentsTable.Cell(1, 3).Range;
            cellRange.Text = "Отчество";
            cellRange = paymentsTable.Cell(1, 4).Range;
            cellRange.Text = "Почта";
            cellRange = paymentsTable.Cell(1, 5).Range;
            cellRange.Text = "Должность";


            paymentsTable.Rows[1].Range.Bold = 1;
            paymentsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int i = 0; i < StaffInPDF.Count(); i++)
            {
                var ProductCurrent = StaffInPDF[i];

                cellRange = paymentsTable.Cell(i + 2, 1).Range;
                cellRange.Text = ProductCurrent.lastname_staff;

                cellRange = paymentsTable.Cell(i + 2, 2).Range;
                cellRange.Text = ProductCurrent.name_staff;

                cellRange = paymentsTable.Cell(i + 2, 3).Range;
                cellRange.Text = ProductCurrent.patronymic_staff;

                cellRange = paymentsTable.Cell(i + 2, 4).Range;
                cellRange.Text = ProductCurrent.email_staff;

                cellRange = paymentsTable.Cell(i + 2, 5).Range;
                cellRange.Text = ProductCurrent.name_post;
            }

            string pdfPath = @"C:\Users\User\OneDrive\Desktop\WageFlow_Fullstack\WageFlow.Frontend\WageFlow.Frontend\src\Files\Staff.pdf";

            document.ExportAsFixedFormat(pdfPath, Word.WdExportFormat.wdExportFormatPDF);

            document.Close(false);
            StaffApplicationPDF.Quit();

            Process.Start(new ProcessStartInfo
            {
                FileName = pdfPath,
                UseShellExecute = true
            });
        }
    }
}
