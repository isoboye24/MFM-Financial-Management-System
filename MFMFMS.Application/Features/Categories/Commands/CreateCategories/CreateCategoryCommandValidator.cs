using FluentValidation;

namespace MFMFMS.Application.Features.Categories.Commands.CreateCategories
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("The field {PropertyName} is required.");            
        }
    }
}
