using MediatR;

namespace CQRSAndMediatR.Records.Command.CreateOrder;

public class UpdateOrderCommand : IRequest
{
    /// <summary>
    /// Id заявки
    /// </summary>
    public Guid OrderId { get; set; }
    /// <summary>
    /// Количество выбранного товара
    /// </summary>
    public uint SelectedQuantity { get; set; } 
}