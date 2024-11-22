namespace TdoT_Backend.Dtos
{
    public class RegistrationDto
    {
        public string School { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateOnly Date { get; set; }

    }
}
