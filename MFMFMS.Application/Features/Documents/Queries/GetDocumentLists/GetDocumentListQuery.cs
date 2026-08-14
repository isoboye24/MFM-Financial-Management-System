using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Documents.Queries.GetDocumentLists
{
    public class GetDocumentListQuery : DocumentsFilterDTO, IRequest<PaginatedDTO<DocumentListsDTO>>
    {
    }
}
