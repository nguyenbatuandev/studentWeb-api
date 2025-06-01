using System.Net;

namespace student.Models
{
    public class APIResponse
    {
        public bool Status {  get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public dynamic data { get; set; }
        public List<string> Errors { get; set; }
    }
}
