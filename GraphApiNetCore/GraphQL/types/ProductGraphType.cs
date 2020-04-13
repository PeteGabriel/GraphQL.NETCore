using GraphApiNetCore.Repository;
using GraphApiNetCore.Repository.entities;
using GraphApiNetCore.Repository.impl;
using GraphQL.Types;

namespace GraphApiNetCore.GraphQL.types
{
    public class ProductGraphType: ObjectGraphType<Product>
    {

        public ProductGraphType(IRepository<ProductReview> prodReviewRepo)
        {
            var reviews = prodReviewRepo as ProductReviewRepository;
            
            Field(t => t.Id).Description("Id of product");
            Field(t => t.Name).Description("Name of product");
            Field(t => t.Price).Description("Price of product");
            Field(t => t.Rating).Description("Rating");
            Field(t => t.Stock).Description("Stock");
            Field(t => t.IntroducedAt).Description("When was first created");;
            Field(t => t.PhotoFileName);
            Field<TypeGraphType>(Name= "Type", Description="Type of product");

            Field<ListGraphType<ProductReviewType>>(
                "review", 
                "Reviews related to this product",
                resolve: ctx => reviews?.FilterByProduct(ctx.Source.Id));

        }
        
    }
}