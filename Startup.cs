﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using myfirstdotnetcore.Data;
using myfirstdotnetcore.Services;

namespace myfirstdotnetcore
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ISample, Sample>();
            services.AddDbContext<MovieDbContext>(
                options => options.UseSqlServer(_configuration.GetConnectionString("Movie")));
            services.AddScoped<IMovie, SqlMovieData>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ISample sample)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvc(configureRoutes);
            

            app.Run(async (context) =>
            {
                var name = sample.GetName();
                await context.Response.WriteAsync($"{name}:{env.EnvironmentName}");
            });
        }

        private void configureRoutes(IRouteBuilder routes)
        {
            routes.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
