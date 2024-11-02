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
                .WithMessage("Vəzifə adı mütləq daxil edilməlidir")
                .MinimumLength(3)
                .WithMessage("Vəzifə adı minimum 3 simvol ola bilər")
                .MaximumLength(100)
                .WithMessage("Vəzifə adı maksimum 100 simvol ola bilər");
        }
    }
}
