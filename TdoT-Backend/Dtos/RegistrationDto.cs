namespace TdoT_Backend.Dtos;
public class RegistrationDto : IEquatable<RegistrationDto>
{
    public string School { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateOnly Date { get; set; }


    public bool Equals(RegistrationDto? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return School == other.School && Name == other.Name && Email == other.Email && Phone == other.Phone && Date.Equals(other.Date);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((RegistrationDto)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(School, Name, Email, Phone, Date);
    }
}
