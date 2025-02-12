using DataBase;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository;

namespace Seed;

public class Seed
{
    private AppDbContext _dbContext;

    public Seed(AppDbContext context)
    {
        _dbContext = context;
    }

    public async Task Initialize()
    {
        await SeedDicProducts();
        await SeedProductInfo();
    }

    private async Task SeedDicProducts()
    {
     
        if (!_dbContext.DicProducs.Any())
        {
            _dbContext.DicProducs.AddRange(
                new DicProducts() { Name = "Хлеб" },
                new DicProducts() { Name = "Молоко", },
                new DicProducts() { Name = "Кефир" },
                new DicProducts() { Name = "Сыр" }
                );
            await _dbContext.SaveChangesAsync();
        }
    }
    private async Task SeedProductInfo()
    {
        var getAllDicProducts = await _dbContext.DicProducs.ToListAsync();
        var getAllProductInfo = await _dbContext.ProductInfo.ToListAsync();
        var list = new List<ProductInfo>();
        var random = new Random();
        if (getAllDicProducts.Any() && !getAllProductInfo.Any())
        {
            foreach (var item in getAllDicProducts)
            {
                      list.Add(new ProductInfo()
                      {
                          DicProductsId = item.Id,
                          Count = (uint)random.Next(3, 11)
                      });
            }

            await _dbContext.AddRangeAsync(list);
            await _dbContext.SaveChangesAsync();

        }
    }
}