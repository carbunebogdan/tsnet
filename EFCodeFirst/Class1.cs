using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Configuration;

namespace ClassLibraryNetCore.Model
{
    public partial class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
    }

    public partial class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
    public partial class Order
    {
        public int OrderId { get; set; }
        public decimal TotalValue { get; set; }
        public System.DateTime Date { get; set; }
        public int CustomerCustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }

    public partial class Album
    {
        public Album()
        {
            this.Artists = new HashSet<Artist>();
        }

        public int AlbumId { get; set; }
        public string AlbumName { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }
    }

    public partial class Artist
    {
        public Artist()
        {
            this.Albums = new HashSet<Album>();
        }

        public int ArtistId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }

    public class ModelContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-KAUU9VV;Database = EFCore2020; Trusted_Connection = True");
        //ChangeTracker.LazyLoadingEnabled = false;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
            .HasMany<Order>(o => o.Orders)
            .WithOne(c => c.Customer);

            modelBuilder.Entity<Artist>()
            .HasMany<Album>(alb => alb.Albums);


            modelBuilder.Entity<Album>()
            .HasMany<Artist>(art => art.Artists);
        }
    }

}