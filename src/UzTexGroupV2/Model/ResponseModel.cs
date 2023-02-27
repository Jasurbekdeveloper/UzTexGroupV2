using System.Text.Json;

namespace UzTexGroupV2.Model;

public class ResponseModel
{
    public int StatusCode { get; set; }
    public Exception Error { get; set; }
    public Object Data { get; set; }

    public bool Success
    {
        get => StatusCode / 100 == 2;
    }

    public ResponseModel(int statusCode, Exception exception)
    {
        this.StatusCode = statusCode;
        this.Error = exception;
    }

    public ResponseModel(int statusCode, Object data)
    {
        this.StatusCode = statusCode;
        this.Data = data;
    }

    public override string ToString()
    {
        return JsonSerializer
            .Serialize(this);
    }
}
