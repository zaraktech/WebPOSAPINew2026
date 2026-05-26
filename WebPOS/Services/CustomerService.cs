using System.Net.Http.Json;
using Shared.Models;
namespace WebPOS.Services
{
    public class CustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CustomerMaster>> GetCustomers()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<CustomerMaster>>("api/CustomerMaster");
            }

            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message + " " + Ex.InnerException?.Message);
                return new List<CustomerMaster?>();
            }
        }
            

        public async Task<CustomerMaster> GetCustomer(int id)
        {
            return await _httpClient.GetFromJsonAsync<CustomerMaster>($"api/customermaster/{id}");
        }

        public async Task<bool> AddCustomer(CustomerMaster   customer)
        {
            var response = await _httpClient.PostAsJsonAsync("api/customermaster", customer);

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

        public async Task<bool> UpdateCustomer(CustomerMaster customer)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/customers/{customer.CustomerId}", customer);
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

