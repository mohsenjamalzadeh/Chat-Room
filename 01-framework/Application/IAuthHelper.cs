using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace _01_framework.Application
{
    public interface IAuthHelper
    {

        void SignIn(AuthViewModel authViewModel);
        void Singout();

    }

    public class AuthViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void SignIn(AuthViewModel authViewModel)
        {

            var claims=new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, authViewModel.Name),
                new Claim("AccountId",authViewModel.Id),
                new Claim("Email",authViewModel.Email),
            };

            var claimsIdentity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties=new AuthenticationProperties()
            {
                ExpiresUtc=DateTimeOffset.UtcNow.AddDays(1)
            };

            _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

        }

         public void Singout()
        {
            _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

       
    }
}
