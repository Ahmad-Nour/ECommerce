using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepo
        , IGenericRepository<ProductBrand> productBrandRepo
        , IGenericRepository<ProductType> productTypeRepo , IMapper mapper)
        {
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
            _productBrandRepo = productBrandRepo;
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task< ActionResult< IReadOnlyList <ProductToReturnDto> > > GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var products = await _productRepo.ListAsync(spec);
            return Ok(_mapper.Map< IReadOnlyList <Product> , IReadOnlyList <ProductToReturnDto> >(products));
        }

        [HttpGet("{id}")]
        public async Task< ActionResult <ProductToReturnDto> > GetProduct(int id)
        {
            var spc =new ProductsWithTypesAndBrandsSpecification(id);
            var products = await _productRepo.GetEntityWithSpec(spc);
            return _mapper.Map<Product , ProductToReturnDto>(products);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }

    }
}