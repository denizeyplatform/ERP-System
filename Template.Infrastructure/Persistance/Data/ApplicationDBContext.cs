using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Common;
using Template.Domain.Entities.Commerce;
using Template.Domain.Entities.HRM;

namespace Template.Infrastructure.Persistance.Data
{
    public class ApplicationDBContext : DbContext 
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
             : base(options)
        {
        }

        #region HRM Entities
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        #endregion

        #region commerce Entities
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region HRM
            modelBuilder.Entity<Employee>().ToTable("Employees", "hrm");
            modelBuilder.Entity<Attendance>().ToTable("Attendances", "hrm");
            #endregion
            #region Commerce
            modelBuilder.Entity<Category>().ToTable("Categories", "ecommerce");
            modelBuilder.Entity<Product>().ToTable("Products", "ecommerce");
            modelBuilder.Entity<Order>().ToTable("Orders", "ecommerce");
            modelBuilder.Entity<OrderItem>().ToTable("OrderItems", "ecommerce");
            modelBuilder.Entity<Payment>().ToTable("Payments", "ecommerce");

            // Soft Delete Global Filter
            modelBuilder.Entity<Product>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(e => !e.IsDeleted);

            modelBuilder.Entity<Order>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<OrderItem>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Payment>().HasQueryFilter(e => !e.IsDeleted);

            // Product - Category
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);


            // Order - Items
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);
            #endregion

        }

    }
}
