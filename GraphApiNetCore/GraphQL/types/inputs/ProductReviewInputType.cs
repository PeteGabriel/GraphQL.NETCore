using GraphQL.Types;

namespace GraphApiNetCore.GraphQL.types.inputs
{
    public class ProductReviewInputType : InputObjectGraphType
    {
        public ProductReviewInputType()
        {
            Name = "productReviewInput";
            Field<NonNullGraphType<StringGraphType>>("title");
            Field<NonNullGraphType<StringGraphType>>("review");
            Field<NonNullGraphType<IntGraphType>>("productId");
        }
    }
}