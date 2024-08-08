using MVC_FinalProje.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFinalProjeBusiness.DTOs.BookDTOs
{
    public class BookCreateDTO
    {
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        //Nav Prop
       
        public Guid AuthorId { get; set; }
  
        public Guid PublisherId { get; set; }
    }
}
