using MVC_FinalProje.Domain.Entities;
using MVCFinalProje.Infrastucre.AppContext;
using MVCFinalProje.Infrastucre.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFinalProje.Infrastrucre.Repositories.BookRepository
{
    public class BookRepository:EFBaseRepository<Book>,IBookRepository
    {
        public BookRepository(AppDbContex context) : base(context)
        {

        }
       
    }
}
