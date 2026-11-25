using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Contracts.Storage;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;
using Microsoft.Extensions.Logging;

namespace MFMFMS.Application.Features.Members.Commands.PermanentDeleteMember
{
    public class PermanentDeleteMemberCommandHandler : IRequestHandler<PermanentDeleteMemberCommand>
    {
        private readonly IMemberRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageStorageService _imageStorage;
        private readonly ILogger<PermanentDeleteMemberCommandHandler> _logger;

        public PermanentDeleteMemberCommandHandler(IMemberRepository repository, IUnitOfWork unitOfWork, IImageStorageService imageStorage,
        ILogger<PermanentDeleteMemberCommandHandler> logger)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _imageStorage = imageStorage;
            _logger = logger;
        }

        public async Task Handle(PermanentDeleteMemberCommand request)
        {
            var member = await _repository.GetMemberDetail(request.Id);

            if (member is null)
                throw new NotFoundException("Member not found");

            var imagePath = member.ImagePath;

            try
            {
                await _repository.DeletePermanently(member);
                await _unitOfWork.Commit();
            }
            catch
            {
                await _unitOfWork.Rollback();
                throw;
            }

            if (string.IsNullOrWhiteSpace(imagePath))
                return;

            // Keep the image if another member still uses it.
            var imageIsInUse = await _repository.IsImagePathInUse(imagePath);

            if (imageIsInUse)
                return;

            try
            {
                await _imageStorage.DeleteAsync(imagePath);
            }
            catch (Exception ex)
            {
                // The database deletion has already succeeded.
                // Do not attempt to roll it back because file deletion failed.
                _logger.LogError(
                    ex,
                    "Could not delete member image {ImagePath}",
                    imagePath);
            }


        }
    }
}
