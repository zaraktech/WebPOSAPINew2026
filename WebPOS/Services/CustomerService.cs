using System.Net.Http.Json;
using WebPOS.Models;

namespace WebPOS.Services
{
    public class CustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _httpClient.GetFromJsonAsync<List<Customer>>("api/customers");
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await _httpClient.GetFromJsonAsync<Customer>($"api/customers/{id}");
        }

        public async Task<bool> AddCustomer(Customer customer)
        {
            var response = await _httpClient.PostAsJsonAsync("api/customers", customer);

            if (response.IsSuccessStatusCode)
            {
                // Optionally log or process success
                return true;
            }
            else
            {
                // Optionally log the error details
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Failed to add customer: {errorContent}");

                return false;
            }
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/customers/{customer.Id}", customer);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                // Optionally log the error details
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Failed to add customer: {errorContent}");

                return false;
            }
        }

        public async Task DeleteCustomer(int id)
        {
            await _httpClient.DeleteAsync($"api/customers/{id}");
        }


    }
}

