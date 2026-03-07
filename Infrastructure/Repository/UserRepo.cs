using Application.DTOs.UsersDtos;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Repository;

public class UserRepo(DatabaseContext context, IConfiguration configuration) : IUser
{
    public async Task<LoginResponse> LoginUserAsync(LoginDto loginDto)
    {
        var getUser = await context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.UserName == loginDto.UserName);

        if (getUser == null)
            return new LoginResponse { Flag = false, Message = "Usuario no encontrado en el sistema" };

        if (getUser.PasswordHash != loginDto.PasswordHash)
            return new LoginResponse { Flag = false, Message = "Contraseña incorrecta" };

        return new LoginResponse { Flag = true, Message = "Login exitoso", Token = GeneratedToken(getUser) };
    }

    private string GeneratedToken(Users getUser)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var userClaims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, getUser.Id.ToString()),
            new Claim(ClaimTypes.Name, getUser.FullName),
            new Claim(ClaimTypes.Role, getUser.Role.RoleName)
        };

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: userClaims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
