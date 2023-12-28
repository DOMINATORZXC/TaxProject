using Domain.SashaProject.Entity;
using Domain.SashaProject.Requests;
using Domain.SashaProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SashaProject.Models;
using Service.SashaProject.IService;
using System.Diagnostics;

namespace SashaProject.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        public IActionResult Client()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClient()
        {
            var response = await _clientService.GetAllClients();
            if (response.StatusCode == Domain.SashaProject.Enum.StatusCode.OK)
            {
                return View(response.Data.ToList());
            }
            else if (response.StatusCode == Domain.SashaProject.Enum.StatusCode.CarNotFound)
            {
                return View();
            }
            return RedirectToAction("Error");

        }
            [HttpGet]
            public async Task<IActionResult> GetClient(int id)
            {
                if (id == 0)
                {
                    return View();
                }
                var response = await _clientService.Get(id);
                if (response.StatusCode == Domain.SashaProject.Enum.StatusCode.OK)
                {
                    return View(response.Data);
                }
                return RedirectToAction("Error");
            }
        
            public async Task<IActionResult> DeleteClient(int id)
            {
                var response = await _clientService.DeleteClient(id);

                return RedirectToAction("GetAllClient");

            }
            [HttpGet]
            public async Task<IActionResult> SaveClient(int id)
            {
                var response = await _clientService.Get(id);
                return View(response.Data);
            }
            [HttpPost]
            public async Task<IActionResult> CreateClient(ClientCreateRequest model)
            {
                 await _clientService.CreateClient(model);
        
                 return RedirectToAction("GetAllClient"); 
            }
            [HttpPost]
            public async Task<IActionResult> EditClient(ClientViewModel model)
            {
                await _clientService.Edit(model.ClientId, model);
                return RedirectToAction("GetAllClient");
            }
            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
    }
}
