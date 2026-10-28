using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;
using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.MemberNotes.Commands.CreateMemberNote
{
    public class CreateMemberNoteCommandHandler : IRequestHandler<CreateMemberNoteCommand, Guid>
    {
        private readonly IMemberNoteRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateMemberNoteCommandHandler(IMemberNoteRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateMemberNoteCommand request)
        {
            bool exists = await _repository.Exists(request.NoteTitle, request.MemberId);

            if (exists)
            {
                throw new CustomValidationException("The Member Note already exists.");
            }
            else
            {
                var memberNote = new MemberNote(request.Note, request.NoteTitle, request.MemberId);

                try
                {
                    var result = await _repository.Add(memberNote);
                    await _unitOfWork.Commit();
                    return result.Id;
                }
                catch (Exception)
                {
                    await _unitOfWork.Rollback();
                    throw;
                }
            }
        }
    }
}
