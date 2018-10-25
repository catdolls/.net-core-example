using ActivityPost.Core.Contracts.Logger;
using ActivityPost.Core.Contracts.Repositories;
using ActivityPost.Core.Contracts.Services;
using ActivityPost.Infrastructure.Entities.Context;
using ActivityPost.Infrastructure.Entities.Repositories;
using ActivityPost.Infrastructure.Logger;
using ActivityPost.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StructureMap;
using StructureMap.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;

namespace ActivityPost.IOC
{
    public class StructuremapRegistry : Registry
    {
        public StructuremapRegistry()
        {
            //DB Context
            For<DbContextOptions<RepositoryContext>>().Use("Context Options For Content Db", container =>
            {
                IConfiguration configuration = container.GetInstance<IConfiguration>();
                var dbContextBuilder = new DbContextOptionsBuilder<RepositoryContext>().UseSqlServer(configuration.GetConnectionString("AzureDbConnection"));
                return dbContextBuilder.Options;
            });

            //Logger
            For<ILoggerManager>().LifecycleIs(Lifecycles.Container).Use<LoggerManager>();

            //Repository
            For<IPostRepository>().Use<PostRepository>().Named("InitPostRepository").ContainerScoped();
            For<IRepositoryWrapper>().Use<RepositoryWrapper>().ContainerScoped();

            //Service
            For<IPostService>().Use<PostService>().ContainerScoped();
        }
    }
}
