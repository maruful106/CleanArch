using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Core.Interfaces;

namespace CleanArch.Application.Commands
{
    public record DeleteProductCommand(Guid ProductId) : IRequest<bool>;

    public class DeleteProductCommandHandler(IProductRepository productRepository) : IRequestHandler<DeleteProductCommand, bool>
    {
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await productRepository.DeleteProductAsync(request.ProductId);
        }
    }
}
