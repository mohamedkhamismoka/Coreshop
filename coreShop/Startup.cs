using coreShop.BL.interfaces;
using coreShop.BL.Repository;
using coreShop.DAL.Database;
using coreShop.DAL.Extend;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using coreShop.BL.Automapper;

namespace coreShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddScoped<UserManager<ApplicationUser>>();
            services.AddScoped<SignInManager<ApplicationUser>>();
            services.AddScoped<RoleManager<IdentityRole>>();
            services.AddScoped<IProduct,ProductRepo>();
            services.AddScoped<ICart, CartRepo>();
            services.AddScoped<IProduct_cart, Product_cartRepo>();
            services.AddScoped<IProduct_cart, Product_cartRepo>();
            services.AddScoped<IProduct_order, Product_orderRepo>();
            services.AddScoped<Iorder, OrderRepo>();
            services.AddScoped<IPAy,PayRepository>();

            //Mapping
            services.AddAutoMapper(x => x.AddProfile(new Domainprofile()));


            // TO get Connection String
            services.AddDbContextPool<DataContext>(opts =>
          opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));




            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
   .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
       options =>
       {
           options.LoginPath = new PathString("/Account/Login");
           options.AccessDeniedPath = new PathString("/Account/Login");
     
       });





            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 1;


            }).AddEntityFrameworkStores<DataContext>()
              .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area=Client}/{controller=Client}/{action=Index}/{id?}"
                );
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
