using Azure;
using CleanArch.Application.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;

namespace CleanArch.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            BaseResponse<string> response;
            context.Response.ContentType = "application/json";

            switch (ex)
            {
                case ArgumentException argEx:
                    response = new BaseResponse<string>("Invalid input: " + argEx.Message, (int)HttpStatusCode.BadRequest);
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case KeyNotFoundException keyNotFoundEx:
                    response = new BaseResponse<string>("Resource not found: " + keyNotFoundEx.Message, (int)HttpStatusCode.NotFound);
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                case UnauthorizedAccessException unauthorizedEx:
                    response = new BaseResponse<string>("Unauthorized access: " + unauthorizedEx.Message, (int)HttpStatusCode.Unauthorized);
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;

                case InvalidOperationException invalidOpEx:
                    response = new BaseResponse<string>("Invalid operation: " + invalidOpEx.Message, (int)HttpStatusCode.BadRequest);
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case FormatException formatEx:
                    response = new BaseResponse<string>("Format error: " + formatEx.Message, (int)HttpStatusCode.BadRequest);
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case NotSupportedException notSupportedEx:
                    response = new BaseResponse<string>("Operation not supported: " + notSupportedEx.Message, (int)HttpStatusCode.BadRequest);
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                // Add more specific exceptions as needed

                default:
                    response = new BaseResponse<string>("An unexpected error occurred: " + ex.Message, (int)HttpStatusCode.InternalServerError);
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
        }
    }
}
