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
using WageFlow.Frontend.src.Pages.PaymentsPages;
using WageFlow.Frontend.src.Pages.Salary_PaymentPages;

namespace WageFlow.Frontend.src.Pages.StaffPages
{
    /// <summary>
    /// Логика взаимодействия для StaffPage.xaml
    /// </summary>
    public partial class StaffPage : Page
    {
        private readonly ApiService _apiService;
        private List<Staff> _allStaff;
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
    }
}
