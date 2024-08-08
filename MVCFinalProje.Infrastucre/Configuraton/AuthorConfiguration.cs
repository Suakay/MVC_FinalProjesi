using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_FinalProje.Domain.Core.BaseEntityConfigurations;
using MVC_FinalProje.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFinalProje.Infrastucre.Configuraton
{
    public class AuthorConfiguration:AuditableEntityConfiguraion<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(a => a.Name).IsRequired().HasMaxLength(128);
            builder.Property(a => a.DateOfBirth).IsRequired();

            base.Configure(builder);
        }
    }
}
