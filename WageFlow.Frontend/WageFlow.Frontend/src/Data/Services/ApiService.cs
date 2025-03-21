using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Frontend.src.Data.Entities.Payments;
using WageFlow.Frontend.src.Data.Entities.Payments_Type;
using WageFlow.Frontend.src.Data.Entities.Post;
using WageFlow.Frontend.src.Data.Entities.Salary_Payment;
using WageFlow.Frontend.src.Data.Entities.Staff;
using WageFlow.Frontend.src.Data.Entities.User;

namespace WageFlow.Frontend.src.Data.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7172/") // Связь с Backend
            };
        }

        public async Task<User> SignIn(string User_name, string User_password)
        {
            var loginData = new { user_name = User_name, user_password = User_password };
            var response = await _httpClient.PostAsJsonAsync("api/User/SignIn", loginData);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<User>();
            }
            return null;
        }

        // Salary_Payment

        public async Task<List<Salary_Payment>> GetSalary_PaymentList()
        {
            var response = await _httpClient.GetAsync("api/Salary_Payment/List");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<Salary_PaymentContain>();
            return result?.salary_Payment ?? new List<Salary_Payment>();

        }

        public async Task CreateSalary_Payment(Salary_Payment salary_Payment)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Salary_Payment/Create", salary_Payment);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateSalary_Payment(Salary_Payment salary_Payment)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Salary_Payment/Update/{salary_Payment.id_salary_payment}", salary_Payment);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteSalary_Payment(int id_salary_payment)
        {
            var response = await _httpClient.DeleteAsync($"api/Salary_Payment/Delete/{id_salary_payment}");
            response.EnsureSuccessStatusCode();
        }

        // Staff

        public async Task<List<Staff>> GetStaffList()
        {
            var response = await _httpClient.GetAsync("api/Staff/List");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<StaffContain>();
            return result?.staff ?? new List<Staff>();

        }

        public async Task CreateStaff(Staff staff)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Staff/Create", staff);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateStaff(Staff staff)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Staff/Update/{staff.id_staff}", staff);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteStaff(int id_staff)
        {
            var response = await _httpClient.DeleteAsync($"api/Staff/Delete/{id_staff}");
            response.EnsureSuccessStatusCode();
        }

        // Post

        public async Task<List<Post>> GetPostList()
        {
            var response = await _httpClient.GetAsync("api/Post/List");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<PostContain>();
            return result?.post ?? new List<Post>();

        }

        // Payments

        public async Task<List<Payments>> GetPaymentsList()
        {
            var response = await _httpClient.GetAsync("api/Payments/List");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<PaymentsContain>();
            return result?.payments ?? new List<Payments>();

        }

        public async Task CreatePayments(Payments payments)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Payments/Create", payments);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdatePayments(Payments payments)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Payments/Update/{payments.id_payments}", payments);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeletePayments(int id_payments)
        {
            var response = await _httpClient.DeleteAsync($"api/Payments/Delete/{id_payments}");
            response.EnsureSuccessStatusCode();
        }

        // Payments_Type

        public async Task<List<Payments_Type>> GetPayments_TypeList()
        {
            var response = await _httpClient.GetAsync("api/Payments_Type/List");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<Payments_TypeContain>();
            return result?.payments_Type ?? new List<Payments_Type>();

        }

    }
}
