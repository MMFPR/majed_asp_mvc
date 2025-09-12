using System.ComponentModel.DataAnnotations;

namespace majed_asp_mvc.Models
{
    public class Product
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
    }
}
