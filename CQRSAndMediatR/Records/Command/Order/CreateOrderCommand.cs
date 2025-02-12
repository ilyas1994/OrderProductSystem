using MediatR;
using Models;

namespace CQRSAndMediatR.Records.Command.CreateOrder;

public class CreateOrderCommand : IRequest<Guid>
{
    /// <summary>
    /// Id продукта
    /// </summary>
    public Guid ProductInfoId { get; set; }
    /// <summary>
    /// Количество выбранного товара
    /// </summary>
    public uint SelectedQuantity { get; set; } 
}

