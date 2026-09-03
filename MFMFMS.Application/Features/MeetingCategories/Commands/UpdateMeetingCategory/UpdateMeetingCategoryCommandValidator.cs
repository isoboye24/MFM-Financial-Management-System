using FluentValidation;

namespace MFMFMS.Application.Features.MeetingCategories.Commands.UpdateMeetingCategory
{
    public class UpdateMeetingCategoryCommandValidator : AbstractValidator<UpdateMeetingCategoryCommand>
    {
        public UpdateMeetingCategoryCommandValidator()
        {
            RuleFor(p => p.Name)
              .NotEmpty().WithMessage("The field {PropertyName} is required.");
        }
    }
}
