using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.MeetingCategories.Commands.UpdateMeetingCategory
{
    public class UpdateMeetingCategoryCommandHandler : IRequestHandler<UpdateMeetingCategoryCommand>
    {
        private readonly IMeetingCategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMeetingCategoryCommandHandler(IMeetingCategoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateMeetingCategoryCommand request)
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
