using GraphQL.Types;

namespace GraphApiNetCore.GraphQL.types.inputs
{
    public class ProductInputType: InputObjectGraphType
    {
        public ProductInputType()
        {
            Name = "productInputType";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<TypeGraphType>>("type");
            Field<NonNullGraphType<StringGraphType>>("description");
            Field<NonNullGraphType<DecimalGraphType>>("price");
        }
        
        
    }
}