using Application.Common.Interfaces;
using Application.DTO.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userService)
        {
            _userRepository = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            var response = new LoginDto();
            return View(response);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto loginVM)
        {
            try
            {
                var userVm = await _userRepository.GetUserByUserNameAsync(loginVM);

                if (userVm == null || !userVm.IsEnabled)
                {
                    TempData["Error"] = "Please try again";
                    return View(loginVM);
                }
                else
                {
                    await HttpContext.SignOutAsync();

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, userVm.Id.ToString()),
                        new Claim(ClaimTypes.Name, userVm.UserName),
                        new Claim("FullName", userVm.FullName),
                        new Claim(ClaimTypes.Email, userVm.Email)
                    };

                    foreach (var role in userVm.UserRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return LocalRedirect("/Home");
                }
            }
            catch (Exception ex)
            {
                // Обработка исключения
                return View(loginVM);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }

}
