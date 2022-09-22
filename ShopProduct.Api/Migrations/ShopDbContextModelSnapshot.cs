﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopProduct.Api.Data;

#nullable disable

namespace ShopProduct.Api.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    partial class ShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Shop.Api.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "White Puma Sneakers - Blue durable trainers provided by Puma",
                            Name = "White Puma Sneakers",
                            Price = 500m,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 2,
                            Description = "Blue Nike Trainers - Blue durable trainers provided by Nike",
                            Name = "Blue Nike Trainers",
                            Price = 200m,
                            Quantity = 110
                        },
                        new
                        {
                            Id = 3,
                            Description = "Birkenstock Sandals - Leather sandals available in different colours and sizes",
                            Name = "Birkenstock Sandals",
                            Price = 50m,
                            Quantity = 90
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
