namespace InventoryApi.Models;

/**
    * Represents a Partner of virtual museums.
    * Partners participate in the elaboration of the Virtual Museum collection and/or provide items to the collection
    */
public class Partner : InventoryCommon
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}