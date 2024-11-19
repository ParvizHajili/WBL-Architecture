using Core.Constants;
using Entites.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class PositionValidation : AbstractValidator<Position>
    {
        public PositionValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(DefaultConstantValues.GetRequiredMessage("Vəzifə adı"))
                .MinimumLength(3)
                .WithMessage(DefaultConstantValues.GetMinimumLengthMessage("Vəzifə adı", 3))
                .MaximumLength(100)
                .WithMessage(DefaultConstantValues.GetMaxLengthMessage("Vəzifə adı", 100));
        }
    }
}
