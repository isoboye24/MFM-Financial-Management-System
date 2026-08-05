using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Categories.Commands.CreateCategories
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
    }
}
