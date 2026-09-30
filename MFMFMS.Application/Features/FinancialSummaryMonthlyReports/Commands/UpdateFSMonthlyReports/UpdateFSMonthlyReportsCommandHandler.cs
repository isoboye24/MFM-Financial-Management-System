using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Commands.UpdateFSMonthlyReports
{
    public class UpdateFSMonthlyReportsCommandHandler : IRequestHandler<UpdateFSMonthlyReportsCommand>
    {
        private readonly IFinancialSummaryMonthlyReportRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFSMonthlyReportsCommandHandler(IFinancialSummaryMonthlyReportRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateFSMonthlyReportsCommand request)
        {
            var report = await _repository.GetById(request.Id);

            if (report is null)
            {
                throw new NotFoundException("Report is required");
            }

            report.UpdateDate(request.Year, request.Month);
            report.UpdateOpeningBalance(request.OpeningBalance);

            try
            {
                await _repository.Update(report);
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
