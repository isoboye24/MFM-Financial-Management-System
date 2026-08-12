using MFMFMS.Application.Utilities;

namespace MFMFMS.Application.Features.Givings.Commands.CreateGivings
{
    public class CreateGivingCommand : IRequest<Guid>
    {
        public required decimal Amount { get; set; }
        public required DateTime Date { get; set; }
        public required string Summary { get; set; }
        public required Guid MeetingId { get; set; }
        public required Guid CategoryId { get; set; }
    }
}
