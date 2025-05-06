using Microsoft.EntityFrameworkCore;
using StockApp.Core.Entities;

namespace StokApp.Persistence.Contexts
{
    public class StockAppContext : DbContext
    {
        public StockAppContext(DbContextOptions<StockAppContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Fluet API

            #region "Tables"

            // set name in db to spanish
            modelBuilder.Entity<Product>().ToTable("Productos");
            modelBuilder.Entity<Category>().ToTable("Categorias");

            #endregion

            #region "Primary Key"

            modelBuilder.Entity<Product>().HasKey( p => p.Id);// Lamda
            modelBuilder.Entity<Category>().HasKey(c => c.Id);

            #endregion

            #region "RelationsShips"

            modelBuilder.Entity<Category>()
                .HasMany<Product>(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region "Properties Configuration"

            #region Product
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(150);
            #endregion

            #region Category
            modelBuilder.Entity<Category>()
                .Property( c => c.Name)
                .HasMaxLength(150);
            #endregion


            #endregion
        }
    }
}
