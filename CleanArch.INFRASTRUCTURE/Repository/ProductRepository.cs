using CleanArch.Core.Entities;
using CleanArch.Core.Interfaces;
using CleanArch.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.Repository
{
    public class ProductRepository(ApplicationDbContext dbContext) : IProductRepository
    {
        public async Task<Guid> AddProductAsync(ProductEntity product)
        {
            product.Id = Guid.NewGuid();
            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();
            return product.Id;
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            ProductEntity productEntity = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (productEntity != null)
            {
                dbContext.Products.Remove(productEntity);

                
                return await dbContext.SaveChangesAsync()>0;
            }
            else
            {
                return false;
            }
        }

        public async Task<ProductEntity> GetProductByIdAsync(Guid id)
        {
            return await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ProductEntity>> GetProductsAsync()
        {
            return await dbContext.Products.ToListAsync();
        }

        public async Task<ProductEntity> UpdateProductAsync(Guid id,ProductEntity product)
        {
            ProductEntity productEntity = await dbContext.Products.FirstOrDefaultAsync(x=>x.Id == id);
            if (productEntity != null)
            {
                productEntity.Name = product.Name;
                productEntity.Description = product.Description;
                productEntity.Price = product.Price;

                await dbContext.SaveChangesAsync();
                return product;
            }
            else
            {
                return new ProductEntity();
            }
        }
    }
}
