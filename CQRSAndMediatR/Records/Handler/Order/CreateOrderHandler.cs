using CQRSAndMediatR.Records.Command.CreateOrder;
using MediatR;
using Models;
using Repository;

namespace CQRSAndMediatR.Records.Handler.CreateOrder;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IBaseLogic _baseLogic;

    public CreateOrderHandler(IBaseLogic baseLogic)
    {
        _baseLogic = baseLogic;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var newRecord = new Order()
        {
            ProductInfoId = request.ProductInfoId,
            SelectedQuantity = request.SelectedQuantity
        };
        var id =await _baseLogic.BaseRepo().AddAsync(newRecord);
        return id;
    }
}