using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.MeetingCategories.Commands.RestoreMeetingCategory
{
    public class RestoreMeetingCategoryCommandHandler : IRequestHandler<RestoreMeetingCategoryCommand>
    {
        private readonly IMeetingCategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RestoreMeetingCategoryCommandHandler(IMeetingCategoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RestoreMeetingCategoryCommand request)
        {
            var category = await _repository.GetById(request.Id);

            if (category is null)
            {
                throw new NotFoundException("Category not found");
            }

            try
            {
                await _repository.Restore(category);
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
