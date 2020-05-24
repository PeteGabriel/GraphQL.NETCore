using GraphApiNetCore.GraphQL.types;
using GraphApiNetCore.GraphQL.types.inputs;
using GraphApiNetCore.Repository;
using GraphApiNetCore.Repository.entities;
using GraphQL.Types;

namespace GraphApiNetCore.GraphQL.queries
{
    public class ProductMutation: ObjectGraphType
    {
        public ProductMutation(IRepository<Product> repo)
        {
            FieldAsync<ProductGraphType>(
                "createProduct",
                "Create a product",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductInputType>>{Name="product"}),
                resolve: async ctx =>
                {
                    var prod = ctx.GetArgument<Product>("product");
                    return await repo.Add(prod);
                }
            );
        }
    }
}