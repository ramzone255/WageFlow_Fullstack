using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Frontend.src.Data.Entities.Salary_Payment;
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
    }
}
