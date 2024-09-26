namespace Core.Utilities.Results;

public class Result : IResult
{
    public Result(string message, bool success) : this(success)
    {
        this.Message = message;
    }

    public Result(bool success)
    {
        this.Success = success;
    }

    public bool Success { get; }
    public string Message { get; }
}