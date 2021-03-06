﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zedx.Data;

namespace Zedx.Migrations
{
    [DbContext(typeof(ZedxContext))]
    [Migration("20200813134530_local")]
    partial class local
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
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
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Zedx.Models.AllProduct", b =>
                {
                    b.Property<long>("AllProductId")
                        .HasColumnType("bigint");

                    b.Property<int?>("AluminumColorId")
                        .HasColumnType("int");

                    b.Property<int?>("AluminumGageId")
                        .HasColumnType("int");

                    b.Property<long>("CreatedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<long?>("ModifiedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<float>("Rate")
                        .HasColumnType("real");

                    b.HasKey("AllProductId");

                    b.HasIndex("AluminumColorId");

                    b.HasIndex("AluminumGageId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("AllProducts");
                });

            modelBuilder.Entity("Zedx.Models.AluminumColor", b =>
                {
                    b.Property<int>("AluminumColorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AluminumColorId");

                    b.ToTable("AluminumColor");
                });

            modelBuilder.Entity("Zedx.Models.AluminumGage", b =>
                {
                    b.Property<int>("AluminumGageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AluminumGageId");

                    b.ToTable("AluminumGage");
                });

            modelBuilder.Entity("Zedx.Models.AluminumStock", b =>
                {
                    b.Property<long>("AluminumStockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<long>("ProductAluminumId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("AluminumStockId");

                    b.HasIndex("ProductAluminumId");

                    b.ToTable("AluminumStock");
                });

            modelBuilder.Entity("Zedx.Models.Bill", b =>
                {
                    b.Property<long>("BillId")
                        .HasColumnType("bigint");

                    b.Property<long>("CreatedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CustomersCustomerId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<long?>("ModifiedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("NetAmount")
                        .HasColumnType("real");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.Property<float>("TotalDiscount")
                        .HasColumnType("real");

                    b.HasKey("BillId");

                    b.HasIndex("CustomersCustomerId");

                    b.ToTable("Bill");
                });

            modelBuilder.Entity("Zedx.Models.BillDetail", b =>
                {
                    b.Property<long>("BillDetailId")
                        .HasColumnType("bigint");

                    b.Property<long>("AllProductId")
                        .HasColumnType("bigint");

                    b.Property<int?>("AluminumColorId")
                        .HasColumnType("int");

                    b.Property<int?>("AluminumGageId")
                        .HasColumnType("int");

                    b.Property<float>("AmountToBePaid")
                        .HasColumnType("real");

                    b.Property<long>("BillId")
                        .HasColumnType("bigint");

                    b.Property<long>("CreatedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<float>("DiscountedAmount")
                        .HasColumnType("real");

                    b.Property<float>("Feet")
                        .HasColumnType("real");

                    b.Property<long?>("ModifiedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("NetAmount")
                        .HasColumnType("real");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.Property<float>("Rate")
                        .HasColumnType("real");

                    b.Property<float>("SheetHeight")
                        .HasColumnType("real");

                    b.Property<float>("SheetWidth")
                        .HasColumnType("real");

                    b.Property<float>("TotalFeet")
                        .HasColumnType("real");

                    b.HasKey("BillDetailId");

                    b.HasIndex("AllProductId");

                    b.HasIndex("AluminumColorId");

                    b.HasIndex("AluminumGageId");

                    b.HasIndex("BillId");

                    b.ToTable("BillDetail");
                });

            modelBuilder.Entity("Zedx.Models.Customers", b =>
                {
                    b.Property<long>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Zedx.Models.MaintenanceCounter", b =>
                {
                    b.Property<int>("MaintenanceCounterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ColumnName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Counter")
                        .HasColumnType("int");

                    b.Property<string>("TableName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaintenanceCounterId");

                    b.ToTable("MaintenanceCounter");
                });

            modelBuilder.Entity("Zedx.Models.ProductAluminum", b =>
                {
                    b.Property<long>("ProductAluminumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AluminumColorID")
                        .HasColumnType("int");

                    b.Property<int>("AluminumGageID")
                        .HasColumnType("int");

                    b.Property<string>("ProductAluminumName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RatePerFeet")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductAluminumId");

                    b.HasIndex("AluminumColorID");

                    b.HasIndex("AluminumGageID");

                    b.ToTable("ProductAluminum");
                });

            modelBuilder.Entity("Zedx.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("Zedx.Models.ViewModel.ProductType", b =>
                {
                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<long>("CreatedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<long?>("ModifiedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductTypeId");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Zedx.Models.AllProduct", b =>
                {
                    b.HasOne("Zedx.Models.AluminumColor", "AluminumColor")
                        .WithMany()
                        .HasForeignKey("AluminumColorId");

                    b.HasOne("Zedx.Models.AluminumGage", "AluminumGage")
                        .WithMany()
                        .HasForeignKey("AluminumGageId");

                    b.HasOne("Zedx.Models.ViewModel.ProductType", "ProductType")
                        .WithMany("AllProduct")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Zedx.Models.AluminumStock", b =>
                {
                    b.HasOne("Zedx.Models.ProductAluminum", "ProductAluminum")
                        .WithMany()
                        .HasForeignKey("ProductAluminumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Zedx.Models.Bill", b =>
                {
                    b.HasOne("Zedx.Models.Customers", "Customers")
                        .WithMany()
                        .HasForeignKey("CustomersCustomerId");
                });

            modelBuilder.Entity("Zedx.Models.BillDetail", b =>
                {
                    b.HasOne("Zedx.Models.AllProduct", "AllProduct")
                        .WithMany()
                        .HasForeignKey("AllProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Zedx.Models.AluminumColor", "AluminumColor")
                        .WithMany()
                        .HasForeignKey("AluminumColorId");

                    b.HasOne("Zedx.Models.AluminumGage", "AluminumGage")
                        .WithMany()
                        .HasForeignKey("AluminumGageId");

                    b.HasOne("Zedx.Models.Bill", "Bill")
                        .WithMany()
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Zedx.Models.ProductAluminum", b =>
                {
                    b.HasOne("Zedx.Models.AluminumColor", "AluminumColor")
                        .WithMany()
                        .HasForeignKey("AluminumColorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Zedx.Models.AluminumGage", "AluminumGage")
                        .WithMany()
                        .HasForeignKey("AluminumGageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
