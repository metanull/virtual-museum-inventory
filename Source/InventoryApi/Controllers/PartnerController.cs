using Microsoft.AspNetCore.Mvc;
using InventoryApi.Models;
namespace InventoryApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PartnerController : ControllerBase
{
    private readonly ILogger<PartnerController> _logger;

    public PartnerController(ILogger<PartnerController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetPartner")]
    public IEnumerable<Partner> Get()
    {
        return Enumerable.Range(1, 1).Select(index => new Partner
        {
            Id = new Guid("00000000-0000-0000-0000-000000000000"),
            Revision = 1,
            UpdatedDate = null,
            CreatedDate = DateTime.UtcNow,
            Name = "Museum With No Frontiers",
            Description = "This is the default Partner, representing the MWNF association itself; it holds Items who's rights have been transferred to MWNF by the owner."
        })
        .ToArray();
    }
}
