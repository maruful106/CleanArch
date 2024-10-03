using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Core.Entities;
using CleanArch.Core.Interfaces;

namespace CleanArch.Application.Queries
{
    public record GetProductByIdQuery(Guid ProductId) : IRequest<ProductEntity>;

    public class GetProductByIdQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, ProductEntity>
    {
        public async Task<ProductEntity> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
			return await productRepository.GetProductByIdAsync(request.ProductId);
        }
    }
}
