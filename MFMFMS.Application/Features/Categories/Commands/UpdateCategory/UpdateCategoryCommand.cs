using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
