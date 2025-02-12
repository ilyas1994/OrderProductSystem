using System.ComponentModel.DataAnnotations;

namespace UseCases.Dto;

/// <summary>
/// Обновить количество товара в заявке
/// </summary>
public class UpdateOrderDto
{
    /// <summary>
    /// Id заявки
    /// </summary>
    [Required(ErrorMessage = "Поле OrderId должно быть обязательным")]
    public Guid OrderId { get; set; }
    /// <summary>
    /// Количество выбранного товара
    /// </summary>
    [Required(ErrorMessage = "Поле SelectedQuantity должно быть обязательным")]
    public uint SelectedQuantity { get; set; } 
}