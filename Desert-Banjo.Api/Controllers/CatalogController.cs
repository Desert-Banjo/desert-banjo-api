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
            return Ok("hello world.");
        }
    }
}