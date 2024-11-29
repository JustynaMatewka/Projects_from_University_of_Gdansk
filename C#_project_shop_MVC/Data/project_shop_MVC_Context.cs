using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using project_shop_MVC.Models;

namespace project_shop_MVC.Data
{
    public class project_shop_MVC_Context : DbContext
    {
        public project_shop_MVC_Context (DbContextOptions<project_shop_MVC_Context> options)
            : base(options)
        {
        }

        public DbSet<project_shop_MVC.Models.Sales> Sales { get; set; } = default!;
        public DbSet<project_shop_MVC.Models.Shoes> Shoes { get; set; } = default!;
    }
}
