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

    [HttpGet()]
    [ProducesResponseType<List<Item>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult<IEnumerable<Item>> Get()
    {
        var Items = TestData.AllItems().ToList();
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
         _logger.LogInformation("Item({id}) at {time}", Id, DateTime.UtcNow.ToLongTimeString());

        try {
            return Ok(TestData.AllItems().Where(item => (item.Id == Id)).First());
        } catch (InvalidOperationException) {
            return NotFound();
        }
    }

    [HttpGet("{Id}/partner")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Partner> GetPartner(Guid Id)
    {
         _logger.LogInformation("Item({id})/Partner at {time}", Id, DateTime.UtcNow.ToLongTimeString());

        try {
            return Ok(
                        TestData.AllPartners().Where(
                            partner => (partner.Id == TestData.AllItems().Where(item => (item.Id == Id)).First().PartnerId)
                        ).First()
                    );
        } catch (InvalidOperationException) {
            return NotFound();
        }
    }

    [HttpGet("{Id}/image")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<Image>> GetImage(Guid Id)
    {
         _logger.LogInformation("Item({id})/Image at {time}", Id, DateTime.UtcNow.ToLongTimeString());

        try {
            return Ok(TestData.AllImages().Where(image => (image.ItemId == Id)).ToList());
        } catch (InvalidOperationException) {
            return NotFound();
        }
    }

}
