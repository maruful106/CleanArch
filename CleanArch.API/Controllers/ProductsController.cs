using CleanArch.Application.Commands;
using CleanArch.Application.Queries;
using CleanArch.Application.Responses;
using CleanArch.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers
{
    #region Suppressions
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "<Pending>")]
    #endregion

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _command;
        public ProductsController(ISender command)
        {
            _command = command;
        }
        [HttpPost]
        public async Task<IActionResult> AddProductAsync(ProductEntity product)
        {
            var result = await _command.Send(new AddProductCommand(product));
            return CreatedAtAction(nameof(GetProductById), new { productId = result }, new BaseResponse<Guid>(result, StatusCodes.Status201Created));

        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _command.Send(new GetAllProductsQuery());
            return Ok(new BaseResponse<IEnumerable<ProductEntity>>(result, StatusCodes.Status200OK));
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById([FromRoute] Guid productId)
        {
            var result = await _command.Send(new GetProductByIdQuery(productId));
            return result == null
                ? NotFound(new BaseResponse<string>("Product not found", StatusCodes.Status404NotFound))
                : Ok(new BaseResponse<ProductEntity>(result, StatusCodes.Status200OK));
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid productId, [FromBody] ProductEntity product)
        {
            var result = await _command.Send(new UpdateProductCommand(productId, product));
            return result == null
                ? NotFound(new BaseResponse<string>("Product not found", StatusCodes.Status404NotFound))
                : Ok(new BaseResponse<ProductEntity>(result, StatusCodes.Status200OK));
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid productId)
        {
            var result = await _command.Send(new DeleteProductCommand(productId));


            return result == false
                ? NotFound(new BaseResponse<string>("Product not found", StatusCodes.Status404NotFound))
                : NoContent();
        }

    }
}
