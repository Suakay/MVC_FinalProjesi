using Mapster;
using MVC_FinalProje.Domain.Entities;
using MVC_FinalProje.Domain.Utilities.Concretes;
using MVC_FinalProje.Domain.Utilities.Interfaces;
using MVCFinalProje.Infrastrucre.Repositories.PublısherRepository;
using MVCFinalProjeBusiness.DTOs.PublısherDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFinalProjeBusiness.Services.PubllısherServices
{
    public class PublisherService : IPublısherService
    {
        private readonly IPublısherRepository _publisherRepository;
        public PublisherService(IPublısherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }   

        public async Task<IResult> AddAsync(PublısherCreateDTO publısherCreateDTO)
        {
           if(await _publisherRepository.AnyAsync(x => x.Name.ToLower() == publısherCreateDTO.Name.ToLower()))
            {
                return new ErrorResult("Yayınevi sistemde kayıtlı");
            }
            try
            {
                var newPublisher = publısherCreateDTO.Adapt<Publisher>();
                await _publisherRepository.AddAsync(newPublisher);
                await _publisherRepository.SaveChangeAsync();
                return new SuccessResult("Yayınevi ekleme başarılı ");
            }
            catch (Exception ex)
            {
                return new ErrorResult("Hatalı giriş yaptınız");
            }
           
        }

        public async Task<IResult> DeletedAsync(Guid id)
        {
            var deletingPublisher=await _publisherRepository.GetByIdAsync(id);  
            if (deletingPublisher != null)
            {
                return new ErrorResult("Silinecek yayınevi bulunamadı");
            }
            try
            {
                await _publisherRepository.DeleteAsync(deletingPublisher);
                await _publisherRepository.SaveChangeAsync();
                return new SuccessResult("Yayınevi silme başarılı");
            }
            catch(Exception ex) 
            {
                return new ErrorResult("Hata:"+ ex.Message);
            }
        }

        public async Task<IDataResult<List<PublısherListDTO>>> GetAllAsync()
        {
          var publishers= await _publisherRepository.GetAllAsync();
            var publisherListDTO = publishers.Adapt<List<PublısherListDTO>>();
            if(publishers.Count()<0)
            {
                return new ErrorDataResult<List<PublısherListDTO>>(publisherListDTO, "Listelenecek Yayınevi Bulunamadı");
            }
            return new SuccessDataResult<List<PublısherListDTO>>(publisherListDTO, "Yayınevi listeleme başarılı");

        }

        public async Task<IDataResult<PublisherDTO>> GetByIdAsync(Guid id)
        {
            var publisher=await _publisherRepository.GetByIdAsync(id);
            if(publisher == null)
            {
                return new ErrorDataResult<PublisherDTO>(publisher.Adapt<PublisherDTO>(), "Yayınevi bulunamadı");
            }
            return new SuccessDataResult<PublisherDTO>(publisher.Adapt<PublisherDTO>(),"Yayınevi, bulundu");
        }

        public async Task<IResult> UpdateAsync(PublisherUpdateDTO publisherUpdateDTO)
        {
            var updatingPublisher=await _publisherRepository.GetByIdAsync(publisherUpdateDTO.Id);
            if(updatingPublisher is null)
            {
                return new ErrorResult("Güncellenecek yayınevi bulunamadı");
            }
            try
            {
                var updatedPublisher = publisherUpdateDTO.Adapt(updatingPublisher);
                await _publisherRepository.UpdateAsync(updatedPublisher);
                await _publisherRepository.SaveChangeAsync();
                return new SuccessResult("Yayıevi başarıyla güncellendi");
            }
            catch (Exception ex)
            {
                return new ErrorResult("Hata:"+ex.Message);
            }
            

        }
    }
}
