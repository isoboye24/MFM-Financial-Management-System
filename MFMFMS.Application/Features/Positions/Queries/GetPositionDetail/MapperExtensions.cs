using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Positions.Queries.GetPositionDetail
{
    internal static class MapperExtensions
    {
        internal static PositionDetailDTO ToDTO(this Position position)
        {
            return new PositionDetailDTO
            {
                Id = position.Id,
                Name = position.Name
            };
        }
    }
}
