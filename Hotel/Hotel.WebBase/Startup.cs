using Hotel.Entities;
using Hotel.Repository;
using HTActive.Core.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.WebBase
{
    public static class StartupWebBase
    {
        public static void ConfigureService(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAuthentication()
                .AddFacebook(facebookOptions =>
                {
                    facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                    facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                    facebookOptions.SignInScheme = "ExternalCookiesAuthentication";
                    //facebookOptions.Events = new CustomOAuthEvents();
                })
                .AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
                    googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                    googleOptions.SignInScheme = "ExternalCookiesAuthentication";
                });
            services.AddMvc();
            //services.AddScoped<IAuthorizationHandler, HTAuthorizationHandler>();
            services.AddScoped(opt =>
            {
                var optionBuilder = new DbContextOptionsBuilder<InstanceEntities>();
                optionBuilder.UseSqlServer(Configuration.GetConnectionString("InstanceConnection"),
                b => b.MigrationsAssembly("Hotel.Web01"));
                return optionBuilder.Options;
            });
            services.AddScoped<InstanceEntities>();
            services.AddScoped<InstanceUnitOfWork>();
            services.AddScoped<InstanceRepository>();
            services.AddScoped<IBaseUnitOfWork<InstanceEntities>, InstanceUnitOfWork>();
            RegisterServiceHelper.RegisterRepository(services);
        }

        public static void Configure(IApplicationBuilder app, IHostingEnvironment env, IConfiguration Configuration)
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

            app.UseMvc(routes =>
            {
                routes.MapRoute("home", "{cc:regex(^(c_)\\w{{4}}$)}", new
                {
                    controller = "Home",
                    action = "Index"
                });
                
            });
        }
    }
}
