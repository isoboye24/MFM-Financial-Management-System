using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.MemberNotes.Commands.RestoreDeletedMemberNotes
{
    public class RestoreDeletedMemberNoteCommandHandler : IRequestHandler<RestoreDeletedMemberNoteCommand>
    {
        private readonly IMemberNoteRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RestoreDeletedMemberNoteCommandHandler(IMemberNoteRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RestoreDeletedMemberNoteCommand request)
        {
            var note = await _repository.GetById(request.Id);
            if (note is null)
            {
                throw new NotFoundException("Member note not found");
            }

            try
            {
                await _repository.Restore(note);
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
