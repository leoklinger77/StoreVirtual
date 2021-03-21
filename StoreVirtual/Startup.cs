using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StoreVirtual.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using StoreVirtual.Repositories.Interfaces;
using StoreVirtual.Repositories;
using StoreVirtual.Service.Session;
using StoreVirtual.Service.Login;

namespace StoreVirtual
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddHttpContextAccessor();

            //Configureação de Session
            services.AddMemoryCache();
            services.AddSession(options => 
            {
                options.Cookie.Name = ".Session";
                options.IdleTimeout = TimeSpan.FromSeconds(3600);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            string connection = "Server=SERVER;Database=StoreVirtual;User Id=Developer;Password=@123Leo;";
            services.AddDbContext<StoreVirtualContext>(options => options.UseSqlServer(connection));

            services.AddScoped<Session>();
            services.AddScoped<LoginCliente>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<INewsLetterEmailRepository, NewsLetterEmailRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            
            
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
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseCookiePolicy(); // Usado para passar o TempData no RedirectToAction
            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();


            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            
        }
    }
}
