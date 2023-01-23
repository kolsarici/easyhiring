namespace EasyHiring.ApiContract;

public class ResponseBase<T>
{
    public T Data { get; set; }
    public bool Success { get; set; }
    public string MessageCode { get; set; }
    public string Message { get; set; }
    public string UserMessage { get; set; }
}