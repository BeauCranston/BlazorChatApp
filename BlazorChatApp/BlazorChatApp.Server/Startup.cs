using BlazorChatApp.Server.Persistence.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChatApp.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public string myAllowedOrigins = "_myAllowedOrigins";
        public void ConfigureServices(IServiceCollection services)
        {
            var _dbConnection = Configuration["Database:ConnectionString"];
            services.AddControllers();
            services.AddScoped<IConfiguration>();
            services.AddCors(options =>
            {
                options.AddPolicy(name: myAllowedOrigins, builder =>
                {
                    builder.WithOrigins("https://localhost:5001", "http://localhost:5000").AllowAnyHeader().AllowAnyMethod();
                });
            });
            services.AddDbContext<BlazorChatDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors(myAllowedOrigins);
            });
            
        }
    }
}
