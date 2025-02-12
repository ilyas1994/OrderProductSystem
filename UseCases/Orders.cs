using CQRSAndMediatR.Read;
using CQRSAndMediatR.Read.Handler;
using CQRSAndMediatR.Records.Command.CreateOrder;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository;
using UseCases.Dto;
using UseCases.interfaces;
using Exception = System.Exception;

namespace UseCases;

public class Orders : IOrders
{
    private readonly IBaseLogic _baseLogic;
    private IMediator _mediator;

    public Orders(IMediator mediator, IBaseLogic baseLogic)
    {
        _mediator = mediator;
        _baseLogic = baseLogic;
    }

    public async Task<IEnumerable<Order>> GetAllOrdersLogic()
    {
        var data = await _mediator.Send(new GetAllOrdersQuery());
        return data ?? throw new Exception("Заказов еще нет");
    }

    public async Task<IEnumerable<DicProducts>> GetAllProductsLogic()
    {
        var data = await _mediator.Send(new GetAllProductsQuery());
        return data ?? throw new Exception("Продукты еще не были добавлены");
    }

    public async Task<Guid> CreateOrder(CreateOrderDto dto)
    {
        await BasicValidation(dto.ProductInfoId, dto.SelectedQuantity);
        var command = new CreateOrderCommand()
        {
            ProductInfoId = dto.ProductInfoId,
            SelectedQuantity = dto.SelectedQuantity
        };
        
        var record = await _mediator.Send(command);
        return record;

    }

    public async Task UpdateOrder(UpdateOrderDto dto)
    {
        var isExistProductInfo = await _baseLogic.BaseRepo().GetQueryable<Models.Order>()
            .Where(x => x.Id == dto.OrderId)
            .FirstOrDefaultAsync() ?? throw new Exception("Данная заявка отсутствует");
        var command = new UpdateOrderCommand()
        {
            OrderId = dto.OrderId,
            SelectedQuantity = dto.SelectedQuantity
        };
        await _mediator.Send(command);
    }
    
    public async Task RemoveOrder(Guid Id)
    {
        var command = new RemoveOrderCommand()
        {
            OrderId = Id
        };
        await _mediator.Send(command);
    }

    public async Task RecoveryOrder(Guid Id)
    {
        var isExist = await _baseLogic.BaseRepo()
            .GetQueryable<Order>()
            .Where(x => x.Id == Id)
            .FirstOrDefaultAsync() ?? throw new Exception("Заказ не найден");

        var command = new RecoveryOrderCommand()
        {
            OrderId = Id
        };
        await _mediator.Send(command);
    }

    private async Task BasicValidation(Guid productInfoId, uint selectedQuantity)
    {
        var isExistProductInfo = await _baseLogic.BaseRepo().GetQueryable<Models.ProductInfo>()
            .Where(x => x.Id == productInfoId)
            .FirstOrDefaultAsync() ?? throw new Exception("Данный продукт отсутствует");
        
        if (selectedQuantity == 0 || selectedQuantity > int.MaxValue) throw new Exception("Количество товара имеет недопустимые значения");
    }
    
   
}
