using Microsoft.EntityFrameworkCore;
using Models;
using Models.BaseEntity;

namespace DataBase;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public AppDbContext()
    {
            
    }
    public DbSet<DicProducts> DicProducs { get; set; }
    public DbSet<ProductInfo> ProductInfo { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<ProcessHistory> ProcessHistory { get; set; }
}