using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using WageFlow.Frontend.src.Data.Entities.Payments;
using WageFlow.Frontend.src.Data.Entities.Payments_Type;
using WageFlow.Frontend.src.Data.Services;
using WageFlow.Frontend.src.Pages.Salary_PaymentPages;
using WageFlow.Frontend.src.Pages.StaffPages;
using WageFlow.Frontend.src.Pages.Work_EntryPages;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using WageFlow.Frontend.src.Data.Entities.User;

namespace WageFlow.Frontend.src.Pages.PaymentsPages
{
    /// <summary>
    /// Логика взаимодействия для PaymentsPage.xaml
    /// </summary>
    public partial class PaymentsPage : Page
    {
        private readonly ApiService _apiService;
        private List<Payments> _allPayments;
        private List<Payments_Type> _allPayments_Type;
        public PaymentsPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
            LoadPayments();
        }

        private async Task LoadPayments()
        {
            try
            {
                _allPayments = await _apiService.GetPaymentsList();
                PaymentsListView.ItemsSource = _allPayments.OrderBy(x => x.lastname_staff);

                _allPayments_Type = await _apiService.GetPayments_TypeList();
                CmbPayments_Type.ItemsSource = _allPayments_Type.ToList();
                CmbPayments_Type.SelectedValuePath = "id_payments_type";
                CmbPayments_Type.DisplayMemberPath = "name_payments_type";

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
                MessageBox.Show($"Ошибка загрузки выплат: {ex.Message}");
            }
        }

