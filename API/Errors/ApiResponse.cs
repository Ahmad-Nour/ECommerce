using System;

namespace API.Errors
{
    public class ApiResponse
    {

        public ApiResponse(int statusCode, string message =null)
        {
            this.StatusCode = statusCode;
            this.Message = message ?? GetDefualyMessageForStatusCode(statusCode);

        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefualyMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 =>"A bad Request, you have made",
                401 =>"Authorized, you are not",
                404 =>"Resource found, it was not",
                500 =>"I hate Error..",
                _ => null
                                
            };
        }

    }
}