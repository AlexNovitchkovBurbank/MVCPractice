namespace MVCPractice.Utilities
{
    public class GuidCreator : IGuidCreator
    {
        public Guid Create()
        {
            return new Guid();
        }
    }
}
