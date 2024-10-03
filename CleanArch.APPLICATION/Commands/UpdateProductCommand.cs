using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Core.Entities;
using CleanArch.Core.Interfaces;

namespace CleanArch.Application.Commands
{
    public record UpdateProductCommand(Guid ProductId, ProductEntity Product) 
        : IRequest<ProductEntity>;

    public class UpdateProductCommandHandler(IProductRepository productRepository) : IRequestHandler<UpdateProductCommand, ProductEntity>
    {
        public async Task<ProductEntity> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
			return await productRepository.UpdateProductAsync(request.ProductId, request.Product);
        }
    }
}
