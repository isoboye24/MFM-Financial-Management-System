using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Documents.Commands.DeleteDocument
{
    public class DeleteDocumentCommandHandler : IRequestHandler<DeleteDocumentCommand>
    {
        private readonly IDocumentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteDocumentCommandHandler(IDocumentRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteDocumentCommand request)
        {
            var document = await _repository.GetDocumentDetail(request.Id);

            if (document is null)
            {
                throw new NotFoundException("Document not found");
            }

            try
            {
                await _repository.Delete(document);
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
