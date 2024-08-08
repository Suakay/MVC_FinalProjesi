using Microsoft.AspNetCore.Mvc;
using MVCFinalProjeBusiness.DTOs.AuthorDTOs;
using MVCFinalProjeBusiness.Services.AuthorServices;
using Mapster;
using MVC_Proje.UI.Areas.Admin.Models.AuthorVMs;
using MVC_Proje.UI.Models.AuthorVMs;
using AdminAuthorListVM = MVC_Proje.UI.Areas.Admin.Models.AuthorVMs.AdminAuthorListVM;

namespace MVC_Proje.UI.Areas.Admin.Controllers
{
    
    public class AuthorController : AdminBaseController
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _authorService.GetAllAsync();
            if (!result.IsSuccess)
            {
                ErrorNotyf(result.Message);
                return View(result.Data.Adapt<List<AdminAuthorListVM>>());
            }
            await Console.Out.WriteLineAsync(result.Message);
            return View(result.Data.Adapt<List<AdminAuthorListVM>>());
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UI.Models.AuthorVMs.AdminAuthorCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var authorCreateDto = model.Adapt<AuthorCreateDTO>();
            var result = await _authorService.AddAsync(authorCreateDto);
            if (!result.IsSuccess)
            {
                ErrorNotyf(result.Message);
                return View(model);
            }
            await Console.Out.WriteLineAsync(result.Message);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _authorService.DeletedAsync(id);
            if (!result.IsSuccess)
            {
                ErrorNotyf(result.Message);
                return RedirectToAction("Index");
            }
            await Console.Out.WriteLineAsync(result.Message);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _authorService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                ErrorNotyf(result.Message);
                return RedirectToAction("Index");
            }
            return View(result.Adapt<AdminAuthorUpdateVM>());
        }
        [HttpPost]
        public async Task<IActionResult> Update(AdminAuthorUpdateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _authorService.UpdateAsync(model.Adapt<AuthorUpdateDTO>());
            if (!result.IsSuccess)
            {
                ErrorNotyf(result.Message);
                return View(model);
            }
            SuccessNotyf(result.Message);
            return RedirectToAction("Index");

        }
    }
}

