using System.ComponentModel.DataAnnotations;

namespace majed_asp_mvc.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
