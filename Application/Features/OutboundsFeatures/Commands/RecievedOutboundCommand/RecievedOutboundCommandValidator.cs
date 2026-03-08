using FluentValidation;

namespace Application.Features.OutboundsFeatures.Commands.RecievedOutboundCommand;

public class RecievedOutboundCommandValidator : AbstractValidator<RecievedOutboundCommand>
{
    public RecievedOutboundCommandValidator()
    {
        RuleFor(o => o.OutboundId)
            .NotEmpty().WithMessage("El Id de la salida es obligatorio.");
    }
}
