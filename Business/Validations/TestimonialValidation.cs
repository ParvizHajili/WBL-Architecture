using Core.Constants;
using Entites.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class TestimonialValidation : AbstractValidator<Testimonial>
    {
        public TestimonialValidation()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage(DefaultConstantValues.GetRequiredMessage("Müştəri adı"))
                .MinimumLength(3)
                .WithMessage(DefaultConstantValues.GetMinimumLengthMessage("Müştəri adı", 3))
                .MaximumLength(50)
                .WithMessage(DefaultConstantValues.GetMaxLengthMessage("Müştəri adı", 50));

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage(DefaultConstantValues.GetRequiredMessage("Müştəri soyadı"))
                .MinimumLength(3)
                .WithMessage(DefaultConstantValues.GetMinimumLengthMessage("Müştəri soyadı", 3))
                .MaximumLength(50)
                .WithMessage(DefaultConstantValues.GetMaxLengthMessage("Müştəri soyadı", 50));


            RuleFor(x => x.Message)
                .NotEmpty()
                .WithMessage(DefaultConstantValues.GetRequiredMessage("Müştəri mesajı"))
                .MinimumLength(3)
                .WithMessage(DefaultConstantValues.GetMinimumLengthMessage("Müştəri mesajı", 3))
                .MaximumLength(3000)
                .WithMessage(DefaultConstantValues.GetMaxLengthMessage("Müştəri mesajı", 3000));

            RuleFor(x => x.ImageUrl)
                .NotEmpty()
                .WithMessage(DefaultConstantValues.GetRequiredMessage("Müştəri şəkli"));
        }
    }
}
