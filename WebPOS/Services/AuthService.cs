// Services/AuthService.cs
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using System.Security.Claims;


public class AuthService
{
    private readonly HttpClient _httpClient;
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly ILocalStorageService _localStorage;

    public AuthService(HttpClient httpClient,
                      AuthenticationStateProvider authenticationStateProvider,
                      ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _authenticationStateProvider = authenticationStateProvider;
        _localStorage = localStorage;
    }

    public async Task<string> Login(LoginModel loginModel)
    {
        var response = await _httpClient.PostAsJsonAsync("api/login", loginModel);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var token = await response.Content.ReadAsStringAsync();
        await _localStorage.SetItemAsync("authToken", token);
        ((CustomAuthStateProvider)_authenticationStateProvider).NotifyUserAuthentication(token);
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);

        return token;
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");
        ((CustomAuthStateProvider)_authenticationStateProvider).NotifyUserLogout();
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }

    public async Task<UserInfo> GetCurrentUser()
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity.IsAuthenticated)
        {
            return new UserInfo
            {
                Username = user.Identity.Name,
                // Add other claims you need from the token
                Roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList()
            };
        }

        return null;
    }
}

public class UserInfo
{
    public string Username { get; set; }
    public List<string> Roles { get; set; } = new List<string>();
}

public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}