using System.ComponentModel.DataAnnotations;

namespace majed_asp_mvc.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Uid { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

    }
}
