using MVC_FinalProje.Domain.Entities;
using MVCFinalProje.Infrastucre.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFinalProje.Infrastrucre.Repositories.BookRepository
{
    public interface IBookRepository: IAsyncRepository, IAsyncFindable<Book>, IAsyncInsertable<Book>, IAsyncQueryableRepository<Book>, IAsyncDeletableRepository<Book>, IAsyncUpdatebleRepository<Book>, IAsyncOrderableRepository<Book>
    {
    }
}
