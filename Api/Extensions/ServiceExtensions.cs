using Contracts;
using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureNpgSqlContext(this IServiceCollection services, IConfiguration config)
        {
            //var connectionString = config["ConnectionStrings:DataAccessPostgreSqlProvider"];

            //services.AddDbContext<RepositoryContext>(o => o.UseNpgsql(connectionString));

            var host = config["DBHOST"] ?? "localhost";
            var port = config["DBPORT"] ?? "5432";
            var password = config["DBPASSWORD"] ?? "postgres";

            services.AddDbContext<RepositoryContext>(o => o.UseNpgsql($"userid=postgres;password={password};host={host};port={port};database=dockertutorial;"));
        }
        
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
