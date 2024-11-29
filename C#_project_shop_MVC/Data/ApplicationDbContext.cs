using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using project_shop_MVC.Models;

namespace project_shop_MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Potrzebne do powiązania tabel
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Shoes> Shoes { get; set; }
    }
}
