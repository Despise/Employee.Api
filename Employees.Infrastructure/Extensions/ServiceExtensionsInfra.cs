using Employees.Domain.Interfaces;
using Employees.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Employees.Infrastructure.Extensions
{
    public static class ServiceExtensionsInfra
    {
        public static void AddInfrastructureLayer(this IServiceCollection services) {
            services.AddTransient<IEmployee, EmployeeRepository>();
            services.AddControllers().AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });
        }
    }
}
