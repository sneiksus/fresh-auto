using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Models
{
    public class EFContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Car> Cars { get; set; }

        public EFContext()
        {
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;UserId=root;Password=1111;database=DevDb;");
        }
    }
}
