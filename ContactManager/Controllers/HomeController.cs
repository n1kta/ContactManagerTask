using System;
using ContactManager.Application.Contracts;
using ContactManager.Helpers;
using ContactManager.MSSQL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly IManagerService _managerService;

        public HomeController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        public IActionResult Index()
        {
            var result = _managerService.GetManagers();
            return View(result);
        }

        [HttpPost]
        public IActionResult ReadFile(IFormFile uploadedFile)
        {
            if (uploadedFile == null) return Redirect("/Home/Index");

            var managers = CSVImporter.Decoder(uploadedFile);

            try
            {
                _managerService.CreateManager(managers);
                return Redirect("/Home/Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Home/DeleteManager/{managerId}")]
        public IActionResult DeleteManager(int managerId)
        {
            try
            {
                _managerService.DeleteManager(managerId);
                return Redirect("/Home/Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Home/UpdateManager/{managerId}")]
        public IActionResult UpdateManager(int managerId)
        {
            var manager = _managerService.GetManagerById(managerId);
            return View("UpdateManager", manager);
        }

        [HttpPost]
        public IActionResult UpdateManager(Manager manager)
        {
            try
            {
                _managerService.UpdateManager(manager);
                return Redirect("/Home/Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
