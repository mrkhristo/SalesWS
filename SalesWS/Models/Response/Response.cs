namespace SalesWS.Models.Response
{
    public class Response
    {
        public int Success { get; set; } = 0;

        public string Message { get; set; } = string.Empty;

        public object Data { get; set; }
    }
}
