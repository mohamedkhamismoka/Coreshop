using coreShop.DAL.Entity;
using coreShop.DAL.Extend;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreShop.DAL.Database
{
 public class DataContext:IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product_order>().HasKey(a => new { a.order_id, a.product_id });
            builder.Entity<Product_cart>().HasKey(a => new { a.product_id, a.cart_id });
            builder.Entity<IdentityUserLogin<string>>().HasKey(a => a.UserId);
            builder.Entity<IdentityUserRole<string>>().HasKey(a => new { a.UserId, a.RoleId });
            builder.Entity<IdentityUserToken<string>>().HasNoKey();
            builder.Entity<Cart>()
    .Property(et => et.ID)
    .ValueGeneratedNever();

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> carts { get; set; }

        public DbSet<Product_order> product_Orders { get; set; }

        public DbSet<Product_cart> product_Carts { get; set; }

        public DbSet<Pay> pays { get; set; }
    }
}

