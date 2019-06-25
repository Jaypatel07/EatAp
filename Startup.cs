using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EatAp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace EatAp {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.Configure<CookiePolicyOptions> (options => {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDefaultIdentity<IdentityUser> ()
                .AddDefaultUI()
                .AddEntityFrameworkStores<Context> ();
            services.AddAuthentication ().AddFacebook (facebookOptions => {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });
            services.AddDbContext<Context> (options => options.UseMySql (Configuration["DBInfo:ConnectionString"]));
            services.AddSession ();
            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_1);
        }

        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseExceptionHandler ("/Home/Error");
            }

            app.UseStaticFiles ();
            app.UseCookiePolicy ();
            app.UseSession ();
            app.UseMvc (routes => {
                routes.MapRoute (
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        
    }
}