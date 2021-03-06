using ExceptionLoggerMIddlware.Models;
using ExceptionLoggerMIddlware.Services;
using ExceptionLoggerMIddlware.Services.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scoring.ApplicationServices.Mappers;
using Scoring.CoreServices.Repositories;
using Scoring.CoreServices.Repositories.Abstractions;
using Scoring.DatabaseEntity.DB;
using System;
using System.Net;

namespace Scoring.View
{
    public static class ExceptionHandlerExtencion
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogService logger)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async errorContext =>
                {
                    errorContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorContext.Response.ContentType = "application/json";
                    var contextFeature = errorContext.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.Error($"Something went wrong: {contextFeature.Error}");

                        await errorContext.Response.WriteAsync(new ErrorInformation()
                        {
                            StatusCode = errorContext.Response.StatusCode,
                            Message = "Internal Server Error. Error generated by NLog!"
                        }.ToString());
                    }

                });
            });
        }
    }

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
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton<ILogService, LogService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddAutoMapper(typeof(ObjectMapper));

            var assembly = AppDomain.CurrentDomain.Load("Scoring.ApplicationServices");
            services.AddMediatR(assembly);

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogService logger)
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
            app.ConfigureExceptionHandler(logger);
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
