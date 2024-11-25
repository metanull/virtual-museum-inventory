namespace InventoryApi.Models;

/**
    * Represents a virtual museum.
    * It is the parent context for all the items in the virtual museum's inventory.
    */
public class VirtualMuseum : InventoryCommon
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}