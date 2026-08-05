using FluentValidation;

namespace MFMFMS.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(p => p.Name)
              .NotEmpty().WithMessage("The field {PropertyName} is required.");
        }
    }
}
