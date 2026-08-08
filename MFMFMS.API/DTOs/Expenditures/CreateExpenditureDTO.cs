using System.ComponentModel.DataAnnotations;

namespace MFMFMS.API.DTOs.Expenditures
{
    public class CreateExpenditureDTO
    {
        [Required]
        public required string Summary { get; set; }
        [Required]
        public required decimal Amount { get; set; }
        [Required]
        public required DateTime Date { get; set; }
    }
}
