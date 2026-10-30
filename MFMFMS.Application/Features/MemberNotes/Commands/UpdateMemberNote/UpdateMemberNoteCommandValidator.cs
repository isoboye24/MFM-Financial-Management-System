using FluentValidation;

namespace MFMFMS.Application.Features.MemberNotes.Commands.UpdateMemberNote
{
    public class UpdateMemberNoteCommandValidator : AbstractValidator<UpdateMemberNoteCommand>
    {
        public UpdateMemberNoteCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("The field Id is required.");
            RuleFor(p => p.NoteTitle).NotEmpty().WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.Note).NotEmpty().WithMessage("The field {PropertyName} is required.");
            RuleFor(p => p.MemberId).NotEmpty().WithMessage("The field {PropertyName} is required.");
        }
    }
}
