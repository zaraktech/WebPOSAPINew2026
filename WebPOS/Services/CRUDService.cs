using System.Net.Http.Json;

namespace WebPOS.Services
{
    public class CRUDService<T> : ICRUDService<T> where T : class
    {
        private readonly HttpClient _httpClient;

        private readonly string _endpoint;

        public CRUDService(HttpClient httpClient,string endpoint)
        {
            _httpClient = httpClient;
            _endpoint = endpoint;
        }

        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                return await _httpClient
                    .GetFromJsonAsync<List<T>>(_endpoint)
                    ?? new List<T>();
            }
            catch
            {
                return new List<T>();
            }
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient
                    .GetFromJsonAsync<T>(
                        $"{_endpoint}/{id}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                var response = await _httpClient
                    .PostAsJsonAsync(
                        _endpoint,
                        entity);

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(
            int id,
            T entity)
        {
            try
            {
                var response = await _httpClient
                    .PutAsJsonAsync(
                        $"{_endpoint}/{id}",
                        entity);

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient
                    .DeleteAsync(
                        $"{_endpoint}/{id}");

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }

}
