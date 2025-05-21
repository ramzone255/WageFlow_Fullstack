using System;
using System.Collections;
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
using WageFlow.Frontend.src.Data.Entities.Salary_Payment;
using WageFlow.Frontend.src.Data.Entities.Staff;
using WageFlow.Frontend.src.Data.Entities.User;
using WageFlow.Frontend.src.Data.Services;
using WageFlow.Frontend.src.Pages.PaymentsPages;
using WageFlow.Frontend.src.Pages.StaffPages;
using WageFlow.Frontend.src.Pages.Work_EntryPages;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace WageFlow.Frontend.src.Pages.Salary_PaymentPages
{
    /// <summary>
    /// Логика взаимодействия для Salary_PaymentPage.xaml
    /// </summary>
    public partial class Salary_PaymentPage : Page
    {
        private readonly ApiService _apiService;
        private List<Salary_Payment> _allSalary_Payment;

        public Salary_PaymentPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
            LoadSalary_Payment();
        }

        private async Task LoadSalary_Payment()
        {
            try
            {
                _allSalary_Payment = await _apiService.GetSalary_PaymentList();
                Salary_PaymentListView.ItemsSource = _allSalary_Payment.OrderBy(x => x.date_salary_payment);

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
                MessageBox.Show($"Ошибка загрузки отчетов: {ex.Message}");
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

        private void StaffClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StaffPage());
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Salary_PaymentCommandsPage());
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            if (Salary_PaymentListView.SelectedItem is Salary_Payment selectedSalary_Payment)
            {
                NavigationService.Navigate(new Salary_PaymentCommandsPage(selectedSalary_Payment));
            }
            else
            {
                MessageBox.Show("Выберите отчет для редактирования");
            }
        }

        private async void DeleteClick(object sender, RoutedEventArgs e)
        {
            if (Salary_PaymentListView.SelectedItem is Salary_Payment selectedSalary_Payment)
            {
                var result = MessageBox.Show($"Вы уверены, что хотите удалить отчет по {selectedSalary_Payment.lastname_staff} {selectedSalary_Payment.amount_salary_payment}?", "Подтверждение удаления", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        await _apiService.DeleteSalary_Payment(selectedSalary_Payment.id_salary_payment);
                        MessageBox.Show("Отчет успешно удален.");
                        await LoadSalary_Payment();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении отчета: {ex.Message}");
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
            var filtered = _allSalary_Payment.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(TbSerch.Text))
            {
                filtered = filtered.Where(x => x.lastname_staff
                    .IndexOf(TbSerch.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (DateFilter.SelectedDate.HasValue)
            {
                var selectedDate = DateFilter.SelectedDate.Value;
                filtered = filtered.Where(x =>
                    x.date_salary_payment.Month == selectedDate.Month &&
                    x.date_salary_payment.Year == selectedDate.Year);
            }

            Salary_PaymentListView.ItemsSource = filtered.ToList();
        }

        private void TbSerch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void DateFilter_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            DateFilter.SelectedDate = null;
            TbSerch.Clear();
            TotalAmountText.Text = null;
            TaxText.Text = null;
            PensionText.Text = null;
            FinalAmountText.Text = null;
            ApplyFilters();
        }

        private void CalculateSummary_Click(object sender, RoutedEventArgs e)
        {
            var visibleItems = Salary_PaymentListView.ItemsSource as IEnumerable<Salary_Payment>;
            if (visibleItems == null) return;

            decimal totalAmount = (decimal)visibleItems.Sum(p => p.amount_salary_payment);
            decimal tax = totalAmount * 0.13m;
            decimal pension = totalAmount * 0.22m;
            decimal finalAmount = totalAmount - tax - pension;

            TotalAmountText.Text = $"{totalAmount:N0}";
            TaxText.Text = $"{tax:N0}";
            PensionText.Text = $"{pension:N0}";
            FinalAmountText.Text = $"{finalAmount:N0}";
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
            worksheet.Cells[indexRows, 5] = "Сумма выплаты (₽)";
            worksheet.Cells[indexRows, 6] = "Дата выплаты";

            var printItems = Salary_PaymentListView.Items;

            foreach (Salary_Payment item in printItems)
            {
                worksheet.Cells[indexRows, 1] = indexRows - 1;
                worksheet.Cells[indexRows, 2] = item.lastname_staff;
                worksheet.Cells[indexRows, 3] = item.name_staff;
                worksheet.Cells[indexRows, 4] = item.patronymic_staff;
                worksheet.Cells[indexRows, 5] = item.amount_salary_payment;
                worksheet.Cells[indexRows, 6] = item.date_salary_payment.ToString("dd.MM.yyyy");

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
            _allSalary_Payment = await _apiService.GetSalary_PaymentList();

            var groupedPayments = _allSalary_Payment
                .GroupBy(p => new { p.lastname_staff, p.name_staff, p.patronymic_staff })
                .ToList();

            var wordApp = new Word.Application();
            Word.Document document = wordApp.Documents.Add();

            foreach (var group in groupedPayments)
            {
                var fullName = $"{group.Key.lastname_staff} {group.Key.name_staff} {group.Key.patronymic_staff}";

                // Заголовок
                Word.Paragraph empParagraph = document.Paragraphs.Add();
                Word.Range empRange = empParagraph.Range;
                empRange.Text = $"Сотрудник: {fullName}";
                empRange.Font.Bold = 1;
                empRange.Font.Size = 14;
                empRange.InsertParagraphAfter();

                // Таблица
                Word.Paragraph tableParagraph = document.Paragraphs.Add();
                Word.Range tableRange = tableParagraph.Range;

                Word.Table paymentsTable = document.Tables.Add(tableRange, group.Count() + 1, 2);
                paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                paymentsTable.Cell(1, 1).Range.Text = "Сумма выплаты (₽)";
                paymentsTable.Cell(1, 2).Range.Text = "Дата выплаты";
                paymentsTable.Rows[1].Range.Bold = 1;
                paymentsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                int rowIndex = 2;
                foreach (var payment in group)
                {
                    paymentsTable.Cell(rowIndex, 1).Range.Text = payment.amount_salary_payment.ToString();
                    paymentsTable.Cell(rowIndex, 2).Range.Text = payment.date_salary_payment.ToShortDateString();
                    rowIndex++;
                }

                // Пробел между таблицами
                document.Paragraphs.Add();
            }

            wordApp.Visible = true;

            document.SaveAs2(@"C:\Users\User\OneDrive\Desktop\WageFlow_Fullstack\WageFlow.Frontend\WageFlow.Frontend\src\Files\Salary_Payment.docx");
        }

        private async void PDFClick(object sender, RoutedEventArgs e)
        {
            _allSalary_Payment = await _apiService.GetSalary_PaymentList();
            var Salary_PaymentInPDF = _allSalary_Payment;

            var Salary_PaymentApplicationPDF = new Word.Application();

            Word.Document document = Salary_PaymentApplicationPDF.Documents.Add();

            Word.Paragraph empParagraph = document.Paragraphs.Add();
            Word.Range empRange = empParagraph.Range;
            empRange.Text = "Salary_Payment";
            empRange.Font.Bold = 4;
            empRange.Font.Italic = 4;
            empRange.Font.Color = Word.WdColor.wdColorBlack;
            empRange.InsertParagraphAfter();

            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table paymentsTable = document.Tables.Add(tableRange, Salary_PaymentInPDF.Count() + 1, 5);
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
            cellRange.Text = "Сумма выплаты (₽)";
            cellRange = paymentsTable.Cell(1, 5).Range;
            cellRange.Text = "Дата выплаты";


            paymentsTable.Rows[1].Range.Bold = 1;
            paymentsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int i = 0; i < Salary_PaymentInPDF.Count(); i++)
            {
                var ProductCurrent = Salary_PaymentInPDF[i];

                cellRange = paymentsTable.Cell(i + 2, 1).Range;
                cellRange.Text = ProductCurrent.lastname_staff;

                cellRange = paymentsTable.Cell(i + 2, 2).Range;
                cellRange.Text = ProductCurrent.name_staff;

                cellRange = paymentsTable.Cell(i + 2, 3).Range;
                cellRange.Text = ProductCurrent.patronymic_staff;

                cellRange = paymentsTable.Cell(i + 2, 4).Range;
                cellRange.Text = ProductCurrent.amount_salary_payment.ToString();

                cellRange = paymentsTable.Cell(i + 2, 5).Range;
                cellRange.Text = ProductCurrent.date_salary_payment.ToString();
            }

            string pdfPath = @"C:\Users\User\OneDrive\Desktop\WageFlow_Fullstack\WageFlow.Frontend\WageFlow.Frontend\src\Files\Salary_Payment.pdf";

            document.ExportAsFixedFormat(pdfPath, Word.WdExportFormat.wdExportFormatPDF);

            document.Close(false);
            Salary_PaymentApplicationPDF.Quit();

            Process.Start(new ProcessStartInfo
            {
                FileName = pdfPath,
                UseShellExecute = true
            });
        }
    }
}
