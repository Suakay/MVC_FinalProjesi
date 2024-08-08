using MVC_FinalProje.Domain.Entities;
using MVCFinalProje.Infrastucre.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCFinalProje.Infrastrucre.Repositories.PublısherRepository
{
    public interface IPublısherRepository: IAsyncRepository, IAsyncFindable<Publisher>, IAsyncInsertable<Publisher>, IAsyncQueryableRepository<Publisher>, IAsyncDeletableRepository<Publisher>, IAsyncUpdatebleRepository<Publisher>,IAsyncOrderableRepository<Publisher>   
        
    {
        
        
    }
    
}
