﻿// <auto-generated />
using CompaniesApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CompaniesApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210727111324_addItitialSeedData")]
    partial class addItitialSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CompaniesApp.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Company");

                    b.HasData(
                        new
                        {
                            CompanyId = 1,
                            Email = "contact@microsoft.com",
                            Logo = "\\images\\Microsoft_logo.png",
                            Name = "Microsoft",
                            Website = "microsoft.com"
                        },
                        new
                        {
                            CompanyId = 2,
                            Email = "contact@google.com",
                            Logo = "\\images\\Google_logo.png",
                            Name = "Google",
                            Website = "google.com"
                        },
                        new
                        {
                            CompanyId = 3,
                            Email = "contact@apple.com",
                            Logo = "\\images\\Apple_logo.png",
                            Name = "Apple",
                            Website = "apple.com"
                        },
                        new
                        {
                            CompanyId = 4,
                            Email = "contact@amazon.com",
                            Logo = "\\images\\Amazon_logo.png",
                            Name = "Amazon",
                            Website = "amazon.com"
                        },
                        new
                        {
                            CompanyId = 5,
                            Email = "contact@facebook.com",
                            Logo = "\\images\\Facebook_logo.png",
                            Name = "Facebook",
                            Website = "facebook.com"
                        },
                        new
                        {
                            CompanyId = 6,
                            Email = "contact@netflix.com",
                            Logo = "\\images\\Netflix_logo.png",
                            Name = "Netflix",
                            Website = "netflix.com"
                        });
                });

            modelBuilder.Entity("CompaniesApp.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            CompanyId = 1,
                            Email = "ringo@star.com",
                            FirstName = "Ringo",
                            LastName = "Star",
                            PhoneNumber = "001987621"
                        },
                        new
                        {
                            EmployeeId = 2,
                            CompanyId = 2,
                            Email = "paul@mccartney.com",
                            FirstName = "Paul",
                            LastName = "McCartney",
                            PhoneNumber = "001987622"
                        },
                        new
                        {
                            EmployeeId = 3,
                            CompanyId = 3,
                            Email = "george@harrison.com",
                            FirstName = "George",
                            LastName = "Harrison",
                            PhoneNumber = "001987623"
                        },
                        new
                        {
                            EmployeeId = 4,
                            CompanyId = 4,
                            Email = "john@lennon.com",
                            FirstName = "John",
                            LastName = "Lennon",
                            PhoneNumber = "001987624"
                        },
                        new
                        {
                            EmployeeId = 5,
                            CompanyId = 5,
                            Email = "ozzy@osbourne.com",
                            FirstName = "Ozzy",
                            LastName = "Osbourne",
                            PhoneNumber = "001987625"
                        },
                        new
                        {
                            EmployeeId = 6,
                            CompanyId = 6,
                            Email = "benedict@cumberbatch.com",
                            FirstName = "Benedict",
                            LastName = "Cumberbatch",
                            PhoneNumber = "001987626"
                        });
                });

            modelBuilder.Entity("CompaniesApp.Models.Employee", b =>
                {
                    b.HasOne("CompaniesApp.Models.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("CompaniesApp.Models.Company", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}