using Application.DTOs.UsersDtos;

namespace Application.Interfaces;

public interface IUser
{
    Task<LoginResponse> LoginUserAsync(LoginDto loginDto);
}
