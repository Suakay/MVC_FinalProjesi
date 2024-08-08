using MVC_FinalProje.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_FinalProje.Domain.Entities
{
    public class Book:AuditableEntity
    {
        public string Name {  get; set; }   
        public DateTime PublishDate { get; set; }   
        //Nav Prop
        public virtual Author Author { get; set; }
        public Guid AuthorId { get; set; }
        [Column (TypeName="varchar(255)")]
        public string  Publisher { get; set; }
        public Guid PublisherId { get; set; }   
    }
}
