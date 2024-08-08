using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFinalProjeBusiness.DTOs.BookDTOs
{
    public class BookUpdateDTO
    {
        public  Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        //Nav Prop

        public Guid AuthorId { get; set; }

        public Guid PublisherId { get; set; }
    }
}
