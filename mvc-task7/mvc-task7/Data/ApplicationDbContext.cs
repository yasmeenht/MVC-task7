using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvc_task7.Models;

namespace mvc_task7.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Category> categories { get; set; }
        public DbSet<Supplier> suppliers { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Order> orders { get; set; }
    

    
    protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Employee>().ToTable("Employee");
            builder.Entity<Order>().ToTable("Order");

            builder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryID);


            builder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.SupplierID);

            builder.Entity<Order>()
                .HasOne(p => p.Employee)
                .WithMany(c => c.Orders)
                .HasForeignKey(p => p.EmployeeId);
        }

    

    }
}
