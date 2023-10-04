using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace FirstBlazorApp.Data.Providers;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, "Ramil2112@mail.ru")
            },
            "apiauth_type");

        var emptyIdentity = new ClaimsIdentity();

        var user = new ClaimsPrincipal(emptyIdentity);

        return Task.FromResult(new AuthenticationState(user));
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
}