namespace MVCPractice.Validators
{
    public interface IRecordPosterValidator
    {
        public Error ValidateId(string idAsString);
        public Error ValidateName(string name);
    }
}