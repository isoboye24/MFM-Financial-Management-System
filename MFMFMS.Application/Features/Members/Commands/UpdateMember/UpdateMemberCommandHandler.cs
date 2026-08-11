using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Members.Commands.UpdateMember
{
    public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand>
    {
        private readonly IMemberRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateMemberCommandHandler(IMemberRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateMemberCommand request)
        {
            var member = await _repository.GetById(request.Id);

            if (member is null)
            {
                throw new NotFoundException("Member is required");
            }
            member.UpdateFirstName(request.FirstName);
            member.UpdateLastName(request.LastName);
            member.UpdateAddress(request.Address);
            member.UpdatePhoneNumber(request.PhoneNumber);
            member.UpdatePositionId(request.PositionId);

            try
            {
                await _repository.Update(member);
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
