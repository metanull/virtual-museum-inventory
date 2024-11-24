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
            Name = "Museum With No Frontiers",
            Description = "This is the default Virtual Museum context, it holds Items and Partners that are not categorized yet."
        })
        .ToArray();
    }
}
