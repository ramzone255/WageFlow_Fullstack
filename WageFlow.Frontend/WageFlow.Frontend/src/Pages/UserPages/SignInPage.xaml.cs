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
using WageFlow.Frontend.src.Data.Entities.User;
using WageFlow.Frontend.src.Data.Services;
using WageFlow.Frontend.src.Pages.Salary_Payment;

namespace WageFlow.Frontend.src.Pages.UserPages
{
    /// <summary>
    /// Логика взаимодействия для SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        private readonly ApiService _apiService;
        public SignInPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }

        private async void SignInClick(object sender, RoutedEventArgs e)
        {
            string User_name = TBoxUserName.Text;
            string User_password = TBoxUserPassword.Text;

            var user = await _apiService.SignIn(User_name, User_password);
            if (user != null)
            {
                UserSession.CurrentUser = user;
                NavigationService.Navigate(new Salary_PaymentPage());
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
    }
}
