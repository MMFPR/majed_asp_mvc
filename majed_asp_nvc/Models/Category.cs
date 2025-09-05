using System.ComponentModel.DataAnnotations;

namespace majed_asp_nvc.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
