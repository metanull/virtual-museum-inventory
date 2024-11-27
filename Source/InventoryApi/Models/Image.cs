namespace InventoryApi.Models;

/**
    * Represents an Image inside a virtual museum.
    * Items may have any number of Image attached.
    */
public class Image : InventoryCommon
{
    public required Guid ItemId { get; set; }
    public required Guid FileId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}