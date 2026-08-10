using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Members.Queries.GetMemberLists
{
    internal static class MapperExtensions
    {
        internal static MemberListsDTO ToDTO(this Member member)
        {
            return new MemberListsDTO
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
