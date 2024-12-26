using Microsoft.EntityFrameworkCore;
using Sopfy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopfy.Persistence.Context
{
    public class AppDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // SQL BAĞLANTILARI BURADA  YAPILMAKTADIR.
            optionsBuilder.UseSqlServer("Data Source=KEY\\SQLEXPRESS; database=Shopfy; Integrated Security=True; TrustServerCertificate=True;");
        }
        public DbSet<Category> Categories{ get; set; }
    }
}
