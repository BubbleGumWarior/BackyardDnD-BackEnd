using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackyardDnD_BackEnd.Database;
using BackyardDnD_BackEnd.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BackyardDnD_BackEnd
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => 
                options.AddPolicy("MyPolicy", a => a.WithOrigins("http://localhost:5000")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "BackyardDnd", Version = "v1"});
            });
            
            //database
            services.AddScoped<DatabaseHelper>();
            services.AddScoped<Converter>();
            
            
            //Repositories
            services.AddScoped<IUserInterface,UserRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors(options =>
                    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                /*options.WithOrigins('domain adress', 'second domain').AllowAnyMethod().AllowAnyHeader());*/
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BackyardDndApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors("MyPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
            
        }
    }
}