namespace Application.Wrappers;

public class Response<T>
{
    public Response()
    {

    }

    public Response(T data, string? message = null)
    {
        Succeeded = true;
        Message = message ?? string.Empty;
        Data = data;
        Errors = [];
    }

    public Response(string message)
    {
        Succeeded = false;
        Message = message;
        Data = default!;
        Errors = [];
    }

    public bool Succeeded { get; set; }

    public string Message { get; set; }

    public List<string> Errors { get; set; }

    public T Data { get; set; }
}
