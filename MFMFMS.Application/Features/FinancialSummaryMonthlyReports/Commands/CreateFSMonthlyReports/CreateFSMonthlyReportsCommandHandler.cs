using MFMFMS.Application.Contracts.Persistence;
using MFMFMS.Application.Contracts.Repositories;
using MFMFMS.Application.Exceptions;
using MFMFMS.Application.Utilities;
using MFMFMS.Domain.Entities;

namespace MFMFMS.Application.Features.FinancialSummaryMonthlyReports.Commands.CreateFSMonthlyReports
{
    public class CreateFSMonthlyReportsCommandHandler : IRequestHandler<CreateFSMonthlyReportsCommand, Guid>
    {
        private readonly IFinancialSummaryMonthlyReportRepository _repository;
        private readonly IGivingRepository _givingRepository;
        private readonly IExpenditureRepository _expenditureRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateFSMonthlyReportsCommandHandler(
            IFinancialSummaryMonthlyReportRepository repository,
            IGivingRepository givingRepository,
            IExpenditureRepository expenditureRepository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _givingRepository = givingRepository;
            _expenditureRepository = expenditureRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateFSMonthlyReportsCommand request)
        {
            bool exists = await _repository.Exists(request.Year, request.Month);

            if (exists)
            {
                throw new CustomValidationException("The Report already exists.");
            }

            // Get monthly income
            var totalIncomeAmount = await _givingRepository.GetMonthlyGivingStatistics(request.Month, request.Year);
            var totalIncome = totalIncomeAmount.MonthlyOtherIncome + totalIncomeAmount.MonthlyOfferings + totalIncomeAmount.MonthlySeeds + totalIncomeAmount.MonthlyTithes;

            // Get monthly expenditure
            var totalExpenditureAmount = await _expenditureRepository.GetMonthlyExpenditureStatistics(request.Month, request.Year);
            var totalExpenditure = totalExpenditureAmount.MonthlyExpenditures;

            var report = new FinancialSummaryMonthlyReport(request.Year, request.Month, request.OpeningBalance);

            report.SetTotals(totalIncome, totalExpenditure);

            try
            {
                var result = await _repository.Add(report);

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
