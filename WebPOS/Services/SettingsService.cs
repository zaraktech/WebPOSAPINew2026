using System.Net.Http.Json;
using WebPOS.ViewModels;

namespace WebPOS.Services
{
    public class SettingsService
    {

        private readonly HttpClient _httpClient;

        public SettingsService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }


        public async Task<SettingVM> GetSetting(string KeyName)
        {
            return await _httpClient.GetFromJsonAsync<SettingVM>($"api/Settings/{KeyName}");
        }
    }
}
