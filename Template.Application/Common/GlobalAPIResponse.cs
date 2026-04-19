using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.Common
{
    public class GlobalApiResponse<T>
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }

        public string? ErrorCode { get; set; } 

        public static GlobalApiResponse<T> SuccessResponse(T data, string message = "", int statusCode = 200)
            => new() { Success = true, Data = data, Message = message, StatusCode = statusCode };

        public static GlobalApiResponse<T> FailureResponse(
            string message,
            List<string>? errors = null,
            int statusCode = 500,
            string? errorCode = null)
            => new()
            {
                Success = false,
                Message = message,
                Errors = errors,
                StatusCode = statusCode,
                ErrorCode = errorCode
            };
    }
}
