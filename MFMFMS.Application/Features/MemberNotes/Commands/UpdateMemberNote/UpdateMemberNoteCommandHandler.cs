using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.MemberNotes.Commands.UpdateMemberNote
{
    public class UpdateMemberNoteCommandHandler : IRequestHandler<UpdateMemberNoteCommand>
    {
        private readonly IMemberNoteRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateMemberNoteCommandHandler(IMemberNoteRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateMemberNoteCommand request)
        {
            var note = await _repository.GetById(request.Id);

            if (note is null)
            {
                throw new NotFoundException("Note is required");
            }

            note.UpdateMemberId(request.MemberId);
            note.UpdateNote(request.Note);
            note.UpdateNoteTitle(request.NoteTitle);            

            try
            {
                await _repository.Update(note);
                await _unitOfWork.Commit();
            }
            catch (Exception)
            {
                await _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
