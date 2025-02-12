using MediatR;

namespace CQRSAndMediatR.Records.Command.CreateOrder;

public class RecoveryOrderCommand : IRequest
{
    /// <summary>
    /// Id заказа
    /// </summary>
    public Guid OrderId { get; set; }
}