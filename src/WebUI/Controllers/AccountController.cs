using Application.DTO;
using Application.UserCQRS.Queries;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebUI.Controllers
{
    public class AccountController : BaseController
    {

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            //var response = new LoginDto();
            if (!User.Identity.IsAuthenticated)
                return View();
            else
                return RedirectToAction(nameof(IncidentController.Index), "Incident");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto loginVM)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                loginVM.Username = "Crme145";
                loginVM.Password = "Cedacri1234567!";
                var userVm = await Mediator.Send(new GetUserForLogin
                {
                    Username = loginVM.Username,
                    Password = loginVM.Password
                });

                if (userVm == null || !userVm.IsEnabled)
                {
                    TempData["Error"] = "Please try again";
                    return View(loginVM);
                }
                else
                {
                    await HttpContext.SignOutAsync();

                    var userClaims = new List<Claim>
                     {
                         new Claim(ClaimTypes.NameIdentifier, userVm.Id.ToString()),
                         new Claim(ClaimTypes.Name, userVm.UserName),
                         new Claim("FullName", userVm.FullName),
                         new Claim(ClaimTypes.Email, userVm.Email),
                         new Claim("UiLanguage", GetLanguageCookie())

                     };

                    foreach (var role in userVm.UserRoles)
                    {
                        userClaims.Add(new Claim(ClaimTypes.Role, role.Role.Name));
                    }
                    Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
               CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(GetLanguageCookie().ToString())),
               new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });

                    var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(new[] { claimsIdentity });

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                    return RedirectToAction("Index", "Incident");
                }
            }
            catch (Exception ex)
            {
                // Обработка исключения
                return View(loginVM);
            }
        }

        //[HttpPost]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ChangeCultureLogin(string shortLang)
        {


            List<string> cultures = new() { "en", "ro", "ru" };
            if (!cultures.Contains(shortLang))
            {
                shortLang = "en";
            }

            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(shortLang)),
                                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return RedirectToAction("Login");



        }
    }

}
