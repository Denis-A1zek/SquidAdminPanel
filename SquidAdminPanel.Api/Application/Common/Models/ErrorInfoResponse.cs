using System.Net;

namespace SquidAdminPanel.Api.Application.Common.Models
{
    public class ErrorInfoResponse
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public HttpStatusCode StatusCodes { get; set; }
        public string Message { get; set; }
    }
}
