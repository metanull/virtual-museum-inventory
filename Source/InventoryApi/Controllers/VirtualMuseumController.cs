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

    internal IEnumerable<VirtualMuseum> AllVirtualMuseums()
    {
        List<VirtualMuseum> VirtualMuseums = new List<VirtualMuseum>{
            new VirtualMuseum {
                Id = new Guid("00000000-0000-0000-0000-000000000000"),
                Revision = 1,
                UpdatedDate = null,
                CreatedDate = DateTime.UtcNow,
                Name = "Museum With No Frontiers",
            Description = "This is the default Virtual Museum context, it holds Items and VirtualMuseums that are not categorized yet."
            },
            new VirtualMuseum {
                Id = new Guid("701c9051-37a8-45cf-9cca-a0f6f98ecef3"),
                Revision = 1,
                UpdatedDate = null,
                CreatedDate = DateTime.UtcNow,
                Name = "Discover Islamic Art",
                Description = "Discover ISlamic Art is the first Virtual Museum ever created by Museum With No Frontiers, in 2004."
            }
        };
        return VirtualMuseums;
    }

    [HttpGet()]
    [ProducesResponseType<List<VirtualMuseum>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]   
    public ActionResult<IEnumerable<VirtualMuseum>> Get()
    {
        var VirtualMuseums = AllVirtualMuseums().ToList();
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
         _logger.LogWarning("VirtualMuseum({id}) at {time}", Id, DateTime.UtcNow.ToLongTimeString());

        try {
            return Ok(AllVirtualMuseums().Where(virtualMuseum => (virtualMuseum.Id == Id)).First());
        } catch (InvalidOperationException) {
            return NotFound();
        }
    }
}
