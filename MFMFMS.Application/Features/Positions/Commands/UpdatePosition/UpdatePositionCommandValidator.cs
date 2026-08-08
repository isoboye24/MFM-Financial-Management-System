using FluentValidation;

namespace MFMFMS.Application.Features.Positions.Commands.UpdatePosition
{
    public class UpdatePositionCommandValidator : AbstractValidator<UpdatePositionCommand>
    {
        public UpdatePositionCommandValidator()
        {
            RuleFor(p => p.Name)
              .NotEmpty().WithMessage("The field {PropertyName} is required.");
        }
    }
}
