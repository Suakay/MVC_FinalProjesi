using Mapster;
using MVC_FinalProje.Domain.Entities;
using MVC_FinalProje.Domain.Utilities.Concretes;
using MVC_FinalProje.Domain.Utilities.Interfaces;
using MVCFinalProje.Infrastrucre.Repositories.BookRepository;
using MVCFinalProjeBusiness.DTOs.BookDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace MVCFinalProjeBusiness.Services.BookServices
{
    public class BookService : IBookService
    {
        private readonly IBookRepository  _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IResult> AddAsync(BookCreateDTO bookCreateDTO)
        {
            if(await _bookRepository.AnyAsync(x => x.Name.ToLower() == bookCreateDTO.Name.ToLower()))
            {
                return new ErrorResult("Kitap sistemde kayıtlı");
            }
            try
            {
                var newBook = bookCreateDTO.Adapt<Book>();
                await _bookRepository.AddAsync(newBook);
                await _bookRepository.SaveChangeAsync();
                return new SuccessResult("Kitap ekleme işlemi başarılı");


            }
            catch(Exception ex)
            {
                return new ErrorResult("Hata"+ ex.Message);
            }
        }

        public async Task<IResult> DeletedAsync(Guid id)
        {
            var deletingBook=await _bookRepository.GetByIdAsync(id);    
            if(deletingBook == null)
            {
                return new ErrorResult("Kitap sistemde bulunamadı");
            }
            try
            {
                await _bookRepository.DeleteAsync(deletingBook);
                await _bookRepository.SaveChangeAsync();
                return new SuccessResult("Kitap silme işlemi başarılı");
            }
            catch(Exception ex)
            {
                return new ErrorResult("Hata:"+ex.Message);
            }
        }

        public async Task<IDataResult<List<BookListDTO>>> GetAllAsync()
        {
            var books=await _bookRepository.GetAllAsync();
            var bookListDTO=books.Adapt<List<BookListDTO>>();   
            if(bookListDTO.Count()<=0)
            {
                return new ErrorDataResult<List<BookListDTO>>(bookListDTO, "Listelenecek Kitap bulunamadı");
            }
            return new SuccessDataResult<List<BookListDTO>>(bookListDTO, "Kitap listeleme başarılı");
        }

        public async Task<IDataResult<BookDTO>> GetByIdAsync(Guid id)
        {
           var book=await _bookRepository.GetByIdAsync(id);
            if(book is null)
            {
                return new ErrorDataResult<BookDTO>(book .Adapt<BookDTO>(),"Gösterilecek Kitap Bulunamadı");
            }
            return new SuccessDataResult<BookDTO>(book.Adapt<BookDTO>(), "Gösterilecek Kitap Bulunamadı");
        }

        public async Task<IResult> UpdateAsync(BookUpdateDTO bookUpdateDTO)
        {
            var updatingBook=await _bookRepository.GetByIdAsync(bookUpdateDTO.Id);
            if(updatingBook is null)
            {
                return new ErrorResult("GÜNCELLENECEK KİTAP BULUNAMADI");
            }
            try
            {
                var updatedBook = bookUpdateDTO.Adapt(updatingBook);
                await _bookRepository.UpdateAsync(updatedBook);
                await _bookRepository.SaveChangeAsync();
                return new SuccessResult("kİTAP GÜNCELLEME BAŞARILI");
            }
            catch(Exception ex)
            {
                return new ErrorResult("Hata:" + ex.Message);
            }
         

        }
    }
}
