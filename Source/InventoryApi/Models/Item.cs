namespace InventoryApi.Models;

/**
    * Represents an Item inside a virtual museum.
    * An item is a single entity in the virtual museum's inventory. They can be further organized into collections.
    */
public class Item : InventoryCommon
{
    public required Guid PartnerId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}