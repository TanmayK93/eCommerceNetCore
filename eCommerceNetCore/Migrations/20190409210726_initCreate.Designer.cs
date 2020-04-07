﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eCommerceNetCore.Models;

namespace eCommerceNetCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190409210726_initCreate")]
    partial class initCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eCommerceNetCore.Models.Cart", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("UserId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("eCommerceNetCore.Models.Comments", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("UserId");

                    b.Property<int>("rating");

                    b.Property<string>("text");

                    b.HasKey("ProductId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("eCommerceNetCore.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("date");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("eCommerceNetCore.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId");

                    b.Property<int>("productId");

                    b.Property<int>("quantity");

                    b.Property<int>("userid");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("productId");

                    b.HasIndex("userid");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("eCommerceNetCore.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description");

                    b.Property<int>("discount");

                    b.Property<string>("image");

                    b.Property<string>("name");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("rating");

                    b.Property<string>("sale");

                    b.Property<decimal>("shippingCost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("eCommerceNetCore.Models.ShippingAddress", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address1");

                    b.Property<string>("address2");

                    b.Property<string>("city");

                    b.Property<string>("country");

                    b.Property<string>("defaultaddress");

                    b.Property<string>("name");

                    b.Property<string>("phone");

                    b.Property<string>("postal");

                    b.Property<string>("region");

                    b.Property<int>("userID");

                    b.HasKey("id");

                    b.HasIndex("userID");

                    b.ToTable("ShippingAddress");
                });

            modelBuilder.Entity("eCommerceNetCore.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email");

                    b.Property<string>("password");

                    b.Property<string>("phone");

                    b.Property<string>("username");

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("eCommerceNetCore.Models.Cart", b =>
                {
                    b.HasOne("eCommerceNetCore.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("eCommerceNetCore.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("eCommerceNetCore.Models.Comments", b =>
                {
                    b.HasOne("eCommerceNetCore.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("eCommerceNetCore.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("eCommerceNetCore.Models.OrderDetail", b =>
                {
                    b.HasOne("eCommerceNetCore.Models.Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("eCommerceNetCore.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("eCommerceNetCore.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("eCommerceNetCore.Models.ShippingAddress", b =>
                {
                    b.HasOne("eCommerceNetCore.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
