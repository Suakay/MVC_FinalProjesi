using MVC_FinalProje.Domain.Utilities.Interfaces;
using MVCFinalProjeBusiness.DTOs.AuthorDTOs;
using MVCFinalProjeBusiness.DTOs.BookDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFinalProjeBusiness.Services.BookServices
{
    public interface IBookService
    {
        Task<IResult> AddAsync(BookCreateDTO bookCreateDTO);
        Task<IDataResult<List<BookListDTO>>> GetAllAsync();
        Task<IResult> DeletedAsync(Guid id);
        Task<IDataResult<BookDTO>> GetByIdAsync(Guid id);
        Task<IResult> UpdateAsync(BookUpdateDTO bookUpdateDTO);
    }
}
