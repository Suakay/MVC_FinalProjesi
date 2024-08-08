using MVC_FinalProje.Domain.Utilities.Interfaces;
using MVCFinalProjeBusiness.DTOs.AuthorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFinalProjeBusiness.Services.AuthorServices
{
    public interface IAuthorService
    {
        Task<IResult>AddAsync(AuthorCreateDTO authorCreateDTO);
        Task<IDataResult<List<AuthorListDTO>>> GetAllAsync();
        Task<IResult> DeletedAsync(Guid id);
        Task<IDataResult<AuthorDTO>> GetByIdAsync(Guid id);
        Task<IResult> UpdateAsync(AuthorUpdateDTO authorUpdateDTO);
    }
}
