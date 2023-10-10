using BlogAPP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPP.DBContext
{
    public class MyDbContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Gender> Genders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);   

            optionsBuilder.UseSqlServer(connectionString: "Server=localhost;Database=BlogApp;Integrated Security=True;TrustServerCertificate=True;");
        }
    }
}
