using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Categories.Commands.PermanentDeleteCategory
{
    public class PermanentDeleteCategoryCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
