using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DB_Layer.Models
{
    public class DataDbContext : IdentityDbContext<CustomUser, CustomRole, int>
    {
        public DataDbContext()
        {

        }
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {

        }


        public DbSet<Country> Countries { get; set; }

        public DbSet<Order> Order { get; set; }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Distributor> Distributors { get; set; }

        public DbSet<Branch> Branches { get; set; }

        public DbSet<Pharmacy> Pharmacies { get; set; }

        public DbSet<Order_Products> Order_Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order_Products>()
           .HasKey(op => new { op.OrderId, op.ProductId });


            modelBuilder.Entity<CustomUser>()
                .HasOne(u => u.Manager)
                .WithMany()
                .HasForeignKey(u => u.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
        .HasIndex(o => o.Name)
        .IsUnique();


            modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderProducts)
            .WithOne()
            .HasForeignKey(op => op.OrderId);


            modelBuilder.Entity<Order>()
    .HasOne(o => o.MedRep)
    .WithMany()
    .HasForeignKey(o => o.MedRepId)
    .IsRequired(false)  // Specify that the foreign key is optional
    .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Order>()
    .HasOne(o => o.DM)
    .WithMany()
    .HasForeignKey(o => o.DMId)
    .IsRequired(false)  // Specify that the foreign key is optional
    .OnDelete(DeleteBehavior.Restrict);  // You can choose the desired delete behavior


            modelBuilder.Entity<Order>()
    .HasOne(o => o.Country)
    .WithMany()
    .HasForeignKey(o => o.CountryId)
    .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Order>()
    .HasOne(o => o.Pharmacy)
    .WithMany()
    .HasForeignKey(o => o.PharmacyId)
    .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Role>().HasData(
                new Role() { Id = 1, Name = "DM" });
            modelBuilder.Entity<Role>().HasData(
                new Role() { Id = 2, Name = "MR" });

            modelBuilder.Entity<Country>().HasData(
                new Country() { Id = 1, Name = "KSA" });
            modelBuilder.Entity<Country>().HasData(
                new Country() { Id = 2, Name = "EG" });


            modelBuilder.Entity<Product>().HasData(new Product()
            { Id = 1, Name = "CataFast", Price = 50, Description = "No Descript"});
            modelBuilder.Entity<Product>().HasData(new Product()
            { Id = 2, Name = "Panadol", Price = 20, Description = "No Description" });

            base.OnModelCreating(modelBuilder);
        }


    }
}
