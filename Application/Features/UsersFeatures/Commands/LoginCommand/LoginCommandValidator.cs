using FluentValidation;

namespace Application.Features.UsersFeatures.Commands.LoginCommand;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(u => u.UserName)
            .NotEmpty().WithMessage("El nombre de usuario es requerido");

        RuleFor(u => u.PasswordHash)
            .NotEmpty().WithMessage("La contraseña es requerida");
    }
}
