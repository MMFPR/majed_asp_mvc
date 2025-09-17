using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace majed_asp_mvc.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        
        public string Address { get; set; }
        public string? Position { get; set; }
        public decimal Salary { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        //--------------------

        [ForeignKey("Nationality")]
        public int? NationalityId { get; set; }
        public Nationality? Nationality { get; set; }


    }
}

