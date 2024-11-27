using Microsoft.AspNetCore.Mvc;
using InventoryApi.Models;
namespace InventoryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImageController : ControllerBase
{
    private readonly ILogger<ImageController> _logger;

    public ImageController(ILogger<ImageController> logger)
    {
        _logger = logger;
    }

    [HttpGet()]
    [ProducesResponseType<List<Image>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult<IEnumerable<Image>> Get()
    {
        var Images = TestData.AllImages().ToList();
        if (Images.Count == 0) {
            return NotFound();
        } else {
            return Ok(Images);
        }
    }

    [HttpGet("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Image> Get(Guid Id)
    {
         _logger.LogInformation("Image({id}) at {time}", Id, DateTime.UtcNow.ToLongTimeString());

        try {
            return Ok(TestData.AllImages().Where(image => (image.Id == Id)).First());
        } catch (InvalidOperationException) {
            return NotFound();
        }
    }

    [HttpGet("{Id}/item")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Partner> GetPartner(Guid Id)
    {
         _logger.LogInformation("Image({id})/Item at {time}", Id, DateTime.UtcNow.ToLongTimeString());

        try {
            return Ok(
                        TestData.AllItems().Where(
                            item => (item.Id == TestData.AllImages().Where(image => (image.Id == Id)).First().ItemId)
                        ).First()
                    );
        } catch (InvalidOperationException) {
            return NotFound();
        }
    }

}
