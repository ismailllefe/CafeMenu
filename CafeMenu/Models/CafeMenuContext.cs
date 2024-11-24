using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CafeMenu.Models
{
    public class CafeMenuContext : DbContext
    {
        public CafeMenuContext() : base("CafeMenuContext") { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithRequired(p => p.Category)
                .HasForeignKey(p => p.CategoryID);

            modelBuilder.Entity<ProductProperty>()
                .HasRequired(pp => pp.Product)
                .WithMany(p => p.ProductProperties)
                .HasForeignKey(pp => pp.ProductID);

            modelBuilder.Entity<ProductProperty>()
                .HasRequired(pp => pp.Property)
                .WithMany(p => p.ProductProperties)
                .HasForeignKey(pp => pp.PropertyID);
        }
    }
}