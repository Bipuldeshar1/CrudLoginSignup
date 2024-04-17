using CrudLoginSignup.Models.product;
using CrudLoginSignup.Models.user;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrudLoginSignup.data
{
    public class AppDbContext:IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<User>Users { get; set; }

        public DbSet<Product> products { get; set; }
    }
}
