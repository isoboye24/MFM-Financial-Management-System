using FluentValidation;

namespace MFMFMS.Application.Features.Meetings.Commands.CreateMeetings
{
    public class CreateMeetingsCommandValidator : AbstractValidator<CreateMeetingsCommand>
    {
        public CreateMeetingsCommandValidator()
        {
            RuleFor(p => p.MessageTitle).NotEmpty().WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.Minister).NotEmpty().WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.Date).GreaterThan(DateTime.MinValue).WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.NoOfMaleAttendance).GreaterThanOrEqualTo(0).WithMessage("The field {PropertyName} cannot be negative.");
            RuleFor(p => p.NoOfFemaleAttendance).GreaterThanOrEqualTo(0).WithMessage("The field {PropertyName} cannot be negative.");
            RuleFor(p => p.NoOfChildrenAttendance).GreaterThanOrEqualTo(0).WithMessage("The field {PropertyName} cannot be negative.");
        }
    }
}
