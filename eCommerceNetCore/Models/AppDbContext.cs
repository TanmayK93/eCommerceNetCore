﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceNetCore.Models;

namespace eCommerceNetCore.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // We are doing this so that we disable the default behaviour to use Delete Cascade on foreign keys
            foreach (Microsoft.EntityFrameworkCore.Metadata.IMutableForeignKey relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            // Do this to ensure that all Decimal data types have two decimal places of precision
            foreach (Microsoft.EntityFrameworkCore.Metadata.IMutableProperty property in modelBuilder.Model.GetEntityTypes()
                                                       .SelectMany(t => t.GetProperties())
                                                       .Where(p => p.ClrType == typeof(decimal)))
                property.Relational().ColumnType = "decimal(18,2)";

            //Cart Relationship
            modelBuilder.Entity<Cart>().HasKey(x => new { x.UserId, x.ProductId });

            //Comment Relationship
            modelBuilder.Entity<Comments>().HasKey(x => new { x.ProductId, x.UserId });


            base.OnModelCreating(modelBuilder);
        }


        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Comments> Comment { get; set; }
        public DbSet<ShippingAddress> ShippingAddress { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
