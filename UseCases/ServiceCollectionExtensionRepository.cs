using Microsoft.Extensions.DependencyInjection;
using Models;
using Models.BaseEntity;
using UseCases.interfaces;

namespace UseCases;

    // Подключаем di прямиком в библиотеке классов
    public static class ServiceCollectionExtensionRepository
    {
        public static IServiceCollection UseCasesPackageDi(this IServiceCollection services)
        {
            services.AddTransient<IOrders, Orders>();
            return services;
        }
    }

