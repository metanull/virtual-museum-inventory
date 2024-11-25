using Microsoft.AspNetCore.Mvc;
using InventoryApi.Models;
namespace InventoryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PartnerController : ControllerBase
{
    private readonly ILogger<PartnerController> _logger;

    public PartnerController(ILogger<PartnerController> logger)
    {
        _logger = logger;
    }

    [HttpGet()]
    [ProducesResponseType<List<Partner>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]   
    public ActionResult<IEnumerable<Partner>> Get()
    {
        var Partners = TestData.AllPartners().ToList();
        if (Partners.Count == 0) {
            return NotFound();
        } else {
            return Ok(Partners);
        }
    }

    [HttpGet("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Partner> Get(Guid Id)
    {
         _logger.LogInformation("Partner({id}) at {time}", Id, DateTime.UtcNow.ToLongTimeString());

        try {
            return Ok(TestData.AllPartners().Where(partner => (partner.Id == Id)).First());
        } catch (InvalidOperationException) {
            return NotFound();
        }
    }

    [HttpGet("{Id}/items")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<Item>> GetItems(Guid Id)
    {
         _logger.LogInformation("Partner({id})/Items at {time}", Id, DateTime.UtcNow.ToLongTimeString());

        try {
            return Ok(TestData.AllItems().Where(item => (item.PartnerId == Id)).ToList());
        } catch (InvalidOperationException) {
            return NotFound();
        }
    }

    [HttpGet("{Id}/items/{ItemId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Item> GetItemById(Guid Id,Guid ItemId)
    {
         _logger.LogInformation("Partner({id})/Items/{ItemId} at {time}", Id, ItemId, DateTime.UtcNow.ToLongTimeString());

        try {
            return Ok(TestData.AllItems().Where(item => (item.PartnerId == Id)).Where(item => (item.Id == ItemId)).First());
        } catch (InvalidOperationException) {
            return NotFound();
        }
    }
}
