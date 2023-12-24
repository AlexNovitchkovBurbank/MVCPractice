using System.Text.RegularExpressions;

namespace MVCPractice.Validators
{
    public class RecordPosterValidator : IRecordPosterValidator
    {
        public bool Validate(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            foreach (char character in name)
                if (!char.IsLetter(character))
                    return false;

            return true;
        }
    }
}