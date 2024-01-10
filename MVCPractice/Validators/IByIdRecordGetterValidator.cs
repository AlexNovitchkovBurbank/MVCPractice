namespace MVCPractice.Validators
{
    public interface IByIdRecordGetterValidator
    {
        public Error Validate(string idAsString);
    }
}