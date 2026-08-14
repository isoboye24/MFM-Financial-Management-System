using FluentValidation;

namespace MFMFMS.Application.Features.Documents.Commands.UpdateDocument
{
    public class UpdateDocumentCommandValidator : AbstractValidator<UpdateDocumentCommand>
    {
        public UpdateDocumentCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.BlobName).NotEmpty().WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.DocumentType).IsInEnum().WithMessage("The field {PropertyName} must be a valid enum value.");
        }
    }
}
