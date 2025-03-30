using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace TdoT_Backend.Middleware;

public class AuthenticationMiddleware : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public AuthenticationMiddleware(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock)
        : base(options, logger, encoder, clock)
    { }


    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        string password = File.ReadAllText("Data/adminPassword.txt");
        Request.Headers.TryGetValue("password", out var auth);
        var crypto = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(password ?? "")));
        if (string.Equals(crypto, auth.ToString(), StringComparison.CurrentCultureIgnoreCase) || password?.Length == 0)
        {
            var claims = new[] { new Claim(ClaimTypes.Role, "Admin") };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
        return Task.FromResult(AuthenticateResult.NoResult());
    }
}