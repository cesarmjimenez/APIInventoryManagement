using Application.Wrappers;
using System.Net;
using System.Text.Json;

namespace API.Middlewares;

public class ErrorHandlerMiddleware(RequestDelegate next)
{
    private static readonly JsonSerializerOptions s_jsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var responseModel = new Response<string>() { Succeeded = false, Message = error?.Message };

            switch (error)
            {
                case Application.Exceptions.ApiException e:
                    //custom application error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case Application.Exceptions.ValidationException e:
                    //custom application error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel.Errors = e.Errors;
                    break;

                case KeyNotFoundException e:
                    //not found error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                case UnauthorizedAccessException e:
                    //not found error
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;

                default:
                    //unnhandled error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(responseModel, s_jsonOptions);

            await response.WriteAsync(result);
        }
    }
}