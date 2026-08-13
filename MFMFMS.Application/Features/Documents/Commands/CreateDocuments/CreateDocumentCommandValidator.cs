using FluentValidation;

namespace MFMFMS.Application.Features.Documents.Commands.CreateDocuments
{
    public class CreateDocumentCommandValidator : AbstractValidator<CreateDocumentCommand>
    {
        public CreateDocumentCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.BlobName).NotEmpty().WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.DocumentType).IsInEnum().WithMessage("The field {PropertyName} must be a valid enum value.");
        }
    }
}
