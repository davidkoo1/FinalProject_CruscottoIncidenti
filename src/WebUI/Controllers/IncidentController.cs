using Application.Common.Interfaces;
using Application.DTO;
using Application.IncidentCQRS.Commands;
using Application.IncidentCQRS.Queries;
using Application.TableParameters;
using Domain.Entities;
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
        public async Task<ActionResult> LoadDatatable(DataTablesParameters parameters = null!)
        {
            try
            {

                var result = await Mediator.Send(new GetAllInicdents(parameters));
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

        private async Task InitialViewBags(UpsertIncidentDto incidentDto)
        {
            var origins = await Mediator.Send(new GetAllOrigins { });
            var selectListOriginsVm = origins.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = incidentDto.Id != 0 ? x.Id == incidentDto.OriginId : false
            });
            ViewBag.Origins = selectListOriginsVm;
            if (incidentDto.Id != 0)
            {
                var ambits = await Mediator.Send(new GetAllAmbits { OriginId = incidentDto.OriginId });
                var selectListAmbitsVm = ambits.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name,
                    Selected = incidentDto.Id != 0 ? x.Id == incidentDto.AmbitId : false
                });
                ViewBag.Ambits = selectListAmbitsVm;

                var types = await Mediator.Send(new GetAllIncidentTypes { AmbitId = incidentDto.AmbitId });
                var selectListTypesVm = types.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name,
                    Selected = incidentDto.Id != 0 ? x.Id == incidentDto.IncidentTypeId : false
                });
                ViewBag.IncidentTypes = selectListTypesVm;
            }
            var scenaries = await Mediator.Send(new GetAllScenaries { });
            var selectListScenariesVm = scenaries.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = incidentDto.Id != 0 ? x.Id == incidentDto.ScenaryId : false
            });
            ViewBag.Scenaries = selectListScenariesVm;

            var threats = await Mediator.Send(new GetAllThreats { });
            var selectListThreatsVm = threats.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = incidentDto.Id != 0 ? x.Id == incidentDto.ThreatId : false
            });
            ViewBag.Threats = selectListThreatsVm;

        }


        public async Task<IActionResult> Upsert(int id)
        {
            var updateIncidentVm = await Mediator.Send(new GetIncidentForUpsert { Id = id });
            await InitialViewBags(updateIncidentVm);

            return View("~/Views/Incident/Upsert.cshtml", updateIncidentVm);

        }

        [HttpPost]
        public async Task<IActionResult> Upsert(UpsertIncidentDto incidentUpsert)
        {
            if (ModelState.IsValid)
            {
                var result = await Mediator.Send(new UpsertIncident { UpsertIncidentDto = incidentUpsert });
                if (result)
                {

                    //return Json(new { success = true });
                    return RedirectToAction("Index", "Incident");
                }
                else
                {
                    TempData["Error"] = "But current incident exist";
                    await InitialViewBags(incidentUpsert);
                    return View(incidentUpsert);
                }

            }
            TempData["Error"] = "Give correct data!";
            await InitialViewBags(incidentUpsert);
            return View(incidentUpsert);
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
                return Json(new { success = false });
            }
        }

        [HttpGet]
        public async Task<FileResult> Export()
        {
            var csvFile = await Mediator.Send(new ExportAllIncidentsToCSV());
            return File(csvFile, "text/csv", $"Incidents_{DateTime.UtcNow:yyyyMMdd}.csv");
        }
    }
}
