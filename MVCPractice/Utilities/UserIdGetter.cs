namespace MVCPractice.Utilities
{
    public class UserIdGetter : IUserIdGetter
    {
        public string GetUserIdFromPayload(string pathWithId)
        {
            var valid = validate(pathWithId);

            if (!valid) 
                throw new Exception("could not parse lookup userId from the path");

            var partsOfPath = pathWithId.Split('/');

            return partsOfPath.Last();
        }

        private bool validate(string pathWithId) 
        {
            if (string.IsNullOrEmpty(pathWithId))
                return false;

            return true;
        }
    }
}
