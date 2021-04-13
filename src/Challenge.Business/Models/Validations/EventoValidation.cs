using FluentValidation;

namespace Template.Business.Models.Validations
{
    public class EventoValidation : AbstractValidator<Evento>
    {
        public EventoValidation()
        {
            RuleFor(f => f.Valor)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido");
        }
    }
}
