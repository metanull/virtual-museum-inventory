using Microsoft.AspNetCore.Mvc;
using InventoryApi.Models;
namespace InventoryApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private readonly ILogger<ItemController> _logger;

    public ItemController(ILogger<ItemController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetItem")]
    public IEnumerable<Item> Get()
    {
        return Enumerable.Range(1, 1).Select(index => new Item
        {
            Id = new Guid("00000000-0000-0000-0000-000000000000"),
            Revision = 1,
            UpdatedDate = null,
            CreatedDate = DateTime.UtcNow,
            Name = "Dummy",
            Description = "This is a dummy item."
        })
        .ToArray();
    }
}
