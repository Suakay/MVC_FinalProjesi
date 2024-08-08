using Microsoft.EntityFrameworkCore;
using MVC_FinalProje.Domain.Entities;
using MVCFinalProje.Infrastucre.DataAccess;
using MVCFinalProje.Infrastucre.Repositories.AthourRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCFinalProje.Infrastructure.Repositories.AthourRepository
{
    public interface IAuthorRepository : IAsyncRepository, IAsyncFindable<Author>, IAsyncInsertable<Author>,IAsyncQueryableRepository<Author>,IAsyncDeletableRepository<Author>,IAsyncUpdatebleRepository<Author>   
    {
        Task AddAsync(object newAuthor);
        
        
        Task<bool> AnyAsync(Expression<Func<Author, bool>> predicate); // Koşul ifadesi alıyor
                                                                       // Doğru:


        
        Task DeleteAsync(object deletingAuthor);
    }
}
