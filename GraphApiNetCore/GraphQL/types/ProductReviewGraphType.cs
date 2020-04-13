using GraphApiNetCore.Repository.entities;
using GraphQL.Types;

namespace GraphApiNetCore.GraphQL.types
{
    public class ProductReviewGraphType : ObjectGraphType<ProductReview>
    {
        public ProductReviewGraphType()
        {
            Name="Review";
            Description = "Review related to a product";
            
            Field(t => t.Id).Description("Id of review");
            Field(t => t.ProductId).Description("Product Id associated with this review");
            Field(t => t.Title).Description("Title of review");
            Field(t => t.Review).Description("Content of review");
        }
    }
}