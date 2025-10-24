using System.ComponentModel.DataAnnotations;

namespace majed_asp_mvc.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Uid { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }

        public ICollection<Employee>? Employees { get; set; }

    }
}
