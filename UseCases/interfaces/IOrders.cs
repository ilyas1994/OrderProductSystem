using Models;
using UseCases.Dto;

namespace UseCases.interfaces;

public interface IOrders
{
    public Task<IEnumerable<Order>> GetAllOrdersLogic();
    public Task<IEnumerable<DicProducts>> GetAllProductsLogic();
    public Task<Guid> CreateOrder(CreateOrderDto dto);
    public Task UpdateOrder(UpdateOrderDto dto);
    public Task RemoveOrder(Guid Id);
    public Task RecoveryOrder(Guid Id);
}