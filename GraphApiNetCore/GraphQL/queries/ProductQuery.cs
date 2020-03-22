using GraphApiNetCore.GraphQL.types;
using GraphApiNetCore.Repository;
using GraphApiNetCore.Repository.entities;
using GraphQL.Types;

namespace GraphApiNetCore.GraphQL.queries
{
    public class ProductQuery: ObjectGraphType<ProductGraphType>
    {
        public ProductQuery(IRepository repository)
        {
            Field<ListGraphType<ProductGraphType>>(
                "products", 
                resolve: context => repository.GetProducts());
        }
    }
}