using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(ICategoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateCategoryCommand request)
        {
            var category = await _repository.GetById(request.Id);

            if (category is null)
            {
                throw new NotFoundException("Category is required");
            }
            category.UpdateName(request.Name);

            try
            {
                await _repository.Update(category);
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
