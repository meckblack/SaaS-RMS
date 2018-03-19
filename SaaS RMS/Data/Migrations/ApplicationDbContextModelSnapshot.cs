﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SaaS_RMS.Data;
using System;

namespace SaaS_RMS.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SaaS_RMS.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SaaS_RMS.Models.Entities.Employee.Bank", b =>
                {
                    b.Property<int>("BankId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("BankId");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("SaaS_RMS.Models.Entities.Employee.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RestaurantId");

                    b.HasKey("EmployeeId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("SaaS_RMS.Models.Entities.Employee.EmployeeBankData", b =>
                {
                    b.Property<int>("EmployeeBankDataId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountFirstName")
                        .IsRequired();

                    b.Property<string>("AccountLastName")
                        .IsRequired();

                    b.Property<string>("AccountMiddleName");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<string>("AccountType")
                        .IsRequired();

                    b.Property<int>("BankId");

                    b.Property<int>("EmployeeId");

                    b.HasKey("EmployeeBankDataId");

                    b.HasIndex("BankId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeBankDatas");
                });

            modelBuilder.Entity("SaaS_RMS.Models.Entities.Employee.EmployeeFamilyData", b =>
                {
                    b.Property<int>("EmployeeFamilyDataId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("ContactNumber")
                        .IsRequired();

                    b.Property<DateTime>("DOB");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int>("EmployeeId");

                    b.Property<string>("NextOfKin")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Relationship")
                        .IsRequired();

                    b.HasKey("EmployeeFamilyDataId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeFamilyDatas");
                });

            modelBuilder.Entity("SaaS_RMS.Models.Entities.Employee.EmployeeMedicalData", b =>
                {
                    b.Property<int>("EmployeeMedicalDataId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BloodGroup")
                        .IsRequired();

                    b.Property<int>("EmployeeId");

                    b.Property<string>("Genotype")
                        .IsRequired();

                    b.HasKey("EmployeeMedicalDataId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeMedicalDatas");
                });

            modelBuilder.Entity("SaaS_RMS.Models.Entities.Employee.EmployeePersonalData", b =>
                {
                    b.Property<int>("EmployeePersonalDataId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DOB")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int>("EmployeeId");

                    b.Property<string>("EmployeeImage");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<string>("HomePhone")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int>("LgaId");

                    b.Property<string>("MaritalStatus")
                        .IsRequired();

                    b.Property<string>("MiddleName");

                    b.Property<string>("MobilePhone");

                    b.Property<string>("POB")
                        .IsRequired();

                    b.Property<string>("PrimaryAddress")
                        .IsRequired();

                    b.Property<string>("SecondaryAddress");

                    b.Property<int>("StateId");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("WorkPhone")
                        .IsRequired();

                    b.HasKey("EmployeePersonalDataId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("LgaId");

                    b.HasIndex("StateId");

                    b.ToTable("EmployeePersonalDatas");
                });

            modelBuilder.Entity("SaaS_RMS.Models.Entities.Employee.EmployeeWorkData", b =>
                {
                    b.Property<int>("EmployeeWorkDataId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("EmploymentDate");

                    b.Property<int?>("EmploymentPositionId");

                    b.Property<string>("EmploymentStatus")
                        .IsRequired();

                    b.HasKey("EmployeeWorkDataId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("EmploymentPositionId");

                    b.ToTable("EmployeeWorkDatas");
                });

            modelBuilder.Entity("SaaS_RMS.Models.Entities.Employee.EmploymentPosition", b =>
                {
                    b.Property<int>("EmploymentPositionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int?>("EmployeeId");

                    b.Property<long>("Income");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("RestaurantId");

                    b.Property<bool>("SeniorMember");

                    b.HasKey("EmploymentPositionId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("EmploymentPositions");
                });

            modelBuilder.Entity("SaaS_RMS.Models.Entities.Restuarant.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("RestaurantId");

                    b.HasKey("DepartmentId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("SaaS_RMS.Models.Entities.System.Lga", b =>
                {
                    b.Property<int>("LgaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("StateId");

                    b.HasKey("LgaId");

                    b.HasIndex("StateId");

                    b.ToTable("Lgas");
                });

            modelBuilder.Entity("SaaS_RMS.Models.Entities.System.Package", b =>
                {
                    b.Property<int>("PackageId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("PackageId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("SaaS_RMS.Models.Entities.System.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessCode")
                        .IsRequired();

                    b.Property<string>("ContactEmail")
                        .IsRequired();

                    b.Property<string>("ContactNumber")
                        .IsRequired();

                    b.Property<int>("LgaId");

                    b.Property<string>("Location")
                        .IsRequired();

                    b.Property<string>("Logo");

                    b.Property<string>("Motto");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("RegistrationNumber");

                    b.Property<string>("SetUpStatus");

                    b.Property<int?>("StateId");

                    b.Property<DateTime>("SubscriprionStartDate");

                    b.Property<string>("SubscriptionDuration");

                    b.Property<DateTime>("SubscriptonEndDate");

                    b.HasKey("RestaurantId");

                    b.HasIndex("LgaId");

                    b.HasIndex("StateId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("SaaS_RMS.Models.Entities.System.State", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("StateId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SaaS_RMS.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SaaS_RMS.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SaaS_RMS.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SaaS_RMS.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaaS_RMS.Models.Entities.Employee.Employee", b =>
                {
                    b.HasOne("SaaS_RMS.Models.Entities.System.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaaS_RMS.Models.Entities.Employee.EmployeeBankData", b =>
                {
                    b.HasOne("SaaS_RMS.Models.Entities.Employee.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SaaS_RMS.Models.Entities.Employee.Employee", "Employee")
                        .WithMany("EmployeeBankDatas")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaaS_RMS.Models.Entities.Employee.EmployeeFamilyData", b =>
                {
                    b.HasOne("SaaS_RMS.Models.Entities.Employee.Employee", "Employee")
                        .WithMany("EmployeeFamilyDatas")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaaS_RMS.Models.Entities.Employee.EmployeeMedicalData", b =>
                {
                    b.HasOne("SaaS_RMS.Models.Entities.Employee.Employee", "Employee")
                        .WithMany("EmployeeMedicalDatas")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaaS_RMS.Models.Entities.Employee.EmployeePersonalData", b =>
                {
                    b.HasOne("SaaS_RMS.Models.Entities.Employee.Employee", "Employee")
                        .WithMany("EmployeePersonalDatas")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SaaS_RMS.Models.Entities.System.Lga", "Lga")
                        .WithMany()
                        .HasForeignKey("LgaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SaaS_RMS.Models.Entities.System.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaaS_RMS.Models.Entities.Employee.EmployeeWorkData", b =>
                {
                    b.HasOne("SaaS_RMS.Models.Entities.Employee.Employee", "Employee")
                        .WithMany("EmployeeWorkDatas")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SaaS_RMS.Models.Entities.Employee.EmploymentPosition")
                        .WithMany("EmployeeWorkDatas")
                        .HasForeignKey("EmploymentPositionId");
                });

            modelBuilder.Entity("SaaS_RMS.Models.Entities.Employee.EmploymentPosition", b =>
                {
                    b.HasOne("SaaS_RMS.Models.Entities.Employee.Employee")
                        .WithMany("EmploymentPositions")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("SaaS_RMS.Models.Entities.System.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaaS_RMS.Models.Entities.Restuarant.Department", b =>
                {
                    b.HasOne("SaaS_RMS.Models.Entities.Employee.Employee", "Employee")
                        .WithMany("Departments")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SaaS_RMS.Models.Entities.System.Restaurant", "Restaurant")
                        .WithMany("Departments")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaaS_RMS.Models.Entities.System.Lga", b =>
                {
                    b.HasOne("SaaS_RMS.Models.Entities.System.State", "State")
                        .WithMany("Lgas")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaaS_RMS.Models.Entities.System.Restaurant", b =>
                {
                    b.HasOne("SaaS_RMS.Models.Entities.System.Lga", "Lga")
                        .WithMany("Restaurants")
                        .HasForeignKey("LgaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SaaS_RMS.Models.Entities.System.State")
                        .WithMany("Restaurants")
                        .HasForeignKey("StateId");
                });
#pragma warning restore 612, 618
        }
    }
}
