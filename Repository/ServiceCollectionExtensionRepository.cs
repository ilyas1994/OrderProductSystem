using Microsoft.Extensions.DependencyInjection;
using Models.BaseEntity;

namespace Repository;

    // Подключаем di прямиком в библиотеке классов
    public static class ServiceCollectionExtensionRepository
    {
        public static IServiceCollection RepositoryPackageDi(this IServiceCollection services)
        {
            services.AddScoped<IRepository<BaseEntity>, Repository<BaseEntity>>();
            services.AddScoped<IBaseLogic, BaseLogic>();
            return services;
        }
    }

