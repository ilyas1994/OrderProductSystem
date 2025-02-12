using System.ComponentModel.DataAnnotations;

namespace UseCases.Dto;

/// <summary>
/// Создать заказ
/// </summary>
public class CreateOrderDto
{
    /// <summary>
    /// Id продукта
    /// </summary>
    [Required(ErrorMessage = "Поле ProductInfoId должно быть обязательным")]
    public Guid ProductInfoId { get; set; }
    /// <summary>
    /// Количество выбранного товара
    /// </summary>
    [Required(ErrorMessage = "Поле SelectedQuantity должно быть обязательным")]
    public uint SelectedQuantity { get; set; } 
}