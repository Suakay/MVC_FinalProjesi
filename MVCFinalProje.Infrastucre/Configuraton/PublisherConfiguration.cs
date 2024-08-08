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
    public class PublisherConfiguration : AuditableEntityConfiguraion<Publisher>
    {
        public override void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(128);
            builder.Property(p=>p.Adress).IsRequired().HasMaxLength(128);       
            base.Configure(builder);
        }
    }
   
}
