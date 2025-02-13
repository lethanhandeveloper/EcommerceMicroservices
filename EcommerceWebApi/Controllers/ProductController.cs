using EcommerceWebApi.Dto;
using EcommerceWebApi.Dtos;
using EcommerceWebApi.Entity;
using EcommerceWebApi.Queries;
using EcommerceWebApi.Repository;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebApi.Controllers
{
    public class ProductController : ApiController
    {
        public readonly IProductRepository _productRepository;
        private readonly IMediator _mediator;

        public ProductController(IProductRepository productRepository, IMediator mediator)
        {
            _productRepository = productRepository;
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task <Guid> Add(ProductDto productDto) 
        {
            Product product = productDto.Adapt<Product>();
            Guid id = await _productRepository.AddNewProduct(product);
            return id;
        }

        [HttpPost("getAll")]
        public async Task<List<ProductDto>> GetAll()
        {
            List<Product> products = await _productRepository.GetAllProducts();
           return products.Select(x => x.Adapt<ProductDto>()).ToList();
        }

        [HttpDelete("delete/{id}")]
        public async Task<Guid> Delete(Guid id)
        {
            Product product = await _productRepository.GetProductById(id);
            if(product != null)
            {
                return await _productRepository.Delete(product);
            }

            return Guid.Empty;
        }

        [HttpGet("getbyid")]
        public async Task<ProductDto> GetById(Guid id)
        {
            Product product = await _productRepository.GetProductById(id);
            if (product != null)
            {
                return product.Adapt<ProductDto>();
            }

            return null;
        }

        [HttpPost("paging")]
        public async Task<List<ProductDto>> GetPaginatedProducts(SortFilterPagingProductDto sortFilterPagingProductDto)
        {
            List<Product> products = await _productRepository.GetPaginatedProduct(sortFilterPagingProductDto);
            List<ProductDto> result = new List<ProductDto>();

            if (products != null)
            {
                result = products.Select(p => p.Adapt<ProductDto>()).ToList();
                return result;
            }

            return result;
        }

        

    }
}
