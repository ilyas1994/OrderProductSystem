using CQRSAndMediatR.Records.Command.CreateOrder;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository;

namespace CQRSAndMediatR.Records.Handler.CreateOrder;

public class RecoveryOrderHandler : IRequestHandler<RecoveryOrderCommand>
{
    private readonly IBaseLogic _baseLogic;

    public RecoveryOrderHandler(IBaseLogic baseLogic)
    {
        _baseLogic = baseLogic;
    }

    public async Task Handle(RecoveryOrderCommand request, CancellationToken cancellationToken)
    {
        var data = await _baseLogic.BaseRepo()
            .GetQueryable<Order>()
            .Where(x => x.Id == request.OrderId && x.DeleteDate != null)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        data.DeleteDate = null;
        await _baseLogic.BaseRepo().UpdateAsync(data);
    }
}