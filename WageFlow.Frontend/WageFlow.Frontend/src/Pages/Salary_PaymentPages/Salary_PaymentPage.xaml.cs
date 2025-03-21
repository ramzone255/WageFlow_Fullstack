using System;
using System.Collections;
using System.Collections.Generic;
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
using WageFlow.Frontend.src.Data.Entities.Salary_Payment;
using WageFlow.Frontend.src.Data.Entities.Staff;
using WageFlow.Frontend.src.Data.Entities.User;
using WageFlow.Frontend.src.Data.Services;
using WageFlow.Frontend.src.Pages.StaffPages;

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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки отчетов: {ex.Message}");
            }
        }

        private void Work_EntryClick(object sender, RoutedEventArgs e)
        {

        }

        private void PaymentsClick(object sender, RoutedEventArgs e)
        {

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

        private void Salary_Payment_PaymentsClick(object sender, RoutedEventArgs e)
        {

        }

        private void Salary_Payment_Work_Entry_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
