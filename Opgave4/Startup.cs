using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace Opgave4
{
    public class Startup
    {
        public const string AllowAllCorsPolicy = "allowAll";
        public const string AllowOnlyGetCorsPolicy = "allowOnlyGet";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddControllers();

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Opgave4", Version = "v1" });
            //});

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Cars API",
                    Version = "v1",
                    Description = "Test Rest service",
                    Contact = new OpenApiContact
                    {
                        Name = "Laila Matouk",
                        Email = "lail0894@edu.zealand.dk",
                        Url = new Uri("https://www.zealand.dk"),
                    }
                });
                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "Cars API v2",
                    Version = "v2",
                    Description = "Test Rest service 2",
                    Contact = new OpenApiContact
                    {
                        Name = "Laila Matouk",
                        Email = "lail0894@edu.zealand.dk",
                        Url = new Uri("https://www.zealand.dk"),
                    }
                });

                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //options.InCludeXmlComments(xmlPath);
            });

            services.AddCors(options =>
                {
                    options.AddPolicy(AllowAllCorsPolicy,
                        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                    options.AddPolicy(AllowOnlyGetCorsPolicy,
                        policy => policy.AllowAnyOrigin().WithMethods("GET").AllowAnyHeader());
                }
            );
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger v1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "Swagger v2");
            });


            app.UseRouting();

            app.UseCors("AllowAllCorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            //app.UseSwagger();

            //app.UseSwaggerUI(c =>
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Items API v1.0")
            //);

        }
    }
}
