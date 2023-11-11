using Microsoft.EntityFrameworkCore;
using NotesLayerApp.Core.Dto;
using System.Text.Json;

namespace NotesLayerApp.API.Middleware;

public class MyExceptionMiddleware
{

    private readonly RequestDelegate _next;

    public MyExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    private ErrorResponse GetErrorResponseDto(Exception ex)
    {
        var errorResponse = new ErrorResponse
        {
            ErrorMessage = ex.Message,
            StatusCode = 400,
        };

        return errorResponse;
    }

    private async Task WriteDtoInResponse(HttpContext context, ErrorResponse response)
    {
        context.Response.StatusCode = response.StatusCode;
        context.Response.ContentType = "application/json";
        var jsonResponse = JsonSerializer.Serialize(response);

        await context.Response.WriteAsync(jsonResponse);
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await WriteDtoInResponse(context, GetErrorResponseDto(ex));
        }
    }
}
