using CQRSAndMediatR;
using CQRSAndMediatR.Read;
using CQRSAndMediatR.Read.Handler;
using DataBase;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.BaseEntity;
using Repository;
using UseCases;

var builder = WebApplication.CreateBuilder(args);

// Подключение appsetings в зависимости от окружения, development, Test, Production
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Добавляем услуги в контейнер
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Подключаем DI зависимости из библиотеки классов
builder.Services.RepositoryPackageDi();
builder.Services.CqrsAndMediatRPackageDi(typeof(Program).Assembly);
builder.Services.UseCasesPackageDi();


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Заполнение базы данных начальными данными при запуске приложения
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    var seedInitilization = new Seed.Seed(context);
    await seedInitilization.Initialize();
}


app.Run();