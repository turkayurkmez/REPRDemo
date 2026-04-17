using REPRDemo.Shared;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using REPRDemo.Services;

namespace REPRDemo.Features.Products.CreateProduct
{
    public class CreateProductEndpoint : IEndpoint
    {
        public void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/products", HandleAsync)

               .WithName("CreateProduct")
               .WithTags("Products")
               //.RequireAuthorization()
               .Produces<CreateProductResponse>(StatusCodes.Status201Created)
               .ProducesValidationProblem();



        }

        private async Task<IResult> HandleAsync(CreateProductRequest request, ICreateProductHandler handler, CancellationToken cancellationToken)
        {
            var product = await handler.HandleAsync(request, cancellationToken);
            var response = new CreateProductResponse
            (
                Id: product.Id,
                Name: product.Name,
                Price: product.Price,
                CreatedAt: product.CreatedAt

            );

            return Results.Created($"/api/products/{response.Id}", response);
        }
    }
}
