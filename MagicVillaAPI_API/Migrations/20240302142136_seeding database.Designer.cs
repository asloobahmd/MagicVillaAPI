﻿// <auto-generated />
using System;
using MagicVillaAPI_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVillaAPI_API.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240302142136_seeding database")]
    partial class seedingdatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagicVillaAPI_API.Models.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int>("Sqft")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenity = "",
                            CreatedDate = new DateTime(2024, 3, 2, 19, 51, 35, 925, DateTimeKind.Local).AddTicks(2499),
                            Details = "Sample details",
                            ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/521880995.jpg?k=1c30caf791925fbd5f47ceee91c6cf24e073f6dbab9c14cbd83f9cc81c31735f&o=&hp=1",
                            Name = "Royal Villa",
                            Occupancy = 4,
                            Rate = 200.0,
                            Sqft = 550
                        },
                        new
                        {
                            Id = 2,
                            Amenity = "",
                            CreatedDate = new DateTime(2024, 3, 2, 19, 51, 35, 925, DateTimeKind.Local).AddTicks(2514),
                            Details = "Sample details",
                            ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/521881899.jpg?k=58328b33c718de90b57afc53016df5c9f8cfdd32cc92736a8fa4e8f493e70d84&o=&hp=1",
                            Name = "Bliss Villa",
                            Occupancy = 5,
                            Rate = 180.0,
                            Sqft = 500
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
