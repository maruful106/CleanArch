using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Responses
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }
        public int StatusCode { get; set; }

        public BaseResponse(T data, int statusCode)
        {
            Success = true;
            Data = data;
            Errors = null;
            StatusCode = statusCode;
        }

        public BaseResponse(List<string> errors, int statusCode)
        {
            Success = false;
            Data = default;
            Errors = errors;
            StatusCode = statusCode;
        }
    }
}
