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
using WageFlow.Frontend.src.Data.Entities.Post;
using WageFlow.Frontend.src.Data.Entities.Salary_Payment;
using WageFlow.Frontend.src.Data.Entities.Staff;
using WageFlow.Frontend.src.Data.Services;
using WageFlow.Frontend.src.Pages.Salary_PaymentPages;

namespace WageFlow.Frontend.src.Pages.StaffPages
{
    /// <summary>
    /// Логика взаимодействия для StaffCommandsPage.xaml
    /// </summary>
    public partial class StaffCommandsPage : Page
    {
        private readonly ApiService _apiService;
        private readonly Staff _staff;
        private List<Post> _allPost;
        public StaffCommandsPage(Staff staff = null)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _staff = staff ?? new Staff();
            LoadPost();

            TBoxName.Text = _staff.name_staff;
            TBoxLastName.Text = _staff.lastname_staff;
            TBoxPatronymic.Text = _staff.patronymic_staff;
            TBoxEmail.Text = _staff.email_staff;
            CmbSelectPost.Text = _staff.id_post.ToString();
        }

        private async Task LoadPost()
        {
            try
            {
                _allPost = await _apiService.GetPostList();
                CmbSelectPost.ItemsSource = _allPost.ToList();
                CmbSelectPost.SelectedValuePath = "id_post";
                CmbSelectPost.DisplayMemberPath = "name_post";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки должностей: {ex.Message}");
            }
        }

        private async void StaffSaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _staff.name_staff = TBoxName.Text;
                _staff.lastname_staff = TBoxLastName.Text;
                _staff.patronymic_staff = TBoxPatronymic.Text;
                _staff.email_staff = TBoxEmail.Text;
                _staff.id_post = (int)CmbSelectPost.SelectedValue;

                if (_staff.id_staff == 0)
                {
                    await _apiService.CreateStaff(_staff);
                    MessageBox.Show("Сотрудник успешно добавлен");
                }
                else
                {
                    await _apiService.UpdateStaff(_staff);
                    MessageBox.Show("Сотрудник успешно обновлен");
                }
                NavigationService.Navigate(new StaffPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении сотрудника: {ex.Message}");
            }
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StaffPage());
        }
    }
}
