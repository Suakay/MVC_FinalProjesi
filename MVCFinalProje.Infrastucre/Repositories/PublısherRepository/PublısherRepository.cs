using Microsoft.EntityFrameworkCore;
using MVC_FinalProje.Domain.Entities;
using MVCFinalProje.Infrastucre.AppContext;
using MVCFinalProje.Infrastucre.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFinalProje.Infrastrucre.Repositories.PublısherRepository
{
    public class PublısherRepository : EFBaseRepository<Publisher>, IPublısherRepository
    {
        public PublısherRepository(AppDbContex contex) : base(contex) { }

       

      
    }
}
