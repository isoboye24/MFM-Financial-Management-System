using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;
using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Members.Commands.CreateMembers
{
    public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Guid>
    {
        private readonly IMemberRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateMemberCommandHandler(IMemberRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateMemberCommand request)
        {
            bool exists = await _repository.Exists(request.FirstName, request.LastName, request.PhoneNumber);

            if (exists)
            {
                throw new CustomValidationException("The member already exists.");
            }
            else
            {
                var member = new Member(request.FirstName, request.LastName, request.Address, request.PhoneNumber, request.PositionId);

                try
                {
                    var result = await _repository.Add(member);
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
