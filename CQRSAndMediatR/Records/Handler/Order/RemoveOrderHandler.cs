using CQRSAndMediatR.Records.Command.CreateOrder;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository;

namespace CQRSAndMediatR.Records.Handler.CreateOrder;

public class RemoveOrderHandler : IRequestHandler<RemoveOrderCommand>
{
    private readonly IBaseLogic _baseLogic;

    public RemoveOrderHandler(IBaseLogic baseLogic)
    {
        _baseLogic = baseLogic;
    }

    public async Task Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
    {
        var isExist = await _baseLogic.BaseRepo()
            .GetQueryable<Order>()
            .FirstOrDefaultAsync() ?? throw new Exception($"Не найдена заявка {request.OrderId}");

        isExist.DeleteDate = DateTime.UtcNow;
         _baseLogic.BaseRepo().Update(isExist);
        
        var processHistory = new ProcessHistory()
        {
            OrderId = request.OrderId,
            DeleteDate = DateTime.UtcNow
        };
        _baseLogic.BaseRepo().Add(processHistory);
        await _baseLogic.BaseRepo().SaveChangesAsync();
    }
}