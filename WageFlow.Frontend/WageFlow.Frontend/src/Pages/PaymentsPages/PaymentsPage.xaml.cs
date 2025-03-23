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
using WageFlow.Frontend.src.Data.Entities.Payments;
using WageFlow.Frontend.src.Data.Entities.Staff;
using WageFlow.Frontend.src.Data.Services;
using WageFlow.Frontend.src.Pages.Salary_PaymentPages;
using WageFlow.Frontend.src.Pages.StaffPages;
using WageFlow.Frontend.src.Pages.Work_EntryPages;

namespace WageFlow.Frontend.src.Pages.PaymentsPages
{
    /// <summary>
    /// Логика взаимодействия для PaymentsPage.xaml
    /// </summary>
    public partial class PaymentsPage : Page
    {
        private readonly ApiService _apiService;
        private List<Payments> _allPayments;
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
    }
}
