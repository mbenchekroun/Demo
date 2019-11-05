using Dapper;

namespace Demo.Models
{
    [Table("Products")]
    public class ProductDto
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public double Price { get; set; }
    }
}
