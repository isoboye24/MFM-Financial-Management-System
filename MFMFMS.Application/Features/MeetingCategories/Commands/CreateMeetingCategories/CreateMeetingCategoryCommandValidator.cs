using FluentValidation;

namespace MFMFMS.Application.Features.MeetingCategories.Commands.CreateMeetingCategories
{
    public class CreateMeetingCategoryCommandValidator : AbstractValidator<CreateMeetingCategoryCommand>
    {
        public CreateMeetingCategoryCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("The field {PropertyName} is required.");
        }
    }
}
