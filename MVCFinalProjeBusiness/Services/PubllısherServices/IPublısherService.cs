using MVC_FinalProje.Domain.Utilities.Interfaces;
using MVCFinalProjeBusiness.DTOs.AuthorDTOs;
using MVCFinalProjeBusiness.DTOs.PublısherDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFinalProjeBusiness.Services.PubllısherServices
{
    public interface IPublısherService
    {
        Task<IResult> AddAsync(PublısherCreateDTO publısherCreateDTO);
        Task<IDataResult<List<PublısherListDTO>>> GetAllAsync();
        /// <summary>
        /// Bumetot aldığı parametre sonucu yayın evini siler.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Başarılı/Başarısız</returns>
        Task<IResult> DeletedAsync(Guid id);
        Task<IDataResult<PublisherDTO>> GetByIdAsync(Guid id);
        Task<IResult> UpdateAsync(PublisherUpdateDTO publisherUpdateDTO);
    }
}
