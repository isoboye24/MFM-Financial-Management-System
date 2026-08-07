using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Categories.Commands.RestoreCategory
{
    public class RestoreCategoryCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
