using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

/// <summary>
/// История заявки, на данный момент отслеживается только пометка на удаление
/// </summary>
public class ProcessHistory : BaseEntity.BaseEntity
{
    [ForeignKey(nameof(OrderId))]
    public Order Order { get; set; }
    public Guid OrderId { get; set; } 
}