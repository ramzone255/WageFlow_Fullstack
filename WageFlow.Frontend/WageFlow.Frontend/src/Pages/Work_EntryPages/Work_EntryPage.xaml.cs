
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
using WageFlow.Frontend.src.Data.Entities.User;
using WageFlow.Frontend.src.Data.Entities.Work_Entry;
using WageFlow.Frontend.src.Data.Entities.Work_Type;
using WageFlow.Frontend.src.Data.Services;
using WageFlow.Frontend.src.Pages.PaymentsPages;
using WageFlow.Frontend.src.Pages.Salary_PaymentPages;
using WageFlow.Frontend.src.Pages.StaffPages;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace WageFlow.Frontend.src.Pages.Work_EntryPages
{
    /// <summary>
    /// Логика взаимодействия для Work_EntryPage.xaml
    /// </summary>
    public partial class Work_EntryPage : Page
    {
        private readonly ApiService _apiService;
        private List<Work_Entry> _allWork_Entry;
        private List<Work_Type> _allWork_Type;
        public Work_EntryPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
            LoadWork_Entry();
        }

        private async Task LoadWork_Entry()
        {
            try
            {
                _allWork_Entry = await _apiService.GetWork_EntryList();
                Work_EntryListView.ItemsSource = _allWork_Entry.OrderBy(x => x.lastname_staff);

                _allWork_Type = await _apiService.GetWork_TypeList();
                CmbWork_Type.ItemsSource = _allWork_Type.ToList();
                CmbWork_Type.SelectedValuePath = "id_work_type";
                CmbWork_Type.DisplayMemberPath = "name_work_type";

                string name_postUser = UserSession.CurrentUser.name_post;
                if (name_postUser == "Сотрудник")
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
                MessageBox.Show($"Ошибка загрузки выработки работ: {ex.Message}");
            }
        }

        private void PaymentsClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PaymentsPage());
        }

        private void StaffClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StaffPage());
        }

        private void Salary_PaymentClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Salary_PaymentPage());
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Work_EntryCommandPage());
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            if (Work_EntryListView.SelectedItem is Work_Entry selectedWork_Entry)
            {
                NavigationService.Navigate(new Work_EntryCommandPage(selectedWork_Entry));
            }
            else
            {
                MessageBox.Show("Выберите работу для редактирования");
            }
        }

        private async void DeleteClick(object sender, RoutedEventArgs e)
        {
            if (Work_EntryListView.SelectedItem is Work_Entry selectedWork_Entry)
            {
                var result = MessageBox.Show($"Вы уверены, что хотите удалить работа {selectedWork_Entry.name_work_type} для сотрудника {selectedWork_Entry.lastname_staff}?", "Подтверждение удаления", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        await _apiService.DeleteWork_Entry(selectedWork_Entry.id_work_entry);
                        MessageBox.Show("Работа успешно удалена.");
                        await LoadWork_Entry();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении работы: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите работу для удаления.");
            }
        }

        private void ApplyFilters()
        {
            var filtered = _allWork_Entry.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(TbSerch.Text))
            {
                filtered = filtered.Where(x => x.lastname_staff
                    .IndexOf(TbSerch.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (CmbWork_Type.SelectedValue is int typeId)
                filtered = filtered.Where(x => x.id_work_type == typeId);

            Work_EntryListView.ItemsSource = filtered.ToList();
        }

        private void CmbWork_Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            CmbWork_Type.SelectedItem = null;
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
            worksheet.Cells[indexRows, 5] = "Тип работы";
            worksheet.Cells[indexRows, 6] = "Количество";
            worksheet.Cells[indexRows, 7] = "Сумма (₽)";
            worksheet.Cells[indexRows, 8] = "Дата";

            Excel.Range range = worksheet.Range[
                            worksheet.Cells[indexRows, 1],
                            worksheet.Cells[indexRows, 6]
                        ];
            range.Font.Bold = true;

            indexRows++;

            var printItems = Work_EntryListView.Items;

            foreach (Work_Entry item in printItems)
            {
                worksheet.Cells[indexRows, 1] = indexRows - 1;
                worksheet.Cells[indexRows, 2] = item.lastname_staff;
                worksheet.Cells[indexRows, 3] = item.name_staff;
                worksheet.Cells[indexRows, 4] = item.patronymic_staff;
                worksheet.Cells[indexRows, 5] = item.name_work_type;
                worksheet.Cells[indexRows, 6] = item.quantity_work_entry;
                worksheet.Cells[indexRows, 7] = item.amount_work_type;
                worksheet.Cells[indexRows, 8] = item.date_work_entry.ToString("dd.MM.yyyy");

                indexRows++;
            }

            range.ColumnWidth = 20;

            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            ExcelApp.Visible = true;
        }

        private async void WordClick(object sender, RoutedEventArgs e)
        {
            _allWork_Entry = await _apiService.GetWork_EntryList();
            var Work_EntryInPDF = _allWork_Entry;

            var Work_EntryApplicationPDF = new Word.Application();

            Word.Document document = Work_EntryApplicationPDF.Documents.Add();

            Word.Paragraph empParagraph = document.Paragraphs.Add();
            Word.Range empRange = empParagraph.Range;
            empRange.Text = "Work_Entry";
            empRange.Font.Bold = 4;
            empRange.Font.Italic = 4;
            empRange.Font.Color = Word.WdColor.wdColorBlack;
            empRange.InsertParagraphAfter();

            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table paymentsTable = document.Tables.Add(tableRange, Work_EntryInPDF.Count() + 1, 7);
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
            cellRange.Text = "Тип работы";
            cellRange = paymentsTable.Cell(1, 5).Range;
            cellRange.Text = "Количество";
            cellRange = paymentsTable.Cell(1, 6).Range;
            cellRange.Text = "Сумма (₽)";
            cellRange = paymentsTable.Cell(1, 7).Range;
            cellRange.Text = "Дата";


            paymentsTable.Rows[1].Range.Bold = 1;
            paymentsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int i = 0; i < Work_EntryInPDF.Count(); i++)
            {
                var ProductCurrent = Work_EntryInPDF[i];

                cellRange = paymentsTable.Cell(i + 2, 1).Range;
                cellRange.Text = ProductCurrent.lastname_staff;

                cellRange = paymentsTable.Cell(i + 2, 2).Range;
                cellRange.Text = ProductCurrent.name_staff;

                cellRange = paymentsTable.Cell(i + 2, 3).Range;
                cellRange.Text = ProductCurrent.patronymic_staff;

                cellRange = paymentsTable.Cell(i + 2, 4).Range;
                cellRange.Text = ProductCurrent.name_work_type;

                cellRange = paymentsTable.Cell(i + 2, 5).Range;
                cellRange.Text = ProductCurrent.quantity_work_entry.ToString();

                cellRange = paymentsTable.Cell(i + 2, 6).Range;
                cellRange.Text = ProductCurrent.amount_work_type.ToString();

                cellRange = paymentsTable.Cell(i + 2, 7).Range;
                cellRange.Text = ProductCurrent.date_work_entry.ToString();
            }

            Work_EntryApplicationPDF.Visible = true;

            document.SaveAs2(@"C:\Users\User\OneDrive\Desktop\WageFlow_Fullstack\WageFlow.Frontend\WageFlow.Frontend\src\Files\Work_Entry.docx");
        }

        private async void PDFClick(object sender, RoutedEventArgs e)
        {
            _allWork_Entry = await _apiService.GetWork_EntryList();
            var Work_EntryInPDF = _allWork_Entry;

            var Work_EntryApplicationPDF = new Word.Application();

            Word.Document document = Work_EntryApplicationPDF.Documents.Add();

            Word.Paragraph empParagraph = document.Paragraphs.Add();
            Word.Range empRange = empParagraph.Range;
            empRange.Text = "Work_Entry";
            empRange.Font.Bold = 4;
            empRange.Font.Italic = 4;
            empRange.Font.Color = Word.WdColor.wdColorBlack;
            empRange.InsertParagraphAfter();

            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table paymentsTable = document.Tables.Add(tableRange, Work_EntryInPDF.Count() + 1, 7);
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
            cellRange.Text = "Тип работы";
            cellRange = paymentsTable.Cell(1, 5).Range;
            cellRange.Text = "Количество";
            cellRange = paymentsTable.Cell(1, 6).Range;
            cellRange.Text = "Сумма (₽)";
            cellRange = paymentsTable.Cell(1, 7).Range;
            cellRange.Text = "Дата";


            paymentsTable.Rows[1].Range.Bold = 1;
            paymentsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int i = 0; i < Work_EntryInPDF.Count(); i++)
            {
                var ProductCurrent = Work_EntryInPDF[i];

                cellRange = paymentsTable.Cell(i + 2, 1).Range;
                cellRange.Text = ProductCurrent.lastname_staff;

                cellRange = paymentsTable.Cell(i + 2, 2).Range;
                cellRange.Text = ProductCurrent.name_staff;

                cellRange = paymentsTable.Cell(i + 2, 3).Range;
                cellRange.Text = ProductCurrent.patronymic_staff;

                cellRange = paymentsTable.Cell(i + 2, 4).Range;
                cellRange.Text = ProductCurrent.name_work_type;

                cellRange = paymentsTable.Cell(i + 2, 5).Range;
                cellRange.Text = ProductCurrent.quantity_work_entry.ToString();

                cellRange = paymentsTable.Cell(i + 2, 6).Range;
                cellRange.Text = ProductCurrent.amount_work_type.ToString();

                cellRange = paymentsTable.Cell(i + 2, 7).Range;
                cellRange.Text = ProductCurrent.date_work_entry.ToString();
            }

            string pdfPath = @"C:\Users\User\OneDrive\Desktop\WageFlow_Fullstack\WageFlow.Frontend\WageFlow.Frontend\src\Files\Work_Entry.pdf";

            document.ExportAsFixedFormat(pdfPath, Word.WdExportFormat.wdExportFormatPDF);

            document.Close(false);
            Work_EntryApplicationPDF.Quit();

            Process.Start(new ProcessStartInfo
            {
                FileName = pdfPath,
                UseShellExecute = true
            });
        }
    }
}
