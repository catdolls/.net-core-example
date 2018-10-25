using ActivityPost.Infrastructure.Entities.Context;
using ActivityPost.IOC;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace ActivityPost.Api.Extensions
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

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        public static IServiceProvider ConfigureStructureMap(this IServiceCollection services)
        {
            var container = new Container();

            container.Configure(config =>
            {
                config.AddRegistry(new StructuremapRegistry());
                config.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
        }

        public static void ConfigureAzureDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(configuration.GetConnectionString("AzureDbConnection")));
        }
    }
}
