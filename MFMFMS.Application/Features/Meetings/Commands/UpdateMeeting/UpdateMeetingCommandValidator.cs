using FluentValidation;

namespace MFMFMS.Application.Features.Meetings.Commands.UpdateMeeting
{
    public class UpdateMeetingCommandValidator : AbstractValidator<UpdateMeetingCommand>
    {
        public UpdateMeetingCommandValidator()
        {
            RuleFor(x => x.MessageTitle)
                .NotEmpty().WithMessage("Message title is required.")
                .MaximumLength(200).WithMessage("Message title must not exceed 200 characters.");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date is required.");

            RuleFor(x => x.Minister)
                .NotEmpty().WithMessage("Minister is required.");

            RuleFor(x => x.NoOfMaleAttendance)
                .GreaterThanOrEqualTo(0).WithMessage("Number of male attendance cannot be negative.");

            RuleFor(x => x.NoOfFemaleAttendance)
                .GreaterThanOrEqualTo(0).WithMessage("Number of female attendance cannot be negative.");

            RuleFor(x => x.NoOfChildrenAttendance)
                .GreaterThanOrEqualTo(0).WithMessage("Number of children attendance cannot be negative.");
        } 
    }
}