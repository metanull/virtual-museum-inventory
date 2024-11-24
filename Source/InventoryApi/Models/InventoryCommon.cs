namespace InventoryApi.Models;

/**
    * Describes the common columns found in all tables of the inventory database.
    */
public abstract class InventoryCommon
{
    public required Guid Id { get; set; }
    public required int Revision { get; set; } = 1;
    public DateTime ?UpdatedDate { get; set; } = null;
    public required DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}