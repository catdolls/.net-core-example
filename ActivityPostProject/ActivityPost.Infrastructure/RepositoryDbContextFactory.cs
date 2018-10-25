

using ActivityPost.Infrastructure.Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace ActivityPost.Infrastructure
{
    public class RepositoryDbContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json")
                .Build();
            string connectionString = configuration.GetConnectionString("AzureDbConnection");

            var builder = new DbContextOptionsBuilder<RepositoryContext>();
            builder.UseSqlServer(connectionString);
            return new RepositoryContext(builder.Options);
        }
    }
}
