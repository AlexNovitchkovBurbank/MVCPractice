namespace MVCPractice
{
    public class Error
    {
        public Error()
        {
            Valid = true;
            Message = string.Empty;
        }

        public bool Valid { get; set; }
        public string Message { get; set; }
    }
}