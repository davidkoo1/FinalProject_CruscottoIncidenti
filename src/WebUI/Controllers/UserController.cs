using Application.DTO;
using Application.RoleCQRS.Queries;
using Application.TableParameters;
using Application.UserCQRS.Commands;
using Application.UserCQRS.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Controllers
{

    [Authorize(Roles = "Admin")]
    public class UserController : BaseController
    {

        // GET: Users
        public async Task<IActionResult> Index()
        {
            //var userList = await Mediator.Send(new GetAllUsers());
            return View(/*userList*/);
            //return PartialView("~/Views/User/Index.cshtml");
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
            catch (Exception)
            {
                throw;
            }
        }


        //// GET: User/Details/5
        public async Task<IActionResult> Details(int id)
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
            //return View(user);
        }

        //// GET: User/Create
        public async Task<IActionResult> GetUpsert(int id)
        {
            //var rolesVm = await Mediator.Send(new GetAllRoles());
            var updateUserVm = await Mediator.Send(new GetUserForUpsert { Id = id });

            await SetUserRoleList(updateUserVm);
            //return View("~/Views/User/Upsert.cshtml", updateUserVm);
            return PartialView("~/Views/User/Upsert.cshtml", updateUserVm);

        }

        private async Task SetUserRoleList(UpsertUserDto createUser)
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
        // POST: User/Create
        [HttpPost]
        public async Task<IActionResult> Upsert(UpsertUserDto createUser)
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
                    TempData["Error"] = "Please try again";
                    await SetUserRoleList(createUser);
                    // Если ModelState не валиден, возвращаем частичное представление с ошибками
                    return PartialView("~/Views/User/Upsert.cshtml", createUser);
                }

            }
            TempData["Error"] = "Please give correct input";
            await SetUserRoleList(createUser);
            // Если ModelState не валиден, возвращаем частичное представление с ошибками
            return PartialView("~/Views/User/Upsert.cshtml", createUser);
        }


        //GET: User/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var user = await Mediator.Send(new GetUserById { Id = id });
            if (user == null)
            {
                return NotFound();
            }

            return PartialView("~/Views/User/Delete.cshtml", user);
        }

        // POST: User/Delete/5
        [HttpPost/*ActionName*/]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await Mediator.Send(new DeleteUser { Id = id });
            if (success)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Не удалось удалить пользователя." });
            }
        }


    }
}
