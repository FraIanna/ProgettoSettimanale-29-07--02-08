using Microsoft.EntityFrameworkCore;
using ProgettoSettimanale_29_07__02_08.Models.Entities;

namespace ProgettoSettimanale_29_07__02_08.Context
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Ingredient> Ingredients { get; set; }
        
        public virtual DbSet<User> Users { get; set; }
        
        public virtual DbSet<Role> Roles { get; set; }  

        public virtual DbSet<Order> Orders { get; set; }

        public DataContext(DbContextOptions<DataContext> opt) : base(opt) { }
    }
}
