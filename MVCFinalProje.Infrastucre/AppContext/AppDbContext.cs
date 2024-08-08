using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MVC_FinalProje.Domain.Core.BaseEntities;
using MVC_FinalProje.Domain.Entities;
using MVC_FinalProje.Domain.Enums;
using MVCFinalProje.Infrastucre.Configuraton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFinalProje.Infrastucre.AppContext
{
    public  class AppDbContex:IdentityDbContext<IdentityUser,IdentityRole,string>   
    {
       public AppDbContex(DbContextOptions<AppDbContex> options):base(options) { }


       public virtual  DbSet<Author> Authors { get; set; }    
        public virtual DbSet<Admin>Admins { get; set; } 
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(IEntityConfiguration).Assembly);
            base.OnModelCreating(builder);
        }
        public override int SaveChanges()
        {
            SetBaseProperties();
            return base.SaveChanges();
        }
         public override Task<int>SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetBaseProperties();
            return base.SaveChangesAsync(cancellationToken);    
        }
        private void SetBaseProperties()
        {
            var enrties = ChangeTracker.Entries<BaseEntity>();
            var userId = "UserBulunamadı";
            foreach(var entry in enrties)
            {
                SetIfAdded(entry , userId);
                SetIfModified(entry , userId);
                SetIfDeleted(entry , userId);
            }
        }

        private void SetIfDeleted(EntityEntry<BaseEntity> entry, string userId)
        {
            if (entry.State != EntityState.Deleted)
            {
                return;
            }
            if(entry.Entity is not AuditableEntity entity)
            {
                return;
            }
            entry.State = EntityState.Modified;
            entry.Entity.Status=Status.Deleted;
            entity.DeletedDate=DateTime.Now;
            entity.DeletedBy=userId;
            
        }

        private void SetIfModified(EntityEntry<BaseEntity> entry, string userId)
        {
            if (entry.State == EntityState.Modified)
            {
                entry.Entity.Status = Status.Modified;
                entry.Entity.UpdatedBy = userId;
                entry.Entity.UpdatedDate = DateTime.Now;
            }
        }

        private void SetIfAdded(EntityEntry<BaseEntity> entry, string userId)
        {
            if(entry.State==EntityState.Added)
            {
                entry.Entity.Status = Status.Added;
                entry.Entity.CreatedBy = userId;    
                entry.Entity.CreatedDate= DateTime.Now; 
            }
        }
    }
}
