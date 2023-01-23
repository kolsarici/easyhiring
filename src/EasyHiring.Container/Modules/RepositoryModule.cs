using System.Reflection;
using Autofac;
using EasyHiring.Repository;
using EasyHiring.Repository.Maps;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyHiring.Container.Modules;

public class RepositoryModule : Autofac.Module
{
    public static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {            
        MongoDomainMapsRegistrar.RegisterDocumentMaps(Assembly.GetAssembly(typeof(QuestionRepository)));
            
        services.Configure<MongoDbSettings>(options =>
        {
            options.ConnectionString = configuration
                .GetSection(nameof(MongoDbSettings) + ":" + MongoDbSettings.ConnectionStringValue).Value;
            options.Database = configuration
                .GetSection(nameof(MongoDbSettings) + ":" + MongoDbSettings.DatabaseValue).Value;
        });
    }

    protected override void Load(ContainerBuilder builder)
    {
        var assemblyType = typeof(QuestionRepository).GetTypeInfo();

        builder.RegisterAssemblyTypes(assemblyType.Assembly)
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        base.Load(builder);
    }
}