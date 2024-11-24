namespace InventoryApi;

/**
    * Represents a virtual museum.
    * It is the parent context for all the items in the virtual museum's inventory.
    */
public class VirtualMuseum
{
    public Guid Id { get; set; }
    public int Revision { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime CreatedDate { get; set; }

    public required string Name { get; set; }
    public string? Description { get; set; }
}