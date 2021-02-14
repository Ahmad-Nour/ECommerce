using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
         Task < Product > GetProductByIdAsync(int id);
         Task < IReadOnlyList < Product > > GetProductsAsync();
         Task < ProductType > GetProductTypeByIdAsync(int id);
         Task < IReadOnlyList < ProductType > > GetProductsTypeAsync();
         Task < ProductBrand > GetProductBrandByIdAsync(int id);
         Task < IReadOnlyList < ProductBrand > > GetProductsBrandAsync();
    }
}