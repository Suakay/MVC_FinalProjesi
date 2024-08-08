using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_FinalProje.Domain.Core.BaseEntityConfigurations;
using MVC_FinalProje.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFinalProje.Infrastrucre.Configuraton
{
    public class BookConfiguration:AuditableEntityConfiguraion<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(b => b.Name).IsRequired().HasMaxLength(128);
            builder.Property(b => b.Publisher).IsRequired();
            base.Configure(builder);
        }
    }
}
