using System.Text.RegularExpressions;

namespace MVCPractice.Validators
{
    public class RecordPosterValidator : IRecordPosterValidator
    {
        public Error Validate(string name)
        {
            var error = new Error();

            if (string.IsNullOrWhiteSpace(name))
            {
                error.Valid = false;
                error.Message = "name cannot be null or only have whitespace";

                return error;
            }

            error.Valid = true;
            error.Message = "";

            return error;
        }
    }
}