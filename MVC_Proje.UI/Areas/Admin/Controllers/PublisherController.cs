using Mapster;
using Microsoft.AspNetCore.Mvc;
using MVC_Proje.UI.Areas.Admin.Models.PublisherVMs;
using MVCFinalProjeBusiness.DTOs.PublısherDTOs;
using MVCFinalProjeBusiness.Services.PubllısherServices;

namespace MVC_Proje.UI.Areas.Admin.Controllers
{
    public class PublisherController : AdminBaseController
    {
        private readonly IPublısherService _publisherService;
        public PublisherController(IPublısherService publısherService)
        {
            _publisherService=publısherService;
        }
        public async Task<IActionResult> Index()
        { var result=await _publisherService.GetAllAsync();
            if(!result.IsSuccess)
            {
                await Console.Out.WriteAsync(result.Message);
                return View(result.Data.Adapt<List<AdminPublisherListVM>>());
            }
            await Console.Out.WriteLineAsync(result.Message);

            return View(result.Data.Adapt < List < AdminPublisherListVM >> ());
        }

        public async Task<IActionResult> Create()
        {
            return View();
            
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdminPublisherCreateVM model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var publisherCreateDTO=model.Adapt<PublısherCreateDTO>();   
            var result=await _publisherService.AddAsync(publisherCreateDTO);
            if(!result.IsSuccess)
            {
                await Console.Out.WriteLineAsync(result.Message);
                return View(model);
            }
            await Console.Out.WriteLineAsync (result.Message);  
            return RedirectToAction("Index");   
        }
        public async Task<IActionResult>Update(Guid id)
        {
            var result=await _publisherService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                await Console.Out.WriteLineAsync(result.Message);
                return RedirectToAction("Index");
            }
            await Console.Out.WriteLineAsync(result.Message);
            return View(result.Data.Adapt<AdminPublisherUpdateVM>());
            
        }
        [HttpPost]
        public async Task<IActionResult>Update(AdminPublisherUpdateVM model)
        {
            if (!ModelState.IsValid)
            {
              return View(model); 
            }
            var result = await _publisherService.UpdateAsync(model.Adapt<PublisherUpdateDTO>());
            if (!result.IsSuccess)
            {
                await Console.Out.WriteLineAsync(result.Message);
                return View(model);
            }
            await Console.Out.WriteLineAsync(result.Message);
            return RedirectToAction("Index");


        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _publisherService.DeletedAsync(id);
            if (!result.IsSuccess)
            {
                await Console.Out.WriteLineAsync(result.Message);
                return RedirectToAction("Index");
            }
            await Console.Out.WriteLineAsync(result.Message);
            return RedirectToAction("Index");   


        }
    }
}
