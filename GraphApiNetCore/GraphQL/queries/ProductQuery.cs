using GraphApiNetCore.GraphQL.types;
using GraphApiNetCore.Repository;
using GraphApiNetCore.Repository.entities;
using GraphQL.Types;

namespace GraphApiNetCore.GraphQL.queries
{
    public class ProductQuery: ObjectGraphType<ProductGraphType>
    {
        public ProductQuery(IRepository<Product> products)
        {
            Field<ListGraphType<ProductGraphType>>(
                "products", 
                resolve: context => products.All());

            Field<ProductGraphType>(
                "product",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>{Name = "id"})
                , 
                resolve: ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    return products.GetById(id);
                });
        }
    }
}