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
                Email = member.Email ?? string.Empty,
                PositionId = member.PositionId,
                PositionName = member.Position?.Name ?? string.Empty,
                GenderId = member.GenderId,
                GenderName = member.Gender?.Name ?? string.Empty,
                CreatedAt = DateOnly.FromDateTime(member.CreationTime ?? DateTime.Now)
            };
        }
    }
}
