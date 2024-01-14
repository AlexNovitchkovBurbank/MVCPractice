namespace MVCPractice.Utilities
{
    public class StringToGuidConverter : IStringToGuidConverter
    {
        public Guid Convert(string id)
        {
            if (id == null)
                throw new ArgumentNullException("id");

            if (!Guid.TryParse(id, out Guid idAsGuid))
                throw new ArgumentException("id string must be a guid");

            return idAsGuid;
        }
    }
}
