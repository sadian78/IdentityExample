using IdentityExample.Core.DTOs;
using IdentityExample.Core.Services.IRepository;
using IdentityExample.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Net.WebRequestMethods;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace IdentityExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHomeRepository _repository;

        public HomeController(ILogger<HomeController> logger, IHomeRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        #region PageLogin

        public async Task<IActionResult> Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var client = await _repository.GetInformationClient(model);
            if (client == null)
            {
                return View(model);
            }

            #region Login 
            string ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.MobilePhone,client.PhoneNumber),
                new Claim(ClaimTypes.Name,client.FirstName+" "+client.LastName),
                new Claim(type: "FirstName", value: client.FirstName),
                new Claim(type: "LastName", value: client.LastName),
                new Claim(type: "Age", value: client.Age.ToString()),
                new Claim(type: "Token", value: client.Token),
                new Claim(type: "IpAddress", value: ipAddress),

            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties
            {
                IsPersistent = model.IsRememberMe
            };
            await HttpContext.SignInAsync(principal, properties);
            #endregion

            return RedirectToAction("Index");
        }


        #endregion

        #region PageLogOut

        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        #endregion

        #region PageIndex
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        #endregion




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}