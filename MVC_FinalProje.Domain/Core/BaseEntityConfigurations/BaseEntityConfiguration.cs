﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_FinalProje.Domain.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_FinalProje.Domain.Core.BaseEntityConfigurations
{
    public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual  void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x=>x.Id).ValueGeneratedNever();
            builder.Property(x=>x.Status).IsRequired(true);
            builder.Property(x=>x.CreatedBy).IsRequired(true);  
            builder.Property(x=>x.CreatedDate).IsRequired(true);    
            builder.Property(x=>x.UpdatedBy).IsRequired(false);
            builder.Property(x=> x.UpdatedDate).IsRequired(false);  

        }
    }
}
