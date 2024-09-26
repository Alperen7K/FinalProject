namespace Core.Utilities.Results;

public class ErrorResult:Result
{
    public ErrorResult( string message) : base(message,false)
    {
    }

    public ErrorResult(bool success) : base(false)
    {
    }
}