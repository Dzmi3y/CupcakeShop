using CupcakeShop.Core.DTOs;
using CupcakeShop.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CupcakeShop.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _bestsellersService;

        public ProductController(IProductService bestsellersService)
        {
            _bestsellersService = bestsellersService;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<ShortProductInfoDTO>))]
        [SwaggerOperation(Summary = "Get bestsellers")]

        public async Task<IActionResult> GetBestsellers()
        {
            var result = await _bestsellersService.GetBestsellrsAsync();
            return result != null ? Ok(result) : StatusCode(500);

        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CatalogPageDTO))]
        [SwaggerOperation(Summary = "Get catalog page")]

        public async Task<IActionResult> GetCatalogPage([FromQuery] int pageNumber, int groupBy, int? typeid)
        {
            var result = await _bestsellersService.GetCatalogPageAsync(typeid, pageNumber, groupBy);
            return result != null ? Ok(result) : StatusCode(500);

        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(FullProductInfoDTO))]
        [SwaggerOperation(Summary = "Get detail product info")]

        public async Task<IActionResult> GetFullProductInfo([FromQuery] Guid id)
        {
            var result = await _bestsellersService.GetFullProductAsync(id);
            return result != null ? Ok(result) : StatusCode(500);

        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(AdditionalParamsDTO))]
        [SwaggerOperation(Summary = "Get additional params")]

        public async Task<IActionResult> GetAdditionalParams()
        {
            var result = await _bestsellersService.GetAdditionalParamsAsync();
            return result!=null ? Ok(result): StatusCode(500);

        }
    }
}
