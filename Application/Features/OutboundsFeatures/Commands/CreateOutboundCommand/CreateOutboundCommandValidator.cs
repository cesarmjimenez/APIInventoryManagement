using FluentValidation;

namespace Application.Features.OutboundsFeatures.Commands.CreateOutboundCommand;

public class CreateOutboundCommandValidator : AbstractValidator<CreateOutboundCommand>
{
    public CreateOutboundCommandValidator()
    {
        RuleFor(o => o.DestinationId)
            .NotEmpty().WithMessage("El destino es obligatorio.")
            .NotEqual(Guid.Empty).WithMessage("El Id de destino no es valido");

        RuleFor(o => o.Items)
            .NotNull().WithMessage("La salida necesita productos.")
            .Must(items => items != null && items.Any()).WithMessage("Debe incluir al menos un item.");

        RuleForEach(o => o.Items).ChildRules(item =>
        {
            item.RuleFor(i => i.ProductId)
            .NotEmpty().WithMessage("El id del producto es obligatorio.");

            item.RuleFor(i => i.Quantity)
            .GreaterThan(0).WithMessage("Debe incluir al menos un producto.");
        });
    }
}
