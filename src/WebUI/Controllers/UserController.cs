using Application.DTO;
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
            var userList = await Mediator.Send(new GetAllUsers());
            return View(userList);
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

            return View(user);
        }

        //// GET: User/Create
        public async Task<IActionResult> Upsert(int id)
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

            return View(updateUserVm);
        }


        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(UpsertUserDto createUser)
        {
            if (ModelState.IsValid)
            {
                if (await Mediator.Send(new UpsertUser { UpsertUserDto = createUser }))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Upsert));
        }

        ////// GET: User/Edit/5
        //public async Task<IActionResult> Edit(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var rolesVm = await Mediator.Send(new GetAllRoles());
        //    var updateUserVm = await Mediator.Send(new GetUserById { Id = id });

        //    var selectListItemRoleVm = rolesVm.Select(x => new SelectListItem
        //    {
        //        Value = x.Id.ToString(),
        //        Text = x.Name,
        //        // Check if this role is one of the user's roles
        //        Selected = updateUserVm.RolesId.Contains(x.Id)
        //    });

        //    ViewBag.Roles = selectListItemRoleVm; // All Exist Roles

        //    if (updateUserVm == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(updateUserVm);
        //}


        ////// POST: User/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, UpdateUserDto updateUserDto)
        //{
        //    if (id != updateUserDto.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            //Add if
        //            await _userRepository.Update(updateUserDto);
        //        }
        //        catch (Exception ex)
        //        {
        //            if (!await _userRepository.UserExists(updateUserDto.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(updateUserDto);
        //}

        //GET: User/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var user = await Mediator.Send(new GetUserById { Id = id });
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await Mediator.Send(new DeleteUser { Id = id }))
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
            //if (await _userRepository.UserExists(id))
            //{
            //    await _userRepository.Delete(id);
            //    //return RedirectToAction(nameof(Index));
            //}


        }

    }
}
