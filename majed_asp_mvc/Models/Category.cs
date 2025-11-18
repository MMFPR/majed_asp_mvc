using System.ComponentModel.DataAnnotations;

namespace majed_asp_mvc.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Uid { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<Product>? Products { get; set; }
    }

}
