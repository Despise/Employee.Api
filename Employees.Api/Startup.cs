using Employees.Application.Extensions;
using Employees.Infrastructure.Extensions;
using Employees.Infrastructure.Persistencia;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Employees.Api
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
            //services.AddControllers().AddFluentValidation(options =>
            //{
            //    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            //});

            //services.AddControllers();


            // Configuración de automapper obtiene los ensamblados para buscar los profile 
           // services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Inyección de dependencias <Interface, ClaseRepo>
            //services.AddTransient<IEmployee, EmployeeRepository>(); SE CAMBIA A INFRASTRUCTURE

            //var hcBuilder = services.AddHealthChecks();
            //hcBuilder.AddCheck("self", () => HealthCheckResult.Healthy());
            //hcBuilder.AddDbContextCheck<EmployeeContext>(typeof(EmployeeContext).Name);

            //services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EmployeeDB")));

            services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:EmployeeDB"]));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Employee API",
                    Description = "Employee ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Guillermo Segura S.",
                        Email = "gsegura.s@hotmail.com",
                        Url = new Uri("https://www.my-web.com"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });


            //services.AddMediatR(typeof(Startup));
            //services.AddMediatR(Assembly.Load("Employees.Aplication"));
            //services.AddMediatR(Assembly.GetExecutingAssembly()); // Si Funciona pero da error en controller
            //services.AddMediatR(typeof(GetEmployeesListQueryHandler).GetTypeInfo().Assembly); // Funciona al 100%
            services.AddApplicationLayer();
            services.AddInfrastructureLayer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
              .AllowAnyHeader()
              .AllowAnyMethod()
              .SetIsOriginAllowed((host) => true)
              .AllowCredentials()
              );

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Employee V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
