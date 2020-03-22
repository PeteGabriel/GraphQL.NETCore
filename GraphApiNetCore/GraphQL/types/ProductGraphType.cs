using GraphApiNetCore.Repository.entities;
using GraphQL.Types;

namespace GraphApiNetCore.GraphQL.types
{
    public class ProductGraphType: ObjectGraphType<Product>
    {

        public ProductGraphType()
        {
            Field(t => t.Id);
            Field(t => t.Name);
            Field(t => t.Price);
        }
        
    }
}