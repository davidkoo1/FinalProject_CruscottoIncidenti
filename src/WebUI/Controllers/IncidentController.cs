using Application.IncidentCQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class IncidentController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            //var incidentList = await Mediator.Send(new GetAllInicdents());
            return View(/*incidentList*/);
        }

        [HttpPost]
        public async Task<ActionResult> LoadDatatable()
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
                var customerData = await Mediator.Send(new GetAllInicdents());

                // Sorting
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    // Example sorting for one column (modify as needed)
                    switch (sortColumn)
                    {
                        case "CreatedBy":
                            customerData = sortColumnDirection == "asc" ? customerData.OrderBy(m => m.OpenDate) : customerData.OrderByDescending(m => m.OpenDate);
                            break;
                        case "Created":
                            customerData = sortColumnDirection == "asc" ? customerData.OrderBy(m => m.CloseDate) : customerData.OrderByDescending(m => m.CloseDate);
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
    }
}
