using EcommerceWebApi.Entity;
using MediatR;

namespace EcommerceWebApi.Queries
{
    public class GetAllProductQuery : IRequest<List<Product>>
    {
    }
}
