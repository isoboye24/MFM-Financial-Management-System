using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.MeetingCategories.Commands.DeleteMeetingCategory
{
    public class DeleteMeetingCategoryCommandHandler : IRequestHandler<DeleteMeetingCategoryCommand>
    {
        private readonly IMeetingCategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMeetingCategoryCommandHandler(IMeetingCategoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteMeetingCategoryCommand request)
        {
            var category = await _repository.GetById(request.Id);

            if (category is null)
            {
                throw new NotFoundException("Category not found");
            }

            try
            {
                await _repository.Delete(category);
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
