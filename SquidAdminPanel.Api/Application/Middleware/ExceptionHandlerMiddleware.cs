using SquidAdminPanel.Api.Application.Common.Models;
using SquidAdminPanel.Api.Core.Exceptions;
using System.Net;
using System.Text.Json;

namespace SquidAdminPanel.Api.Application.Middleware;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _requestDelegate;

    public ExceptionHandlerMiddleware(RequestDelegate requestDelegate) =>
        _requestDelegate = requestDelegate;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _requestDelegate(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception) 
    {
        var errorInfo = new ErrorInfoResponse();
   
        switch (exception)
        {
            case NotFoundException notFoundException:
                errorInfo.StatusCodes = HttpStatusCode.NotFound;
                errorInfo.Title = HttpStatusCode.NotFound.ToString();
                errorInfo.Type = $"{context.Request.Host}{context.Request.Path}";
                errorInfo.Message = exception.Message;
                break;
            default:
                errorInfo.Type = $"{context.Request.Host}{context.Request.Path}";
                errorInfo.Message = exception.Message;
                errorInfo.Title = HttpStatusCode.InternalServerError.ToString();
                errorInfo.StatusCodes = HttpStatusCode.InternalServerError;
                break;
        }

        context.Response.ContentType = "application/json";
        var result = JsonSerializer.Serialize<ErrorInfoResponse>(errorInfo);

        return context.Response.WriteAsync(result);
    }
}
