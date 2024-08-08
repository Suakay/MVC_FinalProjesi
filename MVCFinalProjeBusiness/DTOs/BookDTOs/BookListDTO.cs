using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFinalProjeBusiness.DTOs.BookDTOs
{
    public class BookListDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        

        public string AuthorName{ get; set; }

        public Guid PublisherName { get; set; }
    }
}
