using Microsoft.EntityFrameworkCore;
using ProductsManagementForUnitTest.Domains;
using System.Collections.Generic;

namespace ProductsManagementForUnitTest.Contexts
{
    public class ProductsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=NOTE01-SALA19; initial catalog=ProductsDb; User Id=sa; Pwd=Senai@134; TrustServerCertificate=true;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
