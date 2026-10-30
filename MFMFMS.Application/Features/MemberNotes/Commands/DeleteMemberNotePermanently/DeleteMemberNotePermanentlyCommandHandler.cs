using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.MemberNotes.Commands.DeleteMemberNotePermanently
{
    public class DeleteMemberNotePermanentlyCommandHandler : IRequestHandler<DeleteMemberNotePermanentlyCommand>
    {
        private readonly IMemberNoteRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMemberNotePermanentlyCommandHandler(IMemberNoteRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteMemberNotePermanentlyCommand request)
        {
            var note = await _repository.GetById(request.Id);
            if (note is null)
            {
                throw new NotFoundException("Member note not found");
            }

            try
            {
                await _repository.DeletePermanently(note);
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
