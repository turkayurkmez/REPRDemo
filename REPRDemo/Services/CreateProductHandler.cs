using REPRDemo.Features.Products.CreateProduct;
using REPRDemo.Models;

namespace REPRDemo.Services
{
    public class CreateProductHandler : ICreateProductHandler
    {
        public Task<Product> HandleAsync(CreateProductRequest request, CancellationToken cancellationToken)
        {
            //örnek olarak, burada veritabanına kaydetme işlemi yapılabilir. Ancak, bu örnekte sadece yeni bir Product nesnesi oluşturup döndürüyoruz.
            var product = new Product
            {
                Id = 1,
                Name = request.Name,
                Price = request.Price,
                CreatedAt = DateTime.UtcNow
            };
            return Task.FromResult(product);

        }
    }
}
