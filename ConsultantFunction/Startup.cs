using System;
using System.Collections.Generic;
using System.Text;
using ConsultantData.Model;
using ConsultantService.Repositories;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(ConsultantFunction.Startup))]
namespace ConsultantFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContext<ConsultantContext>(options =>
            options.UseSqlServer("Server = localhost\\SQLEXPRESS; Database = ConsultantDB; Trusted_Connection = True;"));
            builder.Services.AddScoped<IConsultantRepository, SQLConsultantRepository>();
        }
    }
}
