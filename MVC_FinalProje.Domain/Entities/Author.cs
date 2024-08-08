using MVC_FinalProje.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_FinalProje.Domain.Entities
{
    public class Author:AuditableEntity
    {
        public Author()
        {
            Books= new HashSet<Book>();    
        }
        public string Name {  get; set; }   
        public DateTime DateOfBirth { get; set; }   
        public virtual IEnumerable<Book> Books { get; set; }

    }
}
