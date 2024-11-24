using Microsoft.AspNetCore.Mvc;
using InventoryApi.Models;
namespace InventoryApi.Controllers;

[ApiController]
[Route("[controller]")]
public class VirtualMuseumController : ControllerBase
{
    private readonly ILogger<VirtualMuseumController> _logger;

    public VirtualMuseumController(ILogger<VirtualMuseumController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetVirtualMuseum")]
    public IEnumerable<VirtualMuseum> Get()
    {
        return Enumerable.Range(1, 1).Select(index => new VirtualMuseum
        {
            Id = new Guid("00000000-0000-0000-0000-000000000000"),
            Revision = 1,
            UpdatedDate = null,
            CreatedDate = DateTime.UtcNow,
            Name = "Default",
            Description = "Default virtual museum. A virtual museum is a digital entity that is used as a 'container' or 'context' for all the items in one virtual museum."
        })
        .ToArray();
    }
}
