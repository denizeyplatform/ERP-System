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
        public string? Message { get; set; }
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }

        public static GlobalApiResponse<T> SuccessResponse(T data, string message = "")
            => new() { Success = true, Data = data, Message = message };

        public static GlobalApiResponse<T> FailureResponse(string message, List<string>? errors = null)
            => new() { Success = false, Message = message, Errors = errors };
    }
}
