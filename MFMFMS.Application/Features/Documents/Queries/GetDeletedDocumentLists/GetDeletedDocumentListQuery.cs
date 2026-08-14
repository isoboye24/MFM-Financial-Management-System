using MFMFMS.Application.Utilities;
using MFMFMS.Application.Utilities.Common;

namespace MFMFMS.Application.Features.Documents.Queries.GetDeletedDocumentLists
{
    public class GetDeletedDocumentListQuery : DeletedDocumentsFilterDTO, IRequest<PaginatedDTO<DeletedDocumentListDTO>>
    {
    }
}
