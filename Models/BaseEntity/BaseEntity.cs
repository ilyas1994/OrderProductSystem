namespace Models.BaseEntity;

/// <summary>
/// Общие свойства для таблиц
/// </summary>
public class BaseEntity
{
    /// <summary>
    /// Уникальный идинтификатор
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Пометка даты удаления
    /// </summary>
    public DateTime? DeleteDate { get; set; } = null;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}