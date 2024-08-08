using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_FinalProje.Domain.Utilities.Concretes;
using MVC_Proje.UI.Areas.Admin.Models.BookVMs;
using MVCFinalProjeBusiness.DTOs.BookDTOs;
using MVCFinalProjeBusiness.Services.AuthorServices;
using MVCFinalProjeBusiness.Services.BookServices;
using MVCFinalProjeBusiness.Services.PubllısherServices;

namespace MVC_Proje.UI.Areas.Admin.Controllers
{
    public class BookController : AdminBaseController
    {

        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IPublısherService _publisherService;


        public BookController(IBookService bookService, IAuthorService authorService, IPublısherService publisherService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _publisherService = publisherService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _bookService.GetAllAsync();
            var adminBookListVM = result.Data.Adapt<List<AdminBookListVM>>();

            if (!result.IsSuccess)
            {
                ErrorNotyf(result.Message);
                return View(adminBookListVM);
            }
            SuccessNotyf(result.Message);
            return View(adminBookListVM);
        }
        private async Task<SelectList> GetAuthors(Guid? authorId = null)
        {
            var authors = (await _authorService.GetAllAsync()).Data;
            return new SelectList(authors.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = x.Id == (authorId != null ? authorId.Value : authorId)
            }).OrderBy(x => x.Text), "Value", "Text");
        }
        private async Task<SelectList> GetPublishers(Guid? publisherId = null)
        {
            var publishers = (await _publisherService.GetAllAsync()).Data;
            return new SelectList(publishers.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = x.Id == (publisherId != null ? publisherId.Value : publisherId)
            }).OrderBy(x => x.Text), "Value", "Text");
        }
        public async Task<IActionResult> Create()
        {
            AdminBookCreateVM adminBookCreateVM = new AdminBookCreateVM()
            {
                Authors = await GetAuthors(),
                Publishers = await GetPublishers(),
            };

            return View(adminBookCreateVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdminBookCreateVM model)
        {

            var bookCreateDTO = model.Adapt<BookCreateDTO>();
            var result = await _bookService.AddAsync(bookCreateDTO);
            if (!result.IsSuccess)
            {
                ErrorNotyf(result.Message);
                return View(model);
            }
            SuccessNotyf(result.Message);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(Guid Id)
        {
            var result = await _bookService.DeletedAsync(Id);
            if (!result.IsSuccess)
            {
                ErrorNotyf(result.Message);
                return RedirectToAction("Index");
            }

            SuccessNotyf(result.Message);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Edit(Guid Id)
        {
            var result = (await _bookService.GetByIdAsync(Id));

            if (!result.IsSuccess)
            {
                ErrorNotyf(result.Message);
                return RedirectToAction("Book", "Index");
            }
            SuccessNotyf(result.Message);

            var vm = result.Data.Adapt<AdminBookUpdateVM>();

            vm.Authors = await GetAuthors(Id);
            vm.Publishers = await GetPublishers(Id);

            return View(vm);


        }
        [HttpPost]
        public async Task<IActionResult> Edit(AdminBookUpdateVM vm)
        {
            //vm.Authors = await GetAuthors(vm.AuthorId);
            //vm.Publishers = await GetPublishers(vm.PublisherId);

            //if (!ModelState.IsValid) 
            //{
            //    //var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            //    //foreach (var error in errors)
            //    //{
            //    //    ErrorNotyf(error);
            //    //}

            //    return View(vm);    
            //}

            var bookUpdateDTO = vm.Adapt<BookUpdateDTO>();
            var result = await _bookService.UpdateAsync(bookUpdateDTO);
            if (!result.IsSuccess)
            {
                ErrorNotyf(result.Message);
                return View(vm);
            }
            SuccessNotyf(result.Message);
            return RedirectToAction("Index");
        }
    }
}
