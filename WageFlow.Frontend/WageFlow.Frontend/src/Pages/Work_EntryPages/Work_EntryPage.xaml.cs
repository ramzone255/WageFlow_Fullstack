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
using WageFlow.Frontend.src.Data.Entities.Work_Entry;
using WageFlow.Frontend.src.Data.Services;
using WageFlow.Frontend.src.Pages.PaymentsPages;
using WageFlow.Frontend.src.Pages.Salary_PaymentPages;
using WageFlow.Frontend.src.Pages.StaffPages;

namespace WageFlow.Frontend.src.Pages.Work_EntryPages
{
    /// <summary>
    /// Логика взаимодействия для Work_EntryPage.xaml
    /// </summary>
    public partial class Work_EntryPage : Page
    {
        private readonly ApiService _apiService;
        private List<Work_Entry> _allWork_Entry;
        public Work_EntryPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
            LoadWork_Entry();
        }

        private async Task LoadWork_Entry()
        {
            try
            {
                _allWork_Entry = await _apiService.GetWork_EntryList();
                Work_EntryListView.ItemsSource = _allWork_Entry.OrderBy(x => x.lastname_staff);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки выработки работ: {ex.Message}");
            }
        }

        private void PaymentsClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PaymentsPage());
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
            NavigationService.Navigate(new Work_EntryCommandPage());
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            if (Work_EntryListView.SelectedItem is Work_Entry selectedWork_Entry)
            {
                NavigationService.Navigate(new Work_EntryCommandPage(selectedWork_Entry));
            }
            else
            {
                MessageBox.Show("Выберите работу для редактирования");
            }
        }

        private async void DeleteClick(object sender, RoutedEventArgs e)
        {
            if (Work_EntryListView.SelectedItem is Work_Entry selectedWork_Entry)
            {
                var result = MessageBox.Show($"Вы уверены, что хотите удалить работа {selectedWork_Entry.name_work_type} для сотрудника {selectedWork_Entry.lastname_staff}?", "Подтверждение удаления", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        await _apiService.DeleteWork_Entry(selectedWork_Entry.id_work_entry);
                        MessageBox.Show("Работа успешно удалена.");
                        await LoadWork_Entry();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении работы: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите работу для удаления.");
            }
        }

        private void Salary_Payment_Work_Entry_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
