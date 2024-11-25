using Microsoft.AspNetCore.Mvc;
using InventoryApi.Models;
namespace InventoryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VirtualMuseumController : ControllerBase
{
    private readonly ILogger<VirtualMuseumController> _logger;

    public VirtualMuseumController(ILogger<VirtualMuseumController> logger)
    {
        _logger = logger;
    }

    [HttpGet()]
    [ProducesResponseType<List<VirtualMuseum>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]   
    public ActionResult<IEnumerable<VirtualMuseum>> Get()
    {
        var VirtualMuseums = TestData.AllVirtualMuseums().ToList();
        if (VirtualMuseums.Count == 0) {
            return NotFound();
        } else {
            return Ok(VirtualMuseums);
        }
    }

    [HttpGet("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<VirtualMuseum> Get(Guid Id)
    {
         _logger.LogInformation("VirtualMuseum({id}) at {time}", Id, DateTime.UtcNow.ToLongTimeString());

        try {
            return Ok(TestData.AllVirtualMuseums().Where(virtualMuseum => (virtualMuseum.Id == Id)).First());
        } catch (InvalidOperationException) {
            return NotFound();
        }
    }
}
