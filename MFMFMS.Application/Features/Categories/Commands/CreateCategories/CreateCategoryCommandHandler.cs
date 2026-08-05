using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Utilities;
using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.Categories.Commands.CreateCategories
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly ICategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandHandler(ICategoryRepository repository, IUnitOfWork unitOfWork)
        {
             _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request)
        {
            var category = new Category(request.Name);

            try
            {
                var result = await _repository.Add(category);
                await _unitOfWork.Commit();
                return result.Id;
            }
            catch (Exception)
            {
                await _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
