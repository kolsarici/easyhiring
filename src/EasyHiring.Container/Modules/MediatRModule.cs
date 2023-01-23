using System.Reflection;
using Autofac;
using EasyHiring.ApiContract.Request.Query;
using EasyHiring.ApplicationService.Handler.Query;
using MediatR;

namespace EasyHiring.Container.Modules;

public class MediatRModule: Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();
        
        builder.Register<ServiceFactory>(ctx =>
        {
            var c = ctx.Resolve<IComponentContext>();
            return t => c.Resolve(t);
        });
            
        builder.RegisterAssemblyTypes(typeof(GetQuestionListQuery).Assembly) 
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(typeof(GetQuestionListQueryHandler).Assembly)
            .AsClosedTypesOf(typeof(IRequestHandler<,>))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
        
        //builder.RegisterGeneric(typeof(ExceptionHandler<,>)).As(typeof(IPipelineBehavior<,>));
            
        base.Load(builder);
    }
}