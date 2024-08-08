using Mapster;
using MVC_FinalProje.Domain.Entities;
using MVC_FinalProje.Domain.Utilities.Concretes;
using MVC_FinalProje.Domain.Utilities.Interfaces;
using MVCFinalProje.Infrastructure.Repositories.AthourRepository;
using MVCFinalProjeBusiness.DTOs.AuthorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFinalProjeBusiness.Services.AuthorServices
{
    public class AuthorService : IAuthorService
    {

        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IResult> AddAsync(AuthorCreateDTO authorCreateDTO)
        {
            if (await _authorRepository.AnyAsync(x => x.Name.ToLower() == authorCreateDTO.Name.ToLower()))
            {
                return new ErrorResult("Yazar Sistemde kayıtlı");
            }

            try
            {
                var newAuthor = authorCreateDTO.Adapt<Author>();
                await _authorRepository.AddAsync(newAuthor);
                await _authorRepository.SaveChangeAsync();
                return new SuccessResult("Yazar Ekleme Başarılı");
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IResult> DeletedAsync(Guid id)
        {
            var deletingAuthor = await _authorRepository.GetByIdAsync(id);
            if (deletingAuthor == null)
            {
                return new ErrorResult("Silinecek yazar bulunamadı");
            }
            try
            {
                await _authorRepository.DeleteAsync(deletingAuthor);
                await _authorRepository.SaveChangeAsync();
                return new SuccessResult("Yazar silme işlemi başarılı");
            }
            catch (Exception ex)
            {
                return new ErrorResult("Hata:" + ex.Message);
            }

        }

        public async Task<IDataResult<List<AuthorListDTO>>> GetAllAsync()
        {
            var authors = await _authorRepository.GetAllAsync();
            var authorListDTOs = authors.Adapt<List<AuthorListDTO>>();
            if (authors.Count() <= 0)
            {
                return new ErrorDataResult<List<AuthorListDTO>>(authorListDTOs, "Listelenecek Yazar Bulunamadı");
            }

            return new SuccessDataResult<List<AuthorListDTO>>(authorListDTOs, "Yazar Listeleme Başarılı");

        }

        public async Task<IDataResult<AuthorDTO>> GetByIdAsync(Guid id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            try
            {
               
                if (author is null)
                {
                    return new ErrorDataResult<AuthorDTO>("Güncellenecek  Yazar Bulunamadı");
                }
                return new SuccessDataResult<AuthorDTO>(author.Adapt<AuthorDTO>(), "Güncellenecek yazar getirldi");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<AuthorDTO>(author.Adapt<AuthorDTO>(), "Hata:"+ex.Message);
            }
         }

        public async Task<IResult> UpdateAsync(AuthorUpdateDTO authorUpdateDTO)
        {

            var updatingAuthor=await _authorRepository.GetByIdAsync(authorUpdateDTO.Id);
            if(updatingAuthor is null)
            {
                return new ErrorResult("Güncelenecek yazar bulunamadı");
            }
            try
            {
               
                var updateAuthor = authorUpdateDTO.Adapt(updatingAuthor);
               await _authorRepository.UpdateAsync(updateAuthor);  
                await _authorRepository.SaveChangeAsync();
                return new SuccessResult("GÜNCELLEME BAŞARILI");
            }
            catch (Exception ex)
            {
              return new ErrorResult("Hata:" +ex.Message);
            }
           
        }
    }



}
