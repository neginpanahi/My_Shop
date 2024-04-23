using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.Application.Service;
using Demo.Contracts;
using Demo.Domain;
using Demo.Infra.Data;
using Demo.Infra.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Endpoint.Extention;
using Shop.Endpoint.Models;
using Shop.Endpoint.Models.PeymentSistem;

namespace Shop.Endpoint
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
            services.AddSession();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<Cart>(sp => SessionCart.GetCart(sp));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository,OrderRepository>();
            services.AddScoped<IProductFacade, ProductFacade>();
            services.AddScoped<IOrderFacade, OrderFacade>();
            services.AddScoped<IDPay>();
            services.AddDbContext<ShopContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("shop")));
            services.AddDbContext<ShopEndpointContext>(options =>
                    options.UseSqlServer(
                        Configuration.GetConnectionString("ShopEndpointContextConnection")));

            services.AddIdentity<IdentityUser,IdentityRole>()

                .AddEntityFrameworkStores<ShopEndpointContext>();

            services.Configure<CookiePolicyOptions>(options =>

            { 
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
