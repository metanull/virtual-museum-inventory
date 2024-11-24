using Microsoft.AspNetCore.Mvc;
using InventoryApi.Models;
namespace InventoryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
    private readonly ILogger<ItemController> _logger;

    public ItemController(ILogger<ItemController> logger)
    {
        _logger = logger;
    }

    internal IEnumerable<Item> AllItems()
    {
        List<Item> Items = new List<Item>{
            new Item {
                Id = new Guid("fea330f2-302d-4966-959f-d7663e4a4a55"),
                Revision = 1,
                UpdatedDate = null,
                CreatedDate = DateTime.UtcNow,
                Name = "Dummy",
                Description = "This is a dummy item."
            },
            new Item {
                Id = new Guid("510dbe04-5ecd-41bb-b080-a18a3593da00"),
                Revision = 1,
                UpdatedDate = null,
                CreatedDate = DateTime.UtcNow,
                Name = "Crash Test Dummy",
                Description = "This is another dummy item."
            }
        };
        return Items;
    }

    [HttpGet()]
    [ProducesResponseType<List<Item>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]   
    public ActionResult<IEnumerable<Item>> Get()
    {
        var Items = AllItems().ToList();
        if (Items.Count == 0) {
            return NotFound();
        } else {
            return Ok(Items);
        }
    }

    [HttpGet("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Item> Get(Guid Id)
    {
         _logger.LogWarning("Item({id}) at {time}", Id, DateTime.UtcNow.ToLongTimeString());

        try {
            return Ok(AllItems().Where(item => (item.Id == Id)).First());
        } catch (InvalidOperationException) {
            return NotFound();
        }
    }

}
