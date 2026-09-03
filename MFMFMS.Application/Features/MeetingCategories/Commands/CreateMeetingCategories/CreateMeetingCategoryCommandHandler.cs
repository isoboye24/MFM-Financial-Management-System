using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;
using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.MeetingCategories.Commands.CreateMeetingCategories
{
    public class CreateMeetingCategoryCommandHandler : IRequestHandler<CreateMeetingCategoryCommand, Guid>
    {
        private readonly IMeetingCategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateMeetingCategoryCommandHandler(IMeetingCategoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateMeetingCategoryCommand request)
        {
            bool exists = await _repository.Exists(request.Name);

            if (exists)
            {
                throw new CustomValidationException("The meeting category already exists.");
            }
            else
            {
                var category = new MeetingCategory(request.Name);

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
}
