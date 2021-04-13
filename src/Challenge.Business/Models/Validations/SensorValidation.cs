using FluentValidation;

namespace Template.Business.Models.Validations
{
    public class SensorValidation : AbstractValidator<Sensor>
    {
        public SensorValidation()
        {
            RuleFor(f => f.Nome)
           .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido");
        }
    }
}
