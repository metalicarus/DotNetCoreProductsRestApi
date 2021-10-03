using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetRestApi.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Info = Microsoft.OpenApi.Models.OpenApiInfo;

namespace DotNetRestApi
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
            services.AddControllers();
            services.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", new Info {
                    Title = "ProductsApi",
                    Version = "v1"
                });
            });
            
            string mySqlConnection = Configuration.GetConnectionString("MySqlConnection");
            services.AddDbContextPool<MySqlContext>(options => {
               options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)); 
            });


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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(x => {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductsApi v1");
            });
        }
    }
}
