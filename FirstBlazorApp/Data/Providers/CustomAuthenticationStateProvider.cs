using System.Security.Claims;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace FirstBlazorApp.Data.Providers;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private ISessionStorageService _sessionStorage;
    public CustomAuthenticationStateProvider(ISessionStorageService sessionStorage)
    {
        this._sessionStorage = sessionStorage;
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var email = await _sessionStorage.GetItemAsync<string>("emailAddress");

        ClaimsIdentity identity;
        if (!string.IsNullOrEmpty(email))
        {
            identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, email)
                },
                "apiauth_type");
        }
        else
        {
            identity = new ClaimsIdentity();
        }


        var user = new ClaimsPrincipal(identity);

        return await Task.FromResult(new AuthenticationState(user));
    }

    public void MarkUserAsAuthenticated(string emailAddress)
    {
        var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, emailAddress)
            },
            "apiauth_type");

        var user = new ClaimsPrincipal(identity);
        
        //Этого вызова достаточно для оповещения состемы об успешной авторизации
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }
    
    public async Task MarkUserAsLoggedOut()
    {
        var emptyIdentity = new ClaimsIdentity();
        var user = new ClaimsPrincipal(emptyIdentity);

        await this._sessionStorage.RemoveItemAsync("emailAddress");
        
        //Этого вызова достаточно для оповещения состемы об успешной деавторизации. Т.к. передаем юзера с пустыми данными
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }
}