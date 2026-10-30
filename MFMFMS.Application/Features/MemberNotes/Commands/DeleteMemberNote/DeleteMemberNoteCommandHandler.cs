using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.MemberNotes.Commands.DeleteMemberNote
{
    public class DeleteMemberNoteCommandHandler : IRequestHandler<DeleteMemberNoteCommand>
    {
        private readonly IMemberNoteRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMemberNoteCommandHandler(IMemberNoteRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteMemberNoteCommand request)
        {
            var note = await _repository.GetById(request.Id);

            if (note is null)
            {
                throw new NotFoundException("Member note not found");
            }

            try
            {
                await _repository.Delete(note);
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
