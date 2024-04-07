using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class BaseController : Controller
    {
        private IMediator _mediator = null!;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        public async Task<IActionResult> ChangeCulture(string shortLang, string returnUrl)
        {
            try
            {
                //Log.Information($"ChangeCulture | {shortLang}");
                var uiLanguage = EnUiLanguage.RU;
                List<string> cultures = new List<string>() { "en", "ro", "ru" };
                if (!cultures.Contains(shortLang))
                {
                    shortLang = "en";
                }

                switch (shortLang)
                {
                    case "en":
                        uiLanguage = EnUiLanguage.EN;
                        break;
                    case "ro":
                        uiLanguage = EnUiLanguage.RO;
                        break;
                    case "ru":
                        uiLanguage = EnUiLanguage.RU;
                        break;
                    default:
                        uiLanguage = EnUiLanguage.EN;
                        break;
                }


                //var userClaims = GetUserClaims();

                //Getting principal claims that are read-only
                var claimPrincipal = User as ClaimsPrincipal;
                //Getting claimIdentity from principalClaim
                var claimIdentity = claimPrincipal.Identity as ClaimsIdentity;
                //Finding claim we need to read or edit
                var claim = (from c in claimPrincipal.Claims
                             where c.Type == "UiLanguage"
                             select c).Single();

                if (claim != null)
                {
                    //SignOut to unlock claims for mananging them
                    await HttpContext.SignOutAsync();

                    //Creating new claim to change our token after refresh
                    var claimNew = new Claim("UiLanguage", uiLanguage.ToString());
                    //Try remove claim selected from claimIdentity
                    //If we use RemoveClaim we can get excetion if claim can't be removed
                    claimIdentity.TryRemoveClaim(claim);
                    //Add new claim
                    claimIdentity.AddClaim(claimNew);
                    //SignIn to save claim principal
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal);
                }
                Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(shortLang)), new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });

                return await ChangeLanguage((int)uiLanguage, returnUrl);
            }
            catch (Exception ex)
            {
                var uiLanguage = EnUiLanguage.RU;
                return await ChangeLanguage((int)uiLanguage, returnUrl);
            }
        }


        [HttpGet]
        public async Task<IActionResult> ChangeLanguage(int lang, string returnUrl)
        {
            try
            {
                return await ChangeLanguage(lang, returnUrl);


            }
            catch (Exception ex)
            {
                return LocalRedirect(returnUrl ?? "/");
            }
            return LocalRedirect(returnUrl ?? "/");
        }

        public string GetLanguageCookie()
        {
            var cookie = Request.Cookies[CookieRequestCultureProvider.DefaultCookieName];
            if (cookie == null)
            {
                return "en";
            }
            else
            {
                var c_uic = cookie.Split('|');
                var culture = c_uic[0].Split("=");

                return culture[1];
            }
        }
    }
}
