﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.Jwt;
using ProjectSetupV2.Models.Context;
using System;

namespace ProjectSetupV2
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<DBProjectSetupContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBProjectSetup")));

            //services.AddAuthentication(NetCoreJwtDefaults.SchemeName).AddNetCoreJwt();
            services.AddAuthentication().AddNetCoreJwt(options => {
                options.Expiary = TimeSpan.FromHours(1);
                options.Secret = "48ty390yt5h3wosilrghnberolighnjwoligtnjloi4kjtm223";
                // long random string. only if you put this, even after restarting the api the JWT will be valid
            });

            services.AddDefaultIdentity<User>().AddEntityFrameworkStores<DBProjectSetupContext>().AddDefaultUI();
            services.AddMvc()
            .AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling =
            Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Timesheets}/{action=Index}/{id?}");
            });
        }
    }
}
