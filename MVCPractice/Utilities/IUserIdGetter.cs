namespace MVCPractice.Utilities
{
    public interface IUserIdGetter
    {
        public string GetUserIdFromPayload(string pathWithId);
    }
}