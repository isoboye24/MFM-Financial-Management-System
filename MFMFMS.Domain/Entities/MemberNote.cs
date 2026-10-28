using MFMFMS.Domain.Exceptions;

namespace MFMFMS.Domain.Entities
{
    public class MemberNote : SoftDeletableEntity
    {
        public string Note { get; private set; } = string.Empty;
        public string NoteTitle { get; private set; } = string.Empty;
        public DateTime NoteDate { get; private set; }
        public Guid MemberId { get; private set; }
        public Member? Member { get; private set; }

        public MemberNote(string note, string noteTitle, DateTime noteDate, Guid memberId)
        {
            ValidateAll(note, noteTitle, noteDate, memberId);

            Note = note;
            NoteTitle = noteTitle.Trim();
            NoteDate = noteDate;
            MemberId = memberId;
            Id = Guid.CreateVersion7();
        }

        private MemberNote()
        {
            
        }

        private static void ValidateAll(string note, string noteTitle, DateTime noteDate, Guid memberId)
        {
            ValidateNote(note);
            ValidateNoteTitle(noteTitle);
            ValidateNoteDate(noteDate);
            ValidateMemberId(memberId);
        }

        private static void ValidateNote(string note)
        {
            if (string.IsNullOrWhiteSpace(note))
            {
                throw new BusinessRuleException("Note Title is required.");
            }
        }

        public void UpdateNote(string note)
        {
            ValidateNote(note);
            Note = note.Trim();
        }

        private static void ValidateNoteTitle(string noteTitle)
        {
            if (string.IsNullOrWhiteSpace(noteTitle))
            {
                throw new BusinessRuleException("Note Title is required.");
            }

            if (noteTitle.Length > 30)
            {
                throw new BusinessRuleException("Note Title must not exceed 30 characters.");
            }
        }

        public void UpdateNoteTitle(string noteTitle)
        {
            ValidateNoteTitle(noteTitle);
            NoteTitle = noteTitle.Trim();
        }

        private static void ValidateNoteDate(DateTime noteDate)
        {
            if (noteDate == DateTime.MinValue)
            {
                throw new BusinessRuleException("Note Date is required.");
            }
        }

        public void UpdateNoteDate(DateTime noteDate)
        {
            ValidateNoteDate(noteDate);
            NoteDate = noteDate;
        }

        private static void ValidateMemberId(Guid memberId)
        {
            if (memberId == Guid.Empty)
            {
                throw new BusinessRuleException("Member is required.");
            }
        }

        public void UpdateMemberId(Guid memberId)
        {
            ValidateMemberId(memberId);
            MemberId = memberId;
        }
    }
}
