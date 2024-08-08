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
    public class AdminConfiguration:AuditableEntityConfiguraion<Admin>
    {
        public override void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.Property(a=>a.FirstName).IsRequired().HasMaxLength(90);
            builder.Property(a => a.LastName).IsRequired().HasMaxLength(128);
            builder.Property(a=>a.Email).IsRequired().HasMaxLength(128);
            base.Configure(builder);
        }
    }
}
