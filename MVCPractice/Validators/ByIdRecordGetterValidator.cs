
namespace MVCPractice.Validators
{
    public class ByIdRecordGetterValidator : IByIdRecordGetterValidator
    {
        public bool Validate(string id)
        {
            if (!int.TryParse(id, out int idAsNumber))
                return false;

            return true;
        }
    }
}