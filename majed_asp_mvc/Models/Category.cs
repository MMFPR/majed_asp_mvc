using System.ComponentModel.DataAnnotations;

namespace majed_asp_mvc.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
    
}
