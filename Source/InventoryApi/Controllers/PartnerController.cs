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

    internal IEnumerable<Partner> AllPartners()
    {
        List<Partner> Partners = new List<Partner>{
            new Partner {
                Id = new Guid("ede4f63f-7e12-4829-a76c-a687a6f1d505"),
                Revision = 1,
                UpdatedDate = null,
                CreatedDate = DateTime.UtcNow,
                Name = "Museum With No Frontiers",
                Description = "This is the default Partner, representing the MWNF association itself; it holds Items who's rights have been transferred to MWNF by the owner."
            },
            new Partner {
                Id = new Guid("bf7e42e5-8491-4f36-90d8-c547bde4fd6f"),
                Revision = 1,
                UpdatedDate = null,
                CreatedDate = DateTime.UtcNow,
                Name = "Pascal Havelange",
                Description = "A voluntary partners that contributes with code, and not with items."
            }
        };
        return Partners;
    }

    [HttpGet()]
    [ProducesResponseType<List<Partner>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]   
    public ActionResult<IEnumerable<Partner>> Get()
    {
        var Partners = AllPartners().ToList();
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
         _logger.LogWarning("Partner({id}) at {time}", Id, DateTime.UtcNow.ToLongTimeString());

        try {
            return Ok(AllPartners().Where(partner => (partner.Id == Id)).First());
        } catch (InvalidOperationException) {
            return NotFound();
        }
    }
}
