using EcommerceWebApi.Entity;
using EcommerceWebApi.Repository;
using MediatR;

namespace EcommerceWebApi.Queries
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAllProducts();
        }
    }
}
