using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class ProductInfo : BaseEntity.BaseEntity
{
    [ForeignKey(nameof(DicProductsId))]
    public DicProducts DicProducts { get; set; }
    public Guid DicProductsId { get; set; }
    /// <summary>
    /// Количество товара на складе
    /// </summary>
    public uint Count { get; set; }
}