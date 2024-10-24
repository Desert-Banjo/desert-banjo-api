using Microsoft.AspNetCore.Mvc;
using Desert.Banjo.Domain.Catalog;

namespace Desert.Banjo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetItems()
        {
        var items = new List<Item>()
        {
            new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m),
            new Item("Shorts", "Ohio State shorts.", "NIke", 44.99m)
        
        };
    return Ok(items);
        }
    }
 }