using Application.DTO;
using Application.IncidentCQRS.Commands;
using Application.IncidentCQRS.Queries;
using Application.TableParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;

namespace WebUI.Controllers
{
    //[Authorize(Roles = "Operator")]
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
                Log.Error("Error in Incident.LoadDatatable", ex.Message);
                //return PartialView("~/Views/_Shared/Error.cshtml", ex);
                return View("~/Views/Shared/_NotFound.cshtml");
            }
        }


        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var IncidentDetail = await Mediator.Send(new GetIncidentById { Id = id });

                //if (IncidentDetail == null)
                //{
                //    return NotFound();
                //}
                return PartialView("~/Views/Incident/Details.cshtml", IncidentDetail);
            }
            catch (Exception ex)
            {
                Log.Error($"Error in Incident.Details with ID {id}", ex); 
                return View("~/Views/Shared/_NotFound.cshtml");
            }
            
        }

        [HttpPost]
        [Authorize(Roles = "Operator,Admin")]
        public async Task<IActionResult> GetAmbits(int originId)
        {
            try
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
            catch (Exception ex)
            {
                Log.Error($"Error in Incident.GetAmbits with Origin ID {originId}", ex);
                return View("~/Views/Shared/_NotFound.cshtml");
            }


        }

        [HttpPost]
        [Authorize(Roles = "Operator,Admin")]
        public async Task<IActionResult> GetIncidentTypes(int ambitId)
        {
            try
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
            catch (Exception ex)
            {
                Log.Error($"Error in Incident.GetIncidentTypes with Ambit ID {ambitId}", ex);
                return View("~/Views/Shared/_NotFound.cshtml");
            }
        }

        private async Task InitialViewBags(UpsertIncidentDto incidentDto)
        {
            try
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
            catch (Exception ex)
            {
                Log.Information("UpsertIncidentDto => {@incidentDto}", incidentDto);
                Log.Error("Incident.InitialViewBags", ex);
                throw;
            }
            

        }

        [Authorize(Roles = "Operator,Admin")]
        public async Task<IActionResult> Upsert(int id)
        {
            try
            {
                var updateIncidentVm = await Mediator.Send(new GetIncidentForUpsert { Id = id });
                await InitialViewBags(updateIncidentVm);
                return View("~/Views/Incident/Upsert.cshtml", updateIncidentVm);
            }
            catch (Exception ex)
            {
                Log.Error($"Error in Incident.Upsert with ID {id}", ex);
                //TempData["Error"] = "Error processing your request";
                return View("~/Views/Shared/_NotFound.cshtml");
            }


        }

        [HttpPost]
        [Authorize(Roles = "Operator,Admin")]
        public async Task<IActionResult> Upsert(UpsertIncidentDto incidentUpsert)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    var result = await Mediator.Send(new UpsertIncident { UpsertIncidentDto = incidentUpsert });
                    if (result)
                    {
                        return RedirectToAction("Index", "Incident");
                    }
                    else
                    {
                        TempData["Error"] = "But current incident exist";
                    }
                }
                else
                {
                    TempData["Error"] = "Give correct data!";
                }
                await InitialViewBags(incidentUpsert);
                return View(incidentUpsert);
            }
            catch (Exception ex)
            {
                Log.Error("Error during incident upsert operation", ex);
                return View("~/Views/Shared/_NotFound.cshtml");
            }
        }

        [Authorize(Roles = "Operator,Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var incident = await Mediator.Send(new GetIncidentById { Id = id });
                //if (incident == null)
                //{
                //    return NotFound();
                //}

                return PartialView("~/Views/Incident/Delete.cshtml", id);
            }
            catch (Exception ex)
            {
                Log.Error($"Error in Incident.Delete with ID {id}", ex);
                return View("~/Views/Shared/_NotFound.cshtml");
            }

        }


        [HttpPost]
        [Authorize(Roles = "Operator,Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
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
            catch (Exception ex)
            {
                Log.Error($"Error in Incident.DeleteConfirmed with ID {id}", ex);
                return View("~/Views/Shared/_NotFound.cshtml");
            }

        }

        public IActionResult CSV() =>  PartialView("~/Views/Incident/_CSV.cshtml");
        

        [HttpGet]
        public async Task<FileResult> Export()
        {
            try
            {
                var csvFile = await Mediator.Send(new ExportAllIncidentsToCSV());
                return File(csvFile, "text/csv", $"Incidents_{DateTime.UtcNow:yyyyMMdd}.csv");
            }
            catch (Exception ex)
            {
                Log.Error("Error during CSV export", ex);
                throw;
            }
        }

        [HttpPost]
        [Authorize(Roles = "Operator,Admin")]
        public async Task<IActionResult> Import(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return Json(new { StatusCode = 500, Message = "No file uploaded." });
                }

                var command = new ImportIncidentsFromCSV { File = file };
                var result = await Mediator.Send(command);
                if (result)
                {
                    return Json(new { StatusCode = 200 });
                }
                return Json(new { StatusCode = 500, Message = "Something Errors!" });
            }
            catch (Exception ex)
            {
                Log.Error("ImportFile", ex.Message);
                //return Json(new { StatusCode = 500, Message = ex.Message });
                return View("~/Views/Shared/_NotFound.cshtml");
            }



        }


        [Route("/404")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> NotFound() => View("~/Views/Shared/_NotFound.cshtml");
    }
}
