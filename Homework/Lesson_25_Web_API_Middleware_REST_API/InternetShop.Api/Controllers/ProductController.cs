using Asp.Versioning;
using InternetShop.Contract.Requests.Create;
using InternetShop.Contract.Responses;
using InternetShop.Service;
using InternetShop.Service.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[Controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync([FromServices] IRequestHandler<IList<ProductResponse>> getProducts)
        {
            return Ok(await getProducts.Handle());
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] ProductCreateRequest product, [FromServices] IRequestHandler<CreateProductCommand, ProductResponse> createProduct)
        {
            var productCreated = await createProduct.Handle(new CreateProductCommand
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CreatedDate = product.CreatedDate,
                CategoryId = product.CategoryId
            });

            if (productCreated != null)
            {
                return Ok(productCreated);
            }

            return Conflict();
        }
    }
}
