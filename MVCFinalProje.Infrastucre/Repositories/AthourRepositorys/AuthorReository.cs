using MVC_FinalProje.Domain.Entities;
using MVCFinalProje.Infrastructure.Repositories.AthourRepository;
using MVCFinalProje.Infrastucre.AppContext;
using MVCFinalProje.Infrastucre.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFinalProje.Infrastucre.Repositories.AthourRepositorys
{
    public class AuthorReository:EFBaseRepository<Author>,IAuthorRepository
    {
        public AuthorReository(AppDbContex context):base(context) { }

        public Task AddAsync(object newAuthor)
        {
            throw new NotImplementedException();
        }

        

        public Task<bool> AnyAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(object deletingAuthor)
        {
            throw new NotImplementedException();
        }

        public Task GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

       
    }
}
