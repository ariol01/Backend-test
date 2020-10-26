using AppRovemaAriel.Models;
using Microsoft.EntityFrameworkCore;

namespace AppRovemaAriel.Data
{
    public class DataContext: DbContext
    {
        // public DataContext(DbContextOptions options):base(options)
        // {
            
        // }
        
        public DbSet<Product> Products {get;set;}
        public DbSet<Category> Categories {get;set;}
        public DbSet<ProductCategory> ProductCategories {get;set;}
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseInMemoryDatabase("InMemoryProvider");
              optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AppRovemaAriel;Integrated Security=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasKey(x => new { x.CategoryId, x.ProductId });
        }

    }
}