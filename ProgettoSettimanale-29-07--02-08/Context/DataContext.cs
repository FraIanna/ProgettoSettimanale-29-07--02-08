using Microsoft.EntityFrameworkCore;
using ProgettoSettimanale_29_07__02_08.DataLayer.Entities;

namespace ProgettoSettimanale_29_07__02_08.Context
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Ingredient> Ingredients { get; set; }
        
        public virtual DbSet<User> Users { get; set; }
        
        public virtual DbSet<Role> Roles { get; set; }  

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderItem> OrderItem { get; set; }

        public DataContext(DbContextOptions<DataContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Ingredients)
                .WithMany(i => i.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "IngredientProduct",
                    j => j.HasOne<Ingredient>().WithMany().HasForeignKey("IngredientsId"),
                    j => j.HasOne<Product>().WithMany().HasForeignKey("ProductsId"));
        }
    }
}
