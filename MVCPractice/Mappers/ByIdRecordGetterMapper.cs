namespace MVCPractice.Mappers
{
    public class ByIdRecordGetterMapper : IByIdRecordGetterMapper
    {
        public Guid Map(string idAsString)
        {
            if (!Guid.TryParse(idAsString, out Guid result)) 
                throw new ArgumentException("id is not a guid in string format");

            var idAsGuid = Guid.Parse(idAsString);

            return idAsGuid;
        }
    }
}
