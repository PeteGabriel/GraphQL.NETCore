using GraphApiNetCore.Repository.entities;
using GraphQL.Types;

namespace GraphApiNetCore.GraphQL.types
{
    public class ProductGraphType: ObjectGraphType<Product>
    {

        public ProductGraphType()
        {
            Field(t => t.Id).Description("Id of product");
            Field(t => t.Name).Description("Name of product");
            Field(t => t.Price).Description("Price of product");
            Field(t => t.Rating).Description("Rating");
            Field(t => t.Stock).Description("Stock");
            Field(t => t.IntroducedAt).Description("When was first created");;
            Field(t => t.PhotoFileName);
            Field<TypeGraphType>(Name= "Type", Description="Type of product");

        }
        
    }
}