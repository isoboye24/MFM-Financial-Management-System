using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Members.Queries.GetDeletedMemberLists
{
    internal static class MapperExtensions
    {
        internal static DeletedMemberListDTO ToDTO(this Member member)
        {
            return new DeletedMemberListDTO
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Address = member.Address,
                PhoneNumber = member.PhoneNumber,
                PositionName = member.Position?.Name ?? string.Empty,
                DeletedAt = member.DeletedAt ?? DateTime.MinValue
            };
        }
    }
}
