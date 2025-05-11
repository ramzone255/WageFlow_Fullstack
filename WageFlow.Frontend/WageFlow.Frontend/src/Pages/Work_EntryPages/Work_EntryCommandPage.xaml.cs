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
using WageFlow.Frontend.src.Data.Entities.Staff;
using WageFlow.Frontend.src.Data.Entities.Work_Entry;
using WageFlow.Frontend.src.Data.Entities.Work_Type;
using WageFlow.Frontend.src.Data.Services;
using WageFlow.Frontend.src.Pages.PaymentsPages;

namespace WageFlow.Frontend.src.Pages.Work_EntryPages
{
    /// <summary>
    /// Логика взаимодействия для Work_EntryCommandPage.xaml
    /// </summary>
    public partial class Work_EntryCommandPage : Page
    {
        private readonly ApiService _apiService;
        private readonly Work_Entry _work_Entry;
        private List<Work_Type> _allWork_Type;
        private List<Staff> _allStaff;
        public Work_EntryCommandPage(Work_Entry work_Entry = null)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _work_Entry = work_Entry ?? new Work_Entry();
            LoadWork_Type_Staff();

            TBoxQuantity.Text = _work_Entry.quantity_work_entry.ToString();
            CmbSelectStaff.Text = _work_Entry.id_staff.ToString();
            CmbSelectWork_Type.Text = _work_Entry.id_work_type.ToString();
        }

        private async Task LoadWork_Type_Staff()
        {
            try
            {
                _allWork_Type = await _apiService.GetWork_TypeList();
                CmbSelectWork_Type.ItemsSource = _allWork_Type.ToList();
                CmbSelectWork_Type.SelectedValuePath = "id_work_type";
                CmbSelectWork_Type.DisplayMemberPath = "name_work_type";

                _allStaff = await _apiService.GetStaffList();
                CmbSelectStaff.ItemsSource = _allStaff.ToList();
                CmbSelectStaff.SelectedValuePath = "id_staff";
                CmbSelectStaff.DisplayMemberPath = "lastname_staff";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузке сотрудников или типов работ: {ex.Message}");
            }
        }

        private async void Work_EntrySaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _work_Entry.quantity_work_entry = int.Parse(TBoxQuantity.Text);
                _work_Entry.id_staff = (int)CmbSelectStaff.SelectedValue;
                _work_Entry.id_work_type = (int)CmbSelectWork_Type.SelectedValue;

                if (_work_Entry.id_work_entry == 0)
                {
                    await _apiService.CreateWork_Entry(_work_Entry);
                    MessageBox.Show("Работа успешно добавлена");
                }
                else
                {
                    await _apiService.UpdateWork_Entry(_work_Entry);
                    MessageBox.Show("Работа успешно обновлена");
                }
                NavigationService.Navigate(new Work_EntryPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении работ: {ex.Message}");
            }
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Work_EntryPage());
        }
    }
}
