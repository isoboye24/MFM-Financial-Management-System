using FluentValidation.Results;

namespace MFMFMS.Application.Exceptions
{
    public class CustomValidationException : Exception
    {
        public List<string> ValidatorErrors { get; set; } = [];

        public CustomValidationException(string errorMessage)
        {
            ValidatorErrors.Add(errorMessage);
        }

        public CustomValidationException(ValidationResult validationResult)
        {
            foreach (var validationError in validationResult.Errors)
            {
                ValidatorErrors.Add(validationError.ErrorMessage);
            }
        }
    }
}
