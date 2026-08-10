using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Members.Queries.GetMemberDetail
{
    internal static class MapperExtensions
    {
        internal static MemberDetailDTO ToDTO(this Member member)
        {
            return new MemberDetailDTO
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Address = member.Address,
                PhoneNumber = member.PhoneNumber,
                PositionName = member.Position?.Name ?? string.Empty
            };
        }
    }
}
