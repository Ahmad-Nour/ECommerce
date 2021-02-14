using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            this._context = context;
        }

        public async Task<ProductBrand> GetProductBrandByIdAsync(int id)
        {
            return await _context.ProductBrands.FindAsync(id);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductType).Include(p => p.ProductBrand)
                .FirstOrDefaultAsync(p => p.Id ==id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            var products = await _context.Products
                .Include(p => p.ProductType).Include(p => p.ProductBrand)
                .ToListAsync();
                return products;
        }   

        public async Task<IReadOnlyList<ProductBrand>> GetProductsBrandAsync()
        {
            var items =_context.ProductBrands.ToListAsync();
            return await items;
        }

        public async Task<IReadOnlyList<ProductType>> GetProductsTypeAsync()
        {
            var items = _context.ProductTypes.ToListAsync();
            return await items;
        }

        public async Task<ProductType> GetProductTypeByIdAsync(int id)
        {
            return await _context.ProductTypes.FindAsync(id);
        }
    }
}