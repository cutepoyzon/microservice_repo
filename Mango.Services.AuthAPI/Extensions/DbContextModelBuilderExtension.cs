using Mango.Services.AuthAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductsAPI.Extensions
{
    public static class DbContextModelBuilderExtension
    {
        public static ModelBuilder SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "d08f86fc-a412-4753-914c-f75ab58e5aec",
                Name = "Ian Vixen",
                UserName = "testadmin@gmail.com",
                NormalizedUserName = "TESTADMIN@GMAIL.COM",
                Email = "testadmin@gmail.com",
                NormalizedEmail = "TESTADMIN@GMAIL.COM",
                PasswordHash = "AQAAAAIAAYagAAAAEMv/5ff3qJaYH+T03ukkrjq2Rkqwf78PkJD3LJWNWrZDmqkmwPHX6abzS8cdROw6qQ==",
                PhoneNumber = "0554852149"
            });
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "89487ac5-28eb-4d3d-afe1-429fe32f5822",
                Name = "Aaron Vikes",
                UserName = "testcustomer@gmail.com",
                NormalizedUserName = "TESTCUSTOMER@GMAIL.COM",
                Email = "testcustomer@gmail.com",
                NormalizedEmail = "TESTCUSTOMER@GMAIL.COM",
                PasswordHash = "AQAAAAIAAYagAAAAEMv/5ff3qJaYH+T03ukkrjq2Rkqwf78PkJD3LJWNWrZDmqkmwPHX6abzS8cdROw6qQ==",
                PhoneNumber = "0544852149"
            });

            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole
            {
                Id = "d08f86fc-a412-4753-914c-f75ab58e5aea",
                Name = "ADMIN",
                NormalizedName = "ADMIN"
            });
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole
            {
                Id = "89487ac5-28eb-4d3d-afe1-429fe32f582c",
                Name = "CUSTOMER",
                NormalizedName = "CUSTOMER"
            });

            modelBuilder.Entity<ApplicationUserRole>().HasData(new ApplicationUserRole
            {
                UserId = "d08f86fc-a412-4753-914c-f75ab58e5aec",
                RoleId = "d08f86fc-a412-4753-914c-f75ab58e5aea",
            });
            modelBuilder.Entity<ApplicationUserRole>().HasData(new ApplicationUserRole
            {
                UserId = "89487ac5-28eb-4d3d-afe1-429fe32f5822",
                RoleId = "89487ac5-28eb-4d3d-afe1-429fe32f582c",
            });


            return modelBuilder;
        }
    }
}
