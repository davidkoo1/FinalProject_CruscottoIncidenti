﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class BaseController : Controller
    {
        private IMediator _mediator = null!;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
