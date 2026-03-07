using Application.DTOs.UsersDtos;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.UsersFeatures.Commands.LoginCommand;

public class LoginCommand : IRequest<Response<LoginResponse>>
{
    public string? UserName { get; set; }

    public string? PasswordHash { get; set; }
}

public class loginCommandHandler(
    IUser userService,
    IMapper mapper) : IRequestHandler<LoginCommand, Response<LoginResponse>>
{
    public async Task<Response<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var loginDto = mapper.Map<LoginDto>(request);

        var result = await userService.LoginUserAsync(loginDto);

        if (!result.Flag)
            return new Response<LoginResponse>(result.Message) { Succeeded = false };

        return new Response<LoginResponse>(result, result.Message);
    }
}
