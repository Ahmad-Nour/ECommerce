using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification :BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams)
        : base( x =>
            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search))
            && (!productParams.BrandId.HasValue || x.ProductBrandId ==productParams.BrandId) 
            && (!productParams.TypeId.HasValue || x.ProductTypeId ==productParams.TypeId))
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrederBy(p => p.Name);
            if(!string.IsNullOrEmpty(productParams.Sort))
            {
                if(productParams.Sort =="priceAsc")
                {
                    AddOrederBy(p => p.Price);
                }
                else if(productParams.Sort =="priceDesc")
                {
                    AddOrederByDescending(p => p.Price);
                }
                else
                {
                    AddOrederBy(p => p.Name);
                }
            }
            ApplyPaging(productParams.PageSize * (productParams.PageIndex -1) , productParams.PageSize);
            
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id ==id)
        {
            
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);     
        }
    }
}