using CupcakeShop.Core.DTOs;
using CupcakeShop.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CupcakeShop.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IBestsellersService _bestsellersService;

        public ProductController(IBestsellersService bestsellersService)
        {
            _bestsellersService = bestsellersService;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<ShortProductInfoDTO>))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Get bestsellers")]

        public async Task<IActionResult> GetBestsellers()
        {
            var result = await _bestsellersService.GetBestsellrsAsync();
            return Ok(result);

        }
    }
}
