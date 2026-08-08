using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Positions.Queries.GetPositionLists
{
    internal static class MapperExtensions
    {
        internal static PositionListsDTO ToDTO(this Position position)
        {
            return new PositionListsDTO
            {
                Id = position.Id,
                Name = position.Name
            };
        }
    }
}
