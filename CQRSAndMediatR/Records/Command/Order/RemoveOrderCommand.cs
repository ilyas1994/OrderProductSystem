using CQRSAndMediatR.Records.Handler.CreateOrder;
using MediatR;

namespace CQRSAndMediatR.Records.Command.CreateOrder;

public class RemoveOrderCommand : IRequest
{
    /// <summary>
    /// Id заказа
    /// </summary>
    public Guid OrderId { get; set; }
}