using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
