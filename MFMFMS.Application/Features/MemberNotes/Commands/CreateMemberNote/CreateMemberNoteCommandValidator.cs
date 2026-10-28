using FluentValidation;

namespace MFMFMS.Application.Features.MemberNotes.Commands.CreateMemberNote
{
    public class CreateMemberNoteCommandValidator : AbstractValidator<CreateMemberNoteCommand>
    {
        public CreateMemberNoteCommandValidator()
        {
            RuleFor(p => p.NoteTitle).NotEmpty().WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.Note).NotEmpty().WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.MemberId).NotEmpty().WithMessage("The field {PropertyName} is required.");
        }
    }
}
