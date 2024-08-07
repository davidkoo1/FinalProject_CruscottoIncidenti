﻿using Application.DTO;
using Application.Resources;
using Application.RoleCQRS.Queries;
using Application.TableParameters;
using Application.UserCQRS.Commands;
using Application.UserCQRS.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;

namespace WebUI.Controllers
{

    [Authorize(Roles = "Admin")]
    public class UserController : BaseController
    {

        // GET: Users
        public async Task<IActionResult> Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LoadDatatable(DataTablesParameters parameters = null!)
        {
            try
            {
                var result = await Mediator.Send(new GetAllUsers(parameters));
                //return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
                return Ok(new
                {
                    draw = parameters.Draw,
                    recordsFiltered = parameters.TotalCount,
                    recordsTotal = parameters.TotalCount,
                    data = result
                });

            }
            catch (Exception ex)
            {
                Log.Error($"Error in User.LoadDatatable", ex);
                return View("~/Views/Shared/_NotFound.cshtml");
            }
        }


        //// GET: User/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var user = await Mediator.Send(new GetUserById { Id = id });

                if (user == null)
                {
                    return NotFound();
                }
                return PartialView("~/Views/User/Details.cshtml", user);
            }
            catch (Exception ex)
            {
                Log.Error($"Error in User.Details with ID {id}", ex);
                return View("~/Views/Shared/_NotFound.cshtml");
            }

        }

        //// GET: User/Create
        public async Task<IActionResult> GetUpsert(int id)
        {
            try
            {
                var updateUserVm = await Mediator.Send(new GetUserForUpsert { Id = id });

                await SetUserRoleList(updateUserVm);
                return PartialView("~/Views/User/Upsert.cshtml", updateUserVm);
            }
            catch (Exception ex)
            {
                Log.Error($"Error in User.GetUpsert with ID {id}", ex);
                return View("~/Views/Shared/_NotFound.cshtml");
            }


        }

        private async Task SetUserRoleList(UpsertUserDto createUser)
        {
            try
            {
                var rolesVm = await Mediator.Send(new GetAllRoles());
                var selectListItemRoleVm = rolesVm.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name,
                    Selected = createUser.Id != 0 && createUser.RolesId != null ? createUser.RolesId.Contains(x.Id) : false
                });

                ViewBag.Roles = selectListItemRoleVm;
            }
            catch (Exception ex)
            {
                Log.Information("UpsertUserDto => {@createUser}", createUser);
                Log.Error("User.SetUserRoleList", ex);
                throw;
            }

        }
        // POST: User/Create
        [HttpPost]
        public async Task<IActionResult> Upsert(UpsertUserDto createUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await Mediator.Send(new UpsertUser { UpsertUserDto = createUser });
                    if (result)
                    {
                        // return Json(new { success = true/*, redirectUrl = Url.Action(nameof(Index))*/ });
                        return Json(new { success = true });
                    }
                    else
                    {
                        TempData["ErrorUser"] = Localization.ErrorUser1 + ".\n" + Localization.ErrorTryAgain;
                        await SetUserRoleList(createUser);
                        return PartialView("~/Views/User/Upsert.cshtml", createUser);
                    }

                }
                TempData["ErrorUser"] = Localization.ErrorCorrectData + ".\n" + Localization.ErrorTryAgain;
                await SetUserRoleList(createUser);
                return PartialView("~/Views/User/Upsert.cshtml", createUser);
            }
            catch (Exception ex)
            {
                Log.Information("UpsertUserDto => {@createUser}", createUser);
                Log.Error("User.Upsert", ex);
                return View("~/Views/Shared/_NotFound.cshtml");
            }

        }


        //GET: User/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await Mediator.Send(new GetUserById { Id = id });
                if (user == null)
                {
                    return NotFound();
                }

                return PartialView("~/Views/User/Delete.cshtml", user);
            }
            catch (Exception ex)
            {
                Log.Error($"Error in User.Delete with ID {id}", ex);
                return View("~/Views/Shared/_NotFound.cshtml");
            }

        }

        // POST: User/Delete/5
        [HttpPost/*ActionName*/]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var success = await Mediator.Send(new DeleteUser { Id = id });
                if (success)
                {
                    return Json(new { success = true });
                }
                else
                {
                    Log.Error($"Error in Else.User.DeleteConfirmed with ID {id}");
                    return Json(new { success = false, message = Localization.ErrorUser2 + ".\n" + Localization.ErrorTryAgain });
                    
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Error in User.DeleteConfirmed with ID {id}", ex);
                return View("~/Views/Shared/_NotFound.cshtml");
            }

        }


    }
}
