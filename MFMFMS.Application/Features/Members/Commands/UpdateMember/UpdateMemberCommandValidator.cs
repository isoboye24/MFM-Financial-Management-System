using FluentValidation;

namespace MFMFMS.Application.Features.Members.Commands.UpdateMember
{
    public class UpdateMemberCommandValidator : AbstractValidator<UpdateMemberCommand>
    {
        public UpdateMemberCommandValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.Address).NotEmpty().WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.PositionId).NotEmpty().WithMessage("The field {PropertyName} is required.");
        }
    }
}
