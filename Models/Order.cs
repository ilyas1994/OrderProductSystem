using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

/// <summary>
/// Заказы
/// </summary>
public class Order : BaseEntity.BaseEntity
{
    [ForeignKey(nameof(ProductInfoId))]
    public ProductInfo ProductInfo { get; set; }
    /// <summary>
    /// Информация о товаре
    /// </summary>
    public Guid ProductInfoId { get; set; }
    /// <summary>
    /// Количество выбранного товара
    /// </summary>
    public uint SelectedQuantity { get; set; }
}