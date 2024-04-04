using Application.Common.Interfaces;
using Application.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _userRepository.GetUsersAsync());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDto = await _userRepository.GetUserByIdAsync(id);
            if (userDto == null)
            {
                return NotFound();
            }

            return View(userDto);
        }

        // GET: User/Create
        public async Task<IActionResult> Create()
        {
            var rolesVm = await _userRepository.GetRolesAsync();

            var selectListItemRoleVm = rolesVm.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = false,
            });
            ViewBag.Roles = selectListItemRoleVm;

            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserDto createUserDto)
        {
            if (ModelState.IsValid)
            {
                if (await _userRepository.Add(createUserDto))
                {
                    return RedirectToAction(nameof(Index));
                }
                TempData["Error"] = "Email or username in use!";
            }
            return RedirectToAction(nameof(Create));
        }

        //// GET: User/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolesVm = await _userRepository.GetRolesAsync();
            var updateUserVm = await _userRepository.GetUserForEdit(id); // Include user roles here as well

            var selectListItemRoleVm = rolesVm.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                // Check if this role is one of the user's roles
                Selected = updateUserVm.RolesId.Contains(x.Id)
            });

            ViewBag.Roles = selectListItemRoleVm; // All Exist Roles

            if (updateUserVm == null)
            {
                return NotFound();
            }

            return View(updateUserVm);
        }


        //// POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateUserDto updateUserDto)
        {
            if (id != updateUserDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Add if
                    await _userRepository.Update(updateUserDto);
                }
                catch (Exception ex)
                {
                    if (!await _userRepository.UserExists(updateUserDto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(updateUserDto);
        }

        //GET: User/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var user = await _userRepository.GetUserByIdAsync(id);
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

            if (await _userRepository.UserExists(id))
            {
                await _userRepository.Delete(id);
                //return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
