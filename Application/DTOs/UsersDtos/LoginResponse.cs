namespace Application.DTOs.UsersDtos
{
    public class LoginResponse
    {
        public bool Flag { get; set; }

        public string Message { get; set; } = null!;

        public string Token { get; set; } = string.Empty;
    }
}
