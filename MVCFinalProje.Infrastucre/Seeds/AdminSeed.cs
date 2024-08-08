
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MVC_FinalProje.Domain.Entities;
using MVC_FinalProje.Domain.Enums;
using MVCFinalProje.Infrastucre.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFinalProje.Infrastructure.Seeds
{
    public static   class AdminSeed
    {
        private const string adminEmail = "admin@bilgadam.com";
        private const string adminPassword = "Password";
        public static async Task SeedAsync(IConfiguration configuration)
        {
            var dbContextBuilder = new DbContextOptionsBuilder<AppDbContex>();
            dbContextBuilder.UseSqlServer(configuration.GetConnectionString("AppConnectionString"));
            AppDbContex contex=new AppDbContex(dbContextBuilder.Options);
            if(contex.Roles.Any(x=>x.Name=="Admin" ))
            {
                await AddRoles(contex);
            }
            if (!contex.Users.Any(user => user.Email == adminEmail))
            {
                await AddAdmin(contex); 
            }
            
        }
        private static async Task AddAdmin(AppDbContex contex)
        {
            IdentityUser user = new IdentityUser()
            {
                Email = adminEmail,
                NormalizedEmail = adminEmail.ToUpperInvariant(),
                UserName=adminEmail,
                NormalizedUserName=adminEmail.ToUpperInvariant(),


            };
            user.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(user,adminPassword);  
            await contex.Users.AddAsync(user);
            var adminRole = contex.Roles.FirstOrDefault(role => role.Name == Roles.Admin.ToString()).Id;
            await contex.UserRoles.AddAsync(new IdentityUserRole<string>
            {
                RoleId = adminRole,
                UserId = user.Id
            });
            await contex.Admins.AddAsync(new Admin()
            {
                FirstName = "Admin",
                LastName="Admin",
                Email = adminEmail,
                IdentityId = user.Id,

            });
            await contex.SaveChangesAsync(); 

        }

        private static async Task AddRoles(AppDbContex contex)
        {
            string[] roles = Enum.GetNames(typeof(Roles));//Enumda oluşan verilerin isimlşerinni dizi o9larak döer.
            for(int i=0; i<roles.Length; i++)
            {
                if(await contex.Roles.AnyAsync(role => role.Name == roles[i]))
                {
                    continue;
                }
                IdentityRole role = new IdentityRole()
                {
                    Name = roles[i],
                    NormalizedName = roles[i].ToUpperInvariant(),

                };
               // await contex.Roles.Add(role);
                await contex.SaveChangesAsync();    

            }
        }
    }
}
