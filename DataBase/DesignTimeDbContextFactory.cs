using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DataBase;

// Данный класс служит для выполнения команд миграции
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../OrderProductSystem"));

        // Создаем конфигурацию
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(basePath) // Указываем базовый путь
            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true) // Загружаем файл конфигурации
            .Build();   

        // Получаем строку подключения
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        // Настраиваем DbContextOptions
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new AppDbContext(optionsBuilder.Options);
    }
}