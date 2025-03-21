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
using WageFlow.Frontend.src.Data.Entities.Payments_Type;
using WageFlow.Frontend.src.Data.Entities.Post;
using WageFlow.Frontend.src.Data.Entities.Staff;
using WageFlow.Frontend.src.Data.Services;
using WageFlow.Frontend.src.Pages.StaffPages;

namespace WageFlow.Frontend.src.Pages.PaymentsPages
{
    /// <summary>
    /// Логика взаимодействия для PaymentsCommandsPage.xaml
    /// </summary>
    public partial class PaymentsCommandsPage : Page
    {
        private readonly ApiService _apiService;
        private readonly Payments _payments;
        private List<Payments_Type> _allPayments_Type;
        private List<Staff> _allStaff;
        public PaymentsCommandsPage(Payments payments = null)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _payments = payments ?? new Payments();
            LoadPayments_Staff();

            TBoxAmount.Text = _payments.amount_payments.ToString();
            TBoxComment.Text = _payments.comment;
            CmbSelectStaff.Text = _payments.id_staff.ToString();
            CmbSelectPayments_Type.Text = _payments.id_payments_type.ToString();
        }

        private async Task LoadPayments_Staff()
        {
            try
            {
                _allPayments_Type = await _apiService.GetPayments_TypeList();
                CmbSelectPayments_Type.ItemsSource = _allPayments_Type.ToList();
                CmbSelectPayments_Type.SelectedValuePath = "id_payments_type";
                CmbSelectPayments_Type.DisplayMemberPath = "name_payments_type";

                _allStaff = await _apiService.GetStaffList();
                CmbSelectStaff.ItemsSource = _allStaff.ToList();
                CmbSelectStaff.SelectedValuePath = "id_staff";
                CmbSelectStaff.DisplayMemberPath = "lastname_staff";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузке сотрудников или типов выплат: {ex.Message}");
            }
        }

        private async void PaymentsSaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _payments.amount_payments = float.Parse(TBoxAmount.Text);
                _payments.comment = TBoxComment.Text;
                _payments.id_staff = (int)CmbSelectStaff.SelectedValue;
                _payments.id_payments_type = (int)CmbSelectPayments_Type.SelectedValue;

                if (_payments.id_payments == 0)
                {
                    await _apiService.CreatePayments(_payments);
                    MessageBox.Show("Выплата успешно добавлена");
                }
                else
                {
                    await _apiService.UpdatePayments(_payments);
                    MessageBox.Show("Выплата успешно обновлена");
                }
                NavigationService.Navigate(new PaymentsPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении выплаты: {ex.Message}");
            }
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PaymentsPage());
        }
    }
}
