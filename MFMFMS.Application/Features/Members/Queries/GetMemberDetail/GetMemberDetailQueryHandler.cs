using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Members.Queries.GetMemberDetail
{
    public class GetMemberDetailQueryHandler : IRequestHandler<GetMemberDetailQuery, MemberDetailDTO>
    {
        private readonly IMemberRepository _repository;
        public GetMemberDetailQueryHandler(IMemberRepository repository)
        {
            _repository = repository;
        }

        public async Task<MemberDetailDTO> Handle(GetMemberDetailQuery request)
        {
            var member = await _repository.GetMemberDetail(request.Id);

            if (member is null)
            {
                throw new NotFoundException("Member is not found");
            }

            return member.ToDTO();
        }
    }
}
