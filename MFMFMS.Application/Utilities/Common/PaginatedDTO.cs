namespace MFMFMS.Application.Utilities.Common
{
    public class PaginatedDTO<T>
    {
        public List<T> Items { get; set; } = [];
        public int TotalAmountOfRecords { get; set; }
    }
}
