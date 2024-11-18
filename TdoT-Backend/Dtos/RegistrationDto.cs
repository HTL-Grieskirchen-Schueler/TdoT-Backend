namespace TdoT_Backend.Dtos
{
    public class RegistrationDto
    {
        public string School { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateOnly Date { get; set; }

    }
}
