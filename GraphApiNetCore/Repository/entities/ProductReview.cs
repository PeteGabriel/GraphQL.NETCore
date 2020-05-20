using System.ComponentModel.DataAnnotations;

namespace GraphApiNetCore.Repository.entities
{
    public class ProductReview
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public string Title { get; set; }
        public string Review { get; set; }
    }
}