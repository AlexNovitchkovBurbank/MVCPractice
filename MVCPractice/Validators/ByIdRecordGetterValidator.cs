
namespace MVCPractice.Validators
{
    public class ByIdRecordGetterValidator : IByIdRecordGetterValidator
    {
        public bool Validate(string idAsString)
        {
            if (!Guid.TryParse(idAsString, out Guid idAsGuid))
                return false;

            return true;
        }
    }
}