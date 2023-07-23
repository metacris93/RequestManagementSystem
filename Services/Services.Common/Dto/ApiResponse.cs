using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Dto;

public class ApiResponse<T>
{
    public bool Succeeded { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }
    public IDictionary<string, string>? Errors { get; set; }
    public ApiResponse() { }
    public ApiResponse(T data, string message = "")
    {
        Succeeded = true;
        Message = message;
        Data = data;
    }
    public ApiResponse(T data, string message, bool isOk)
    {
        Succeeded = isOk;
        Message = message;
        Data = data;
    }
    public ApiResponse(string message, bool isOk = false)
    {
        Message = message;
        Succeeded = isOk;
    }
    public ApiResponse(string message, IDictionary<string, string> errors, bool isOk = false)
    {
        Message = message;
        Succeeded = isOk;
        Errors = errors;
    }
}
