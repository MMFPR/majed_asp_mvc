namespace majed_asp_mvc.Dtos
{
    public class LoginRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponsetDto
    {
        public bool IsSuccus { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
    }
}
