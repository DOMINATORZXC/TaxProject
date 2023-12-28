using Domain.SashaProject.Entity;
using Domain.SashaProject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SashaProject.Models;
using Service.SashaProject.IService;
using System.Diagnostics;

namespace SashaProject.Controllers
{
    public class AutoController : Controller
    {
        private readonly IAutoService _autoService;

        public AutoController(IAutoService autoService)
        {
            _autoService = autoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _autoService.GetAll();
            if (response.StatusCode == Domain.SashaProject.Enum.StatusCode.OK)
            {
                return View(response.Data.ToList());
            }
            return RedirectToAction("Error");
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _autoService.Get(id);
            if (response.StatusCode == Domain.SashaProject.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _autoService.DeleteEntity(id);
            if (response.StatusCode == Domain.SashaProject.Enum.StatusCode.OK)
            {
                return RedirectToAction("Get");
            }
            return RedirectToAction("Error");
        }
        [HttpPost]
        public async Task<IActionResult> Save(AutoViewModel Model)
        {
            if (ModelState.IsValid)
            {
                if (Model.AutoId == 0)
                {
                    await _autoService.CreateEntity(Model);
                }
                else
                {
                    await _autoService.Edit(Model.AutoId, Model);
                }

            }
            return RedirectToAction("Get");
        }
        [HttpPost]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
