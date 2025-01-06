using CoreCodeFirst_2.Models.Configurations;
using CoreCodeFirst_2.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace CoreCodeFirst_2.Models.ContextClasses
{
    public class MyContext : DbContext
    {

        //Burada Constructor'a verdigimiz DbContextOptions<> tipindeki parametre veritabanı sınıfımızın sahip olacagı ayarlamaları ifade eder...Bu ayarlamaların bu şekilde verildikten sonra MyContext artık bizim tarafımızdan manual olarak cagrılmayacaktır...Biz middleware'de bu ayarlamaların neler oldugunu belirtecegiz ve Middleware MyContext sınıfını tetiklerken bu ayarlamaları onun constructor'ina argüman olarak gönderecektir...Sonra MyContext'in miras aldıgı DbContext sınıfının constructor'ina da bu ayarlamalar gidecektir (base(opt) ifadesi sayesinde)
        public MyContext(DbContextOptions<MyContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserProfileConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserProfile> AppUserProfiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
