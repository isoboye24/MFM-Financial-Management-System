using FluentValidation;

namespace MFMFMS.Application.Features.Members.Commands.CreateMembers
{
    public class CreateMemberCommandValidator : AbstractValidator<CreateMemberCommand>
    {
        public CreateMemberCommandValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.Address).NotEmpty().WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.PositionId).NotEmpty().WithMessage("The field {PropertyName} is required.");
        }
    }
}
