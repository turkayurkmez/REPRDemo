namespace REPRDemo.Features.Products.CreateProduct
{
    public record CreateProductRequest(
        string Name,
        decimal Price,
        int CategoryId);
}
