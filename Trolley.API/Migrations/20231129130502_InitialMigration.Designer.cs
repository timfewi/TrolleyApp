﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trolley.API.Data;

#nullable disable

namespace Trolley.API.Migrations
{
    [DbContext(typeof(TrolleyDbContext))]
    [Migration("20231129130502_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Trolley.API.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("Trolley.API.Entities.BrandProduct", b =>
                {
                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("BrandId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("BrandProduct");
                });

            modelBuilder.Entity("Trolley.API.Entities.Icon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Icon");
                });

            modelBuilder.Entity("Trolley.API.Entities.Market", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MarketCategory")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Market");
                });

            modelBuilder.Entity("Trolley.API.Entities.MarketProduct", b =>
                {
                    b.Property<int>("MarketId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("MarketId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("MarketProduct");
                });

            modelBuilder.Entity("Trolley.API.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("IconId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDiscountProduct")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOrganic")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IconId");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Trolley.API.Entities.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("Trolley.API.Entities.ProductShoppingList", b =>
                {
                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("ShoppingListId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "ShoppingListId");

                    b.HasIndex("ShoppingListId");

                    b.ToTable("ProductShoppingList");
                });

            modelBuilder.Entity("Trolley.API.Entities.ShoppingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsCheapest")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ShoppingList");
                });

            modelBuilder.Entity("Trolley.API.Entities.ShoppingListUser", b =>
                {
                    b.Property<int>("ShoppingListId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ShoppingListId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ShoppingListUser");
                });

            modelBuilder.Entity("Trolley.API.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Trolley.API.Entities.BrandProduct", b =>
                {
                    b.HasOne("Trolley.API.Entities.Brand", "Brand")
                        .WithMany("BrandProducts")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trolley.API.Entities.Product", "Product")
                        .WithMany("BrandProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Trolley.API.Entities.MarketProduct", b =>
                {
                    b.HasOne("Trolley.API.Entities.Market", "Market")
                        .WithMany("MarketProduct")
                        .HasForeignKey("MarketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trolley.API.Entities.Product", "Product")
                        .WithMany("MarketProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Market");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Trolley.API.Entities.Product", b =>
                {
                    b.HasOne("Trolley.API.Entities.Icon", "Icon")
                        .WithMany("Products")
                        .HasForeignKey("IconId");

                    b.HasOne("Trolley.API.Entities.ProductCategory", "ProductCategory")
                        .WithMany()
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Icon");

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("Trolley.API.Entities.ProductShoppingList", b =>
                {
                    b.HasOne("Trolley.API.Entities.Product", "Product")
                        .WithMany("ProductShoppingLists")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trolley.API.Entities.ShoppingList", "ShoppingList")
                        .WithMany("ProductShoppingLists")
                        .HasForeignKey("ShoppingListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ShoppingList");
                });

            modelBuilder.Entity("Trolley.API.Entities.ShoppingListUser", b =>
                {
                    b.HasOne("Trolley.API.Entities.ShoppingList", "ShoppingList")
                        .WithMany("ShoppingListUsers")
                        .HasForeignKey("ShoppingListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trolley.API.Entities.User", "User")
                        .WithMany("ShoppingListUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShoppingList");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Trolley.API.Entities.Brand", b =>
                {
                    b.Navigation("BrandProducts");
                });

            modelBuilder.Entity("Trolley.API.Entities.Icon", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Trolley.API.Entities.Market", b =>
                {
                    b.Navigation("MarketProduct");
                });

            modelBuilder.Entity("Trolley.API.Entities.Product", b =>
                {
                    b.Navigation("BrandProducts");

                    b.Navigation("MarketProducts");

                    b.Navigation("ProductShoppingLists");
                });

            modelBuilder.Entity("Trolley.API.Entities.ShoppingList", b =>
                {
                    b.Navigation("ProductShoppingLists");

                    b.Navigation("ShoppingListUsers");
                });

            modelBuilder.Entity("Trolley.API.Entities.User", b =>
                {
                    b.Navigation("ShoppingListUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
