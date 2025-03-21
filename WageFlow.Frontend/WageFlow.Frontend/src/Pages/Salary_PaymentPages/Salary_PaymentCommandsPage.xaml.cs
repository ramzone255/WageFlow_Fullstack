using System;
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
using WageFlow.Frontend.src.Data.Services;

namespace WageFlow.Frontend.src.Pages.Salary_PaymentPages
{
    /// <summary>
    /// Логика взаимодействия для Salary_PaymentCommandsPage.xaml
    /// </summary>
    public partial class Salary_PaymentCommandsPage : Page
    {
        private readonly ApiService _apiService;
        private readonly Salary_Payment _salary_Payment;
        private List<Staff> _allStaff;

        public Salary_PaymentCommandsPage(Salary_Payment salary_Payment = null)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _salary_Payment = salary_Payment ?? new Salary_Payment();
            LoadStaff();

            TBoxStart_Date_Salary_Payment.Text = _salary_Payment.start_date_salary_payment.ToString();
            TBoxEnd_Date_Salary_Payment.Text = _salary_Payment.end_date_salary_payment.ToString();
            CmbSelectStaff.Text = _salary_Payment.id_staff.ToString();
        }

        private async Task LoadStaff()
        {
            try
            {
                _allStaff = await _apiService.GetStaffList();
                CmbSelectStaff.ItemsSource = _allStaff.ToList();
                CmbSelectStaff.SelectedValuePath = "id_staff";
                CmbSelectStaff.DisplayMemberPath = "lastname_staff";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки сотрудников: {ex.Message}");
            }
        }

        private async void Salary_PaymentSaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _salary_Payment.start_date_salary_payment = DateOnly.Parse(TBoxStart_Date_Salary_Payment.Text);
                _salary_Payment.end_date_salary_payment = DateOnly.Parse(TBoxEnd_Date_Salary_Payment.Text);
                _salary_Payment.id_staff = (int)CmbSelectStaff.SelectedValue;

                if (_salary_Payment.id_salary_payment == 0)
                {
                    await _apiService.CreateSalary_Payment(_salary_Payment);
                    MessageBox.Show("Отчет по заработной плате успешно добавлен");
                }
                else
                {
                    await _apiService.UpdateSalary_Payment(_salary_Payment);
                    MessageBox.Show("Отчет по заработной плате успешно обновлен");
                }
                NavigationService.Navigate(new Salary_PaymentPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении отчета: {ex.Message}");
            }
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Salary_PaymentPage());
        }
    }
}
