namespace Application.DTOs.UsersDtos;

public class LoginDto
{
    public string? UserName { get; set; }

    public string? PasswordHash { get; set; }
}
