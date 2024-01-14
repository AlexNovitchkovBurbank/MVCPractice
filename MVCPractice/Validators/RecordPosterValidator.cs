using System.Text.RegularExpressions;

namespace MVCPractice.Validators
{
    public class RecordPosterValidator : IRecordPosterValidator
    {
        public Error ValidateId(string idAsString)
        {
            var error =  new Error();

            if (!Guid.TryParse(idAsString, out var id))
            {
                error.Valid = false;
                error.Message = "id must be a guid";

                return error;
            }

            error.Valid = true;
            error.Message = "";

            return error;
        }

        public Error ValidateName(string name)
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