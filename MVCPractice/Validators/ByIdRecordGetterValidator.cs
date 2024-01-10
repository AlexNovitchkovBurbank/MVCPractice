namespace MVCPractice.Validators
{
    public class ByIdRecordGetterValidator : IByIdRecordGetterValidator
    {
        public Error Validate(string idAsString)
        {
            var error = new Error();

            if (!Guid.TryParse(idAsString, out Guid idAsGuid))
            {
                error.Valid = false;
                error.Message = "id is not a guid";

                return error;
            }
            
            error.Valid = true;
            error.Message = "";

            return error;
        }
    }
}