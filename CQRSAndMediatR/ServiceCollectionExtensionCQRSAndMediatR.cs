using System.Reflection;
using CQRSAndMediatR.Read;
using CQRSAndMediatR.Read.Handler;
using CQRSAndMediatR.Records.Command.CreateOrder;
using CQRSAndMediatR.Records.Handler.CreateOrder;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Repository;
using ProductInfo = Microsoft.EntityFrameworkCore.Infrastructure.ProductInfo;

namespace CQRSAndMediatR;

public static class ServiceCollectionExtensionCQRSAndMediatR
{
    public static IServiceCollection CqrsAndMediatRPackageDi(this IServiceCollection services, Assembly assembly)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddScoped<IBaseLogic, BaseLogic>();
        // READ
        services.AddTransient<IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>, GetAllOrdersHandler>();
        services.AddTransient<IRequestHandler<GetAllProductsQuery, IEnumerable<DicProducts>>, GetAllProductsHandler>();
        // RECORDS
        services.AddTransient<IRequestHandler<CreateOrderCommand, Guid>, CreateOrderHandler>();
        services.AddTransient<IRequestHandler<UpdateOrderCommand>, UpdateOrderHandler>();
        services.AddTransient<IRequestHandler<RemoveOrderCommand>, RemoveOrderHandler>();
        services.AddTransient<IRequestHandler<RecoveryOrderCommand>, RecoveryOrderHandler>();
        
        
        return services;
    }
}