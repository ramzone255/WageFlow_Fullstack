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
using WageFlow.Frontend.src.Data.Entities.User;
using WageFlow.Frontend.src.Data.Services;

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
                MessageBox.Show($"Ошибка загрузки сотрудников: {ex.Message}");
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

        }

        private void AddClick(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {

        }

        private void Salary_Payment_PaymentsClick(object sender, RoutedEventArgs e)
        {

        }

        private void Salary_Payment_Work_Entry_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
