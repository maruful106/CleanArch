using CleanArch.Application.Commands;
using CleanArch.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers
{
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
            return Ok(result);
        }
    }
}
