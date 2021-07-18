﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RookieShop.Backend.Data;

namespace RookieShop.Backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("RookieShop.Backend.Models.Category", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            id = "RSCA0001",
                            name = "Men"
                        },
                        new
                        {
                            id = "RSCA0002",
                            name = "Women"
                        },
                        new
                        {
                            id = "RSCA0003",
                            name = "Baby"
                        });
                });

            modelBuilder.Entity("RookieShop.Backend.Models.Customer", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            id = "RSC0001",
                            address = "27 IronMan street",
                            password = "helloAlice",
                            phone = "(+84) 524-525-526",
                            username = "alice"
                        },
                        new
                        {
                            id = "RSC0002",
                            address = "32 Batman street",
                            password = "helloBob",
                            phone = "(+84) 594-595-596",
                            username = "bob"
                        });
                });

            modelBuilder.Entity("RookieShop.Backend.Models.Order", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("customerid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("total")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.HasIndex("customerid");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("RookieShop.Backend.Models.OrderDetail", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Productid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<string>("orderid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.HasIndex("Productid");

                    b.HasIndex("orderid");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("RookieShop.Backend.Models.Product", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<string>("categoryid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.HasIndex("categoryid");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            id = "RSCAPM0001",
                            amount = 100,
                            description = "Limited edition printed shirt at New York Athletic club event 2020",
                            imageUri = "ProductImage/m1.jpg",
                            name = "NY Athletic Club shirt",
                            price = 2000000f
                        },
                        new
                        {
                            id = "RSCAPM0002",
                            amount = 200,
                            description = "Favorite biker jacket variant made by natural Croc skin",
                            imageUri = "ProductImage/m2.jpg",
                            name = "Croc Biker Jacket",
                            price = 1500000f
                        },
                        new
                        {
                            id = "RSCAPM0003",
                            amount = 120,
                            description = "Fan thanks t-shirt at Tom&Jerry anniversary show",
                            imageUri = "ProductImage/m3.jpg",
                            name = "Tom&Jerry fan thanks T-shirt",
                            price = 1500000f
                        },
                        new
                        {
                            id = "RSCAPWM0001",
                            amount = 80,
                            description = "Top 300 Fashion dress in 2020",
                            imageUri = "ProductImage/wm1.jpg",
                            name = "Old Western style summer white dress",
                            price = 2100000f
                        },
                        new
                        {
                            id = "RSCAPWM0002",
                            amount = 150,
                            description = "Suitable for jogging and casual",
                            imageUri = "ProductImage/wm2.jpg",
                            name = "Karo dress",
                            price = 900000f
                        },
                        new
                        {
                            id = "RSCAPWM0003",
                            amount = 50,
                            description = "Best seller product in 2020",
                            imageUri = "ProductImage/wm3.jpg",
                            name = "Sub-jacket dress",
                            price = 1000000f
                        },
                        new
                        {
                            id = "RSCAPBB0001",
                            amount = 90,
                            description = "Best seller baby product in June 2020",
                            imageUri = "ProductImage/bb1.jpg",
                            name = "Zip-through hoodie",
                            price = 400000f
                        },
                        new
                        {
                            id = "RSCAPBB0002",
                            amount = 100,
                            description = "Best seller baby product in Jan 2020",
                            imageUri = "ProductImage/bb2.jpg",
                            name = "Teddy 2-piece fleece set",
                            price = 380000f
                        },
                        new
                        {
                            id = "RSCAPBB0003",
                            amount = 100,
                            description = "Best seller baby product in Apr 2020",
                            imageUri = "ProductImage/bb3.jpg",
                            name = "Mini Hooded jacket",
                            price = 380000f
                        });
                });

            modelBuilder.Entity("RookieShop.Backend.Models.Rating", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Productid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("localDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ratingPoint")
                        .HasColumnType("int");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Productid");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("RookieShop.Backend.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

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
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
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
                    b.HasOne("RookieShop.Backend.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RookieShop.Backend.Models.User", null)
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

                    b.HasOne("RookieShop.Backend.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RookieShop.Backend.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RookieShop.Backend.Models.Order", b =>
                {
                    b.HasOne("RookieShop.Backend.Models.Customer", "customer")
                        .WithMany("orders")
                        .HasForeignKey("customerid");

                    b.Navigation("customer");
                });

            modelBuilder.Entity("RookieShop.Backend.Models.OrderDetail", b =>
                {
                    b.HasOne("RookieShop.Backend.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Productid");

                    b.HasOne("RookieShop.Backend.Models.Order", "order")
                        .WithMany("orderDetails")
                        .HasForeignKey("orderid");

                    b.Navigation("order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("RookieShop.Backend.Models.Product", b =>
                {
                    b.HasOne("RookieShop.Backend.Models.Category", null)
                        .WithMany("products")
                        .HasForeignKey("categoryid");
                });

            modelBuilder.Entity("RookieShop.Backend.Models.Rating", b =>
                {
                    b.HasOne("RookieShop.Backend.Models.Product", null)
                        .WithMany("ratings")
                        .HasForeignKey("Productid");
                });

            modelBuilder.Entity("RookieShop.Backend.Models.Category", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("RookieShop.Backend.Models.Customer", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("RookieShop.Backend.Models.Order", b =>
                {
                    b.Navigation("orderDetails");
                });

            modelBuilder.Entity("RookieShop.Backend.Models.Product", b =>
                {
                    b.Navigation("ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
