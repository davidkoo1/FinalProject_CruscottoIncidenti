﻿using Application.DTO;
using Application.IncidentCQRS.Commands;
using Application.IncidentCQRS.Queries;
using Application.RoleCQRS.Queries;
using Application.UserCQRS.Commands;
using Application.UserCQRS.Queries;
using Domain.Entities.HelpDesk;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

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
                var data = customerData
                    .Skip(skip)
                    .Take(pageSize)
                    .Select(d => new
                    {
                        id = d.Id,
                        requestNr = d.RequestNr,
                        subsystem = d.Subsystem,
                        openDate = d.OpenDate.ToString("yyyy-MM-dd"), // Форматируем дату без времени
                        closeDate = d.CloseDate.HasValue ? d.CloseDate.Value.ToString("yyyy-MM-dd") : "", // Форматируем дату без времени, если она есть
                        type = d.Type,
                        urgency = d.Urgency
                    })
                    .ToList();


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

            }
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
            string[] columnNames = new string[] { "RequestNr", "Subsystem", "OpenDate", "CloseDate", "Type", "ApplicationType", "Urgency", "SubCause",
            "ProblemSummary", "ProblemDescription", "Solution", "IncidentType", "Ambit", "Origin", "ThirdParty", "Scenary", "Threat"};

            var incidents = await Mediator.Send(new GetAllInicdents());
            string csv = string.Empty;

            foreach (string columnName in columnNames)
            {
                csv += columnName + ',';
            }

            csv += "\r\n";

            foreach (var incident in incidents)
            {
                csv += incident.RequestNr.ToString().Replace(",", ";") + ",";
                csv += incident.Subsystem.ToString().Replace(",", ";") + ",";
                csv += incident.OpenDate.ToString().Replace(",", ";") + ",";
                csv += incident.CloseDate.ToString().Replace(",", ";") + ",";
                csv += incident.Type.ToString().Replace(",", ";") + ",";
                //csv += incident.ApplicationType.ToString().Replace(",", ";") + ",";
                csv += incident.Urgency.ToString().Replace(",", ";") + ",";
                //csv += incident.SubCause.ToString().Replace(",", ";") + ",";
                // csv += incident.ProblemSummary.Replace(",", ";") + ",";
                //csv += incident.ProblemDescription.ToString().Replace(",", ";") + ",";
                // csv += incident.Solution.ToString().Replace(",", ";") + ",";
                //csv += incident.IncidentType.ToString().Replace(",", ";") + ",";
                //csv += incident.Ambit.ToString().Replace(",", ";") + ",";
                //csv += incident.Origin.ToString().Replace(",", ";") + ",";
                //csv += incident.ThirdParty.ToString().Replace(",", ";") + ",";
                //csv += incident.Scenary.ToString().Replace(",", ";") + ",";
                //csv += incident.Threat.ToString().Replace(",", ";") + ",";
                csv += "\r\n";
            }

            byte[] bytes = Encoding.ASCII.GetBytes(csv);
            return File(bytes, "text/csv", "Inci.csv");
        }
    }
}
