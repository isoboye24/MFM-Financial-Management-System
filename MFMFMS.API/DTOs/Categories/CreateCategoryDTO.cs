using System.ComponentModel.DataAnnotations;

namespace MFMFMS.API.DTOs.Categories
{
    public class CreateCategoryDTO
    {
        [Required]
        [StringLength(250, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        public required string Name { get; set; }
    }
}
