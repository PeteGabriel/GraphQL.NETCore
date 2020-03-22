using GraphApiNetCore.GraphQL.types;
using GraphApiNetCore.Repository;
using GraphQL.Types;

namespace GraphApiNetCore.GraphQL.queries
{
    public class ProductQuery: ObjectGraphType<ProductGraphType>
    {
        public ProductQuery(ProductRepository repository)
        {
            Field<ListGraphType<ProductGraphType>>(
                "products", 
                resolve: context => repository.GetProducts());
        }
    }
}