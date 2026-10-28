using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Genders.GetGenderList
{
    public static class MapperExtensions
    {
        internal static GenderListsDTO ToDTO(this Gender gender)
        {
            return new GenderListsDTO
            {
                Id = gender.Id,
                Name = gender.Name
            };
        }
    }
}
