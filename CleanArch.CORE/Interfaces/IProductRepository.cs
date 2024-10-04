using CleanArch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetProductsAsync();
        Task<ProductEntity> GetProductByIdAsync(Guid id);
        Task<Guid> AddProductAsync(ProductEntity product);
        Task<ProductEntity> UpdateProductAsync(Guid id, ProductEntity product);
        Task<bool> DeleteProductAsync(Guid id);
    }
}
