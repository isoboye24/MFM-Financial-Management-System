using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Members.Commands.PermanentDeleteMember
{
    public class PermanentDeleteMemberCommandHandler : IRequestHandler<PermanentDeleteMemberCommand>
    {
        private readonly IMemberRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PermanentDeleteMemberCommandHandler(IMemberRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(PermanentDeleteMemberCommand request)
        {
            var member = await _repository.GetMemberDetail(request.Id);

            if (member is null)
            {
                throw new NotFoundException("Member not found");
            }

            try
            {
                await _repository.DeletePermanently(member);
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
