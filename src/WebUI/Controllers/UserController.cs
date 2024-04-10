﻿using Application.DTO;
using Application.RoleCQRS.Queries;
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
        }

        [HttpPost]
        public async Task<ActionResult> LoadData()
        {
            try
            {

                var draw = Request.Form["draw"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
                int skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
                // Paging Size (10,20,50,100)

                int recordsTotal = 0;

                // Getting all Customer data
                var customerData = await Mediator.Send(new GetAllUsers());

                // Sorting
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    // Example sorting for one column (modify as needed)
                    switch (sortColumn)
                    {
                        case "CreatedBy":
                            customerData = sortColumnDirection == "asc" ? customerData.OrderBy(m => m.CreatedBy) : customerData.OrderByDescending(m => m.CreatedBy);
                            break;
                        case "Created":
                            customerData = sortColumnDirection == "asc" ? customerData.OrderBy(m => m.Created) : customerData.OrderByDescending(m => m.Created);
                            break;
                        // Add cases for other sortable columns
                        default:
                            break;
                    }
                }

                // Search
                //if (!string.IsNullOrEmpty(searchValue))
                //{
                //    customerData = customerData.Where(m => m.CompanyName.Contains(searchValue)); // Modify CompanyName with your actual property to search
                //}

                // Total number of rows count
                recordsTotal = customerData.Count();

                // Paging
                var data = customerData.Skip(skip).Take(pageSize).ToList();

                // Returning Json Data
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
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
            var rolesVm = await Mediator.Send(new GetAllRoles());
            var updateUserVm = await Mediator.Send(new GetUserForUpsert { Id = id });

            var selectListItemRoleVm = rolesVm.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = updateUserVm.Id != 0 ? updateUserVm.RolesId.Contains(x.Id) : false
            });

            ViewBag.Roles = selectListItemRoleVm;
            //return View("~/Views/User/Upsert.cshtml", updateUserVm);
            return PartialView("~/Views/User/Upsert.cshtml", updateUserVm);

        }


        // POST: User/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(UpsertUserDto createUser)
        {
            if (ModelState.IsValid)
            {
                if (await Mediator.Send(new UpsertUser { UpsertUserDto = createUser }))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
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
