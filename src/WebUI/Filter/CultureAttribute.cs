﻿using Microsoft.AspNetCore.Mvc.Filters;
using System.Globalization;
using System.Web.Http.Filters;
using WebUI.Controllers;
using IActionFilter = Microsoft.AspNetCore.Mvc.Filters.IActionFilter;

namespace WebUI.Filter
{
    public class CultureAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string cultureName = null;
            // Получаем куки из контекста, которые могут содержать установленную культуру
            var controller = filterContext.Controller as BaseController;

            var cultureCookie = controller.GetLanguageCookie();

            if (cultureCookie != null)
                cultureName = cultureCookie.ToLower();
            else
            {
                cultureName = "en";
            }

            // Список культур
            List<string> cultures = new() { "en", "ro", "ru" };
            if (!cultures.Contains(cultureName))
            {
                cultureName = "en";
            }
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {

        }
    }
}
