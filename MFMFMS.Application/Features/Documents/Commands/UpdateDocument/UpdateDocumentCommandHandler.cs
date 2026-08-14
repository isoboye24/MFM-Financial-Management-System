using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Documents.Commands.UpdateDocument
{
    public class UpdateDocumentCommandHandler : IRequestHandler<UpdateDocumentCommand>
    {
        private readonly IDocumentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateDocumentCommandHandler(IDocumentRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateDocumentCommand request)
        {
            var document = await _repository.GetDocumentDetail(request.Id);

            if (document is null)
            {
                throw new NotFoundException("Document is required");
            }
            document.UpdateName(request.Name);
            document.UpdateBlobName(request.BlobName);
            document.UpdateDocumentType(request.DocumentType);

            try
            {
                await _repository.Update(document);
                await _unitOfWork.Commit();
            }
            catch (Exception)
            {
                await _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
