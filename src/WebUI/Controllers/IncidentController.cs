using Application.DTO;
using Application.IncidentCQRS.Commands;
using Application.IncidentCQRS.Queries;
using Application.RoleCQRS.Queries;
using Application.UserCQRS.Commands;
using Application.UserCQRS.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Controllers
{
    public class IncidentController : BaseController
    {
        public async Task<IActionResult> Index()
        {

            return View("~/Views/Incident/Index.cshtml");
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


        public async Task<IActionResult> Details(int id)
        {
            var IncidentDetail = await Mediator.Send(new GetIncidentById { Id = id });

            if (IncidentDetail == null)
            {
                return NotFound();
            }
            return PartialView("~/Views/Incident/Details.cshtml", IncidentDetail);
        }

        [HttpPost]
        public async Task<IActionResult> GetAmbits(int originId)
        {

            var ambits = await Mediator.Send(new GetAllAmbits { OriginId = originId });
            var selectListAmbitsVm = ambits.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = false
            });
            return Json(selectListAmbitsVm);
            
        }

        [HttpPost]
        public async Task<IActionResult> GetIncidentTypes(int ambitId)
        {
            var types = await Mediator.Send(new GetAllIncidentTypes { AmbitId = ambitId });
            var selectListTypesVm = types.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = false
            });
            return Json(selectListTypesVm);
        }


        public async Task<IActionResult> Upsert()
        {
            var origins = await Mediator.Send(new GetAllOrigins { });
            var selectListOriginsVm = origins.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = false
            });
            ViewBag.Origins = selectListOriginsVm;

            var scenaries = await Mediator.Send(new GetAllScenaries { });
            var selectListScenariesVm = scenaries.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = false
            });
            ViewBag.Scenaries = selectListScenariesVm;

            var threats = await Mediator.Send(new GetAllThreats { });
            var selectListThreatsVm = threats.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = false
            });
            ViewBag.Threats = selectListThreatsVm;

            return PartialView("~/Views/Incident/Upsert.cshtml", new UpsertIncidentDto());

        }

        [HttpPost]
        public async Task<IActionResult> Upsert(UpsertIncidentDto incidentUpsert)
        {
            //if (ModelState.IsValid)
            //{
                var result = await Mediator.Send(new UpsertIncident { UpsertIncidentDto = incidentUpsert });
                if (result)
                {
                    // return Json(new { success = true/*, redirectUrl = Url.Action(nameof(Index))*/ });
                    return Json(new { success = true });
                }

            //}
            return PartialView("~/Views/Incident/Upsert.cshtml", incidentUpsert);
        }


        public async Task<IActionResult> Delete(int id)
        {

            var incident = await Mediator.Send(new GetIncidentById { Id = id });
            if (incident == null)
            {
                return NotFound();
            }

            return PartialView("~/Views/Incident/Delete.cshtml", id);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await Mediator.Send(new DeleteIncident { Id = id });
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
