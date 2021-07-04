using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Models;
using System.Collections.Generic;

namespace RookieShop.Backend.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // public DbSet<Brand> Brands { get; set; }

        /*public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }*/

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Customer>().HasData(new List<Customer>()
            {
                new Customer() {id = "RSC0001", username="alice", password="helloAlice", phone="(+84) 524-525-526", address= "27 IronMan street"},
                new Customer() {id = "RSC0002", username="bob", password="helloBob", phone="(+84) 594-595-596", address="32 Batman street"}
            });

            builder.Entity<Category>().HasData(new List<Category>()
            {
                new Category() {id = "RSCA0001", name="men"},
                new Category() {id = "RSCA0002", name="women"},
                new Category() {id = "RSCA0003", name="baby"}
            });

            builder.Entity<Product>().HasData(new List<Product>()
            {
                new Product() {id = "RSCAPM0001", name="NY Athletic Club shirt", description="Limited edition printed shirt at New York Athletic club event 2020", amount=100, price=2000000, imageUri="ShopImage/m1.jpg"},
                new Product() {id = "RSCAPM0002", name="Croc Biker Jacket", description="Favorite biker jacket variant made by natural Croc skin", amount=200, price=1500000 , imageUri="ShopImage/m2.jpg"},
                new Product() {id = "RSCAPM0003", name="Tom&Jerry fan thanks T-shirt", description="Fan thanks t-shirt at Tom&Jerry anniversary show", amount=120, price=1500000, imageUri="ShopImage/m3.jpg"},
                new Product() {id = "RSCAPWM0001", name="Old Western style summer white dress", description="Top 300 Fashion dress in 2020", amount=80, price=2100000, imageUri="ShopImage/wm1.jpg"},
                new Product() {id = "RSCAPWM0002", name="Karo dress", description="Suitable for jogging and casual", amount=150, price=900000, imageUri="ShopImage/wm2.jpg"},
                new Product() {id = "RSCAPWM0003", name="Sub-jacket dress", description="Best seller product in 2020", amount=50, price=1000000, imageUri="ShopImage/wm3.jpg"},
                new Product() {id = "RSCAPBB0001", name="Zip-through hoodie", description="Best seller baby product in June 2020", amount=90, price=400000, imageUri="ShopImage/bb1.jpg"},
                new Product() {id = "RSCAPBB0002", name="Teddy 2-piece fleece set", description="Best seller baby product in Jan 2020", amount=100, price=380000, imageUri="ShopImage/bb2.jpg"},
                new Product() {id = "RSCAPBB0003", name="Mini Hooded jacket", description="Best seller baby product in Apr 2020", amount=100, price=380000, imageUri="ShopImage/bb3.jpg"},
            });
        }
    }
}
