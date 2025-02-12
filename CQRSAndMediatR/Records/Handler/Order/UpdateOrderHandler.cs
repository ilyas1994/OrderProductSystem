using CQRSAndMediatR.Records.Command.CreateOrder;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository;

namespace CQRSAndMediatR.Records.Handler.CreateOrder;

public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand>
{
    private readonly IBaseLogic _baseLogic;

    public UpdateOrderHandler(IBaseLogic baseLogic)
    {
        _baseLogic = baseLogic;
    }

    public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var isExistRecorrd = await _baseLogic.BaseRepo().GetQueryable<Order>()
            .Where(x => x.Id == request.OrderId)
            .FirstOrDefaultAsync();
        
        isExistRecorrd.SelectedQuantity = request.SelectedQuantity;
        await _baseLogic.BaseRepo().UpdateAsync(isExistRecorrd);
    }
}