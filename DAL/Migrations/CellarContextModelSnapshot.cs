﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(CellarContext))]
    partial class CellarContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Bottle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Aroma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DomainName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DrawerId")
                        .HasColumnType("int");

                    b.Property<int?>("DrawerPosition")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GrapeVariety")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("PeakInDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("PeakOutDate")
                        .HasColumnType("date");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("PurchaseDate")
                        .HasColumnType("date");

                    b.Property<string>("RelatedMeals")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Tava")
                        .HasColumnType("int");

                    b.Property<string>("VintageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VintageYear")
                        .HasColumnType("int");

                    b.Property<string>("WineMakerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("YearsOfKeep")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DrawerId");

                    b.ToTable("Bottles");
                });

            modelBuilder.Entity("Models.Cellar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CellarUserId")
                        .HasColumnType("int");

                    b.Property<string>("Family")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Temperature")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CellarUserId");

                    b.ToTable("Cellars");
                });

            modelBuilder.Entity("Models.CellarUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.Drawer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CellarId")
                        .HasColumnType("int");

                    b.Property<int>("NbOfBottlesPerDrawer")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CellarId");

                    b.ToTable("Drawers");
                });

            modelBuilder.Entity("Models.Bottle", b =>
                {
                    b.HasOne("Models.Drawer", "Drawer")
                        .WithMany("Bottles")
                        .HasForeignKey("DrawerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drawer");
                });

            modelBuilder.Entity("Models.Cellar", b =>
                {
                    b.HasOne("Models.CellarUser", "User")
                        .WithMany("Cellars")
                        .HasForeignKey("CellarUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Drawer", b =>
                {
                    b.HasOne("Models.Cellar", "Cellar")
                        .WithMany("Drawers")
                        .HasForeignKey("CellarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cellar");
                });

            modelBuilder.Entity("Models.Cellar", b =>
                {
                    b.Navigation("Drawers");
                });

            modelBuilder.Entity("Models.CellarUser", b =>
                {
                    b.Navigation("Cellars");
                });

            modelBuilder.Entity("Models.Drawer", b =>
                {
                    b.Navigation("Bottles");
                });
#pragma warning restore 612, 618
        }
    }
}
