namespace REPRDemo.Features.Products.CreateProduct
{
    public record CreateProductResponse(
        int Id,
        string Name,
        decimal Price,
        DateTime CreatedAt);
}
