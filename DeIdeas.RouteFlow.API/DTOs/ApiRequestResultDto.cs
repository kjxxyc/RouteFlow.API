using System.Net;

namespace DeIdeas.RouteFlow.API.DTOs
{
    public class ApiRequestResultDto<TResult>
    {
        public int HttpCode { get; set; } = (int)HttpStatusCode.OK;

        public TResult? Result { get; set; }

        public string? Message { get; set; }

        public bool Success { get; set; } = true;
    }
}
