using GraphApiNetCore.Repository.entities;
using GraphQL.Types;

namespace GraphApiNetCore.GraphQL.types
{
    public class TypeGraphType : EnumerationGraphType<ProductType>
    {
        public TypeGraphType()
        {
            Name = "Type";
            Description = "Type of product";
        }
    }
}