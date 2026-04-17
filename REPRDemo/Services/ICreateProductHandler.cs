using REPRDemo.Features.Products.CreateProduct;
using REPRDemo.Models;

namespace REPRDemo.Services
{
    internal interface ICreateProductHandler
    {
        Task<Product> HandleAsync(CreateProductRequest request, CancellationToken cancellationToken);
    }
}