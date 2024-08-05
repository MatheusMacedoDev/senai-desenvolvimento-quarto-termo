using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsManagementForUnitTest.Domains
{
    public class Product
    {
        [Key]
        [Column("product_id")]
        public Guid ProductId { get; set; }


        [Required]
        [Column("product_name")]
        public string Name { get; set; }

        [Required]
        [Column("product_price")]
        public decimal Price { get; set; }
    }
}
