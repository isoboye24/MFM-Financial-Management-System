using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Commands.DeleteFSMonthlyReportsPermanently
{
    public class PermanentDeleteFSMonthlyReportCommandHandler : IRequestHandler<PermanentDeleteFSMonthlyReportCommand>
    {
        private readonly IFinancialSummaryMonthlyReportRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PermanentDeleteFSMonthlyReportCommandHandler(IFinancialSummaryMonthlyReportRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(PermanentDeleteFSMonthlyReportCommand request)
        {
            var report = await _repository.GetById(request.Id);

            if (report is null)
            {
                throw new NotFoundException("Report not found");
            }

            try
            {
                await _repository.DeletePermanently(report);
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
