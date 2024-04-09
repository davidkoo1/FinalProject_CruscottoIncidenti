using Application.DTO;
using Application.RoleCQRS.Queries;
using Application.UserCQRS.Commands;
using Application.UserCQRS.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.Serialization;

namespace WebUI.Controllers
{
    [Serializable]
    [DataContract]
    public class DataTablesParameters
    {
        [DataMember(Name = "totalCount")]
        public int TotalCount { get; set; }

        [DataMember(Name = "draw")]
        public int Draw { get; set; }

        [DataMember(Name = "start")]
        public int Start { get; set; }

        [DataMember(Name = "length")]
        public int Length { get; set; }

        [DataMember(Name = "columns")]
        public List<DataTablesColumn> Columns { get; set; }

        [DataMember(Name = "search")]
        public DataTablesSearch Search { get; set; }

        [DataMember(Name = "order")]
        public List<DataTablesOrder> Order { get; set; }

        /// <summary>
        /// Used for sorting
        /// </summary>
        public void SetColumnName()
        {
            foreach (var item in Order)
            {
                item.Name = Columns[item.Column].Data;
            }
        }

    }
    [Serializable]
    [DataContract]
    public class DataTablesOrder
    {
        [DataMember(Name = "column")]
        public int Column { get; set; }

        [DataMember(Name = "dir")]
        public string Dir { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
    [Serializable]
    [DataContract]
    public class DataTablesColumn
    {
        [DataMember(Name = "data")]
        public string Data { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "searchable")]
        public bool Searchable { get; set; }

        [DataMember(Name = "orderable")]
        public bool Orderable { get; set; }

        [DataMember(Name = "search")]
        public DataTablesSearch Search { get; set; }
    }
    [Serializable]
    [DataContract]
    public class DataTablesSearch
    {
        public DataTablesSearch()
        {
            Values = new List<string>();
        }

        [DataMember(Name = "value")]
        public string Value { get; set; }

        public ICollection<string> Values { get; set; }

        [DataMember(Name = "regex")]
        public string Regex { get; set; }
    }
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
        public async Task<ActionResult> LoadData(DataTablesParameters parameters)
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
            return View("~/Views/User/Upsert.cshtml", updateUserVm);
            //return PartialView("~/Views/User/Upsert.cshtml", updateUserVm);

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
        }

    }
}