        private void Work_EntryClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Work_EntryPage());
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
            NavigationService.Navigate(new PaymentsCommandsPage());
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            if (PaymentsListView.SelectedItem is Payments selectedPayments)
            {
                NavigationService.Navigate(new PaymentsCommandsPage(selectedPayments));
            }
            else
            {
                MessageBox.Show("Выберите выплату для редактирования");
            }
        }

        private async void DeleteClick(object sender, RoutedEventArgs e)
        {
            if (PaymentsListView.SelectedItem is Payments selectedPayments)
            {
                var result = MessageBox.Show($"Вы уверены, что хотите удалить выплату {selectedPayments.comment} для сотрудника {selectedPayments.lastname_staff} на сумму {selectedPayments.amount_payments} типа {selectedPayments.name_payments_type} ?", "Подтверждение удаления", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        await _apiService.DeletePayments(selectedPayments.id_payments);
                        MessageBox.Show("Выплата успешно удалена.");
                        await LoadPayments();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении выплаты: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите выплату для удаления.");
            }
        }

        private void ApplyFilters()
        {
            var filtered = _allPayments.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(TbSerch.Text))
            {
                filtered = filtered.Where(x => x.lastname_staff
                    .IndexOf(TbSerch.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (CmbPayments_Type.SelectedValue is int typeId)
                filtered = filtered.Where(x => x.id_payments_type == typeId);

            PaymentsListView.ItemsSource = filtered.ToList();
        }

        private void CmbPayments_Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            CmbPayments_Type.SelectedItem = null;
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
            worksheet.Cells[indexRows, 5] = "Описание";
            worksheet.Cells[indexRows, 6] = "Тип выплаты";
            worksheet.Cells[indexRows, 7] = "Сумма";
            worksheet.Cells[indexRows, 8] = "Дата";

            var printItems = PaymentsListView.Items;

            foreach (Payments item in printItems)
            {
                worksheet.Cells[indexRows, 1] = indexRows - 1;
                worksheet.Cells[indexRows, 2] = item.lastname_staff;
                worksheet.Cells[indexRows, 3] = item.name_staff;
                worksheet.Cells[indexRows, 4] = item.patronymic_staff;
                worksheet.Cells[indexRows, 5] = item.comment;
                worksheet.Cells[indexRows, 6] = item.name_payments_type;
                worksheet.Cells[indexRows, 7] = item.amount_payments;
                worksheet.Cells[indexRows, 8] = item.date_payments.ToString("dd.MM.yyyy");

                indexRows++;
            }
            Excel.Range range = worksheet.Range[
                worksheet.Cells[1, 1],
                    worksheet.Cells[indexRows, 8]];

            range.ColumnWidth = 20;

            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            ExcelApp.Visible = true;
        }

        private async void WordClick(object sender, RoutedEventArgs e)
        {
            _allPayments = await _apiService.GetPaymentsList();
            var PaymentsInPDF = _allPayments;

            var PaymentsApplicationPDF = new Word.Application();

            Word.Document document = PaymentsApplicationPDF.Documents.Add();

            Word.Paragraph empParagraph = document.Paragraphs.Add();
            Word.Range empRange = empParagraph.Range;
            empRange.Text = "Payments";
            empRange.Font.Bold = 4;
            empRange.Font.Italic = 4;
            empRange.Font.Color = Word.WdColor.wdColorBlack;
            empRange.InsertParagraphAfter();

            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table paymentsTable = document.Tables.Add(tableRange, PaymentsInPDF.Count() + 1, 7);
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
            cellRange.Text = "Описание";
            cellRange = paymentsTable.Cell(1, 5).Range;
            cellRange.Text = "Тип выплаты";
            cellRange = paymentsTable.Cell(1, 6).Range;
            cellRange.Text = "Сумма";
            cellRange = paymentsTable.Cell(1, 7).Range;
            cellRange.Text = "Дата";


            paymentsTable.Rows[1].Range.Bold = 1;
            paymentsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int i = 0; i < PaymentsInPDF.Count(); i++)
            {
                var ProductCurrent = PaymentsInPDF[i];

                cellRange = paymentsTable.Cell(i + 2, 1).Range;
                cellRange.Text = ProductCurrent.lastname_staff;

                cellRange = paymentsTable.Cell(i + 2, 2).Range;
                cellRange.Text = ProductCurrent.name_staff;

                cellRange = paymentsTable.Cell(i + 2, 3).Range;
                cellRange.Text = ProductCurrent.patronymic_staff;

                cellRange = paymentsTable.Cell(i + 2, 4).Range;
                cellRange.Text = ProductCurrent.comment;

                cellRange = paymentsTable.Cell(i + 2, 5).Range;
                cellRange.Text = ProductCurrent.name_payments_type;

                cellRange = paymentsTable.Cell(i + 2, 6).Range;
                cellRange.Text = ProductCurrent.amount_payments.ToString();

                cellRange = paymentsTable.Cell(i + 2, 7).Range;
                cellRange.Text = ProductCurrent.date_payments.ToString();
            }

            PaymentsApplicationPDF.Visible = true;

            document.SaveAs2(@"C:\Users\User\OneDrive\Desktop\WageFlow_Fullstack\WageFlow.Frontend\WageFlow.Frontend\src\Files\Payments.docx");
        }

        private async void PDFClick(object sender, RoutedEventArgs e)
        {
            _allPayments = await _apiService.GetPaymentsList();
            var PaymentsInPDF = _allPayments;

            var PaymentsApplicationPDF = new Word.Application();

            Word.Document document = PaymentsApplicationPDF.Documents.Add();

            Word.Paragraph empParagraph = document.Paragraphs.Add();
            Word.Range empRange = empParagraph.Range;
            empRange.Text = "Payments";
            empRange.Font.Bold = 4;
            empRange.Font.Italic = 4;
            empRange.Font.Color = Word.WdColor.wdColorBlack;
            empRange.InsertParagraphAfter();

            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table paymentsTable = document.Tables.Add(tableRange, PaymentsInPDF.Count() + 1, 7);
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
            cellRange.Text = "Описание";
            cellRange = paymentsTable.Cell(1, 5).Range;
            cellRange.Text = "Тип выплаты";
            cellRange = paymentsTable.Cell(1, 6).Range;
            cellRange.Text = "Сумма";
            cellRange = paymentsTable.Cell(1, 7).Range;
            cellRange.Text = "Дата";


            paymentsTable.Rows[1].Range.Bold = 1;
            paymentsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int i = 0; i < PaymentsInPDF.Count(); i++)
            {
                var ProductCurrent = PaymentsInPDF[i];

                cellRange = paymentsTable.Cell(i + 2, 1).Range;
                cellRange.Text = ProductCurrent.lastname_staff;

                cellRange = paymentsTable.Cell(i + 2, 2).Range;
                cellRange.Text = ProductCurrent.name_staff;

                cellRange = paymentsTable.Cell(i + 2, 3).Range;
                cellRange.Text = ProductCurrent.patronymic_staff;

                cellRange = paymentsTable.Cell(i + 2, 4).Range;
                cellRange.Text = ProductCurrent.comment;

                cellRange = paymentsTable.Cell(i + 2, 5).Range;
                cellRange.Text = ProductCurrent.name_payments_type;

                cellRange = paymentsTable.Cell(i + 2, 6).Range;
                cellRange.Text = ProductCurrent.amount_payments.ToString();

                cellRange = paymentsTable.Cell(i + 2, 7).Range;
                cellRange.Text = ProductCurrent.date_payments.ToString();
            }

            PaymentsApplicationPDF.Visible = true;

            document.SaveAs2(@"C:\Users\User\OneDrive\Desktop\WageFlow_Fullstack\WageFlow.Frontend\WageFlow.Frontend\src\Files\Payments.pdf", Word.WdExportFormat.wdExportFormatPDF);
        }
    }
}
