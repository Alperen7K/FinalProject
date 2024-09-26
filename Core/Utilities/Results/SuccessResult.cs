namespace Core.Utilities.Results;

public class SuccessResult : Result
{
    public SuccessResult(string message) : base(message, true)
    {
    }

    public SuccessResult(bool success) : base(true)
    {
    }

    public SuccessResult() : base(true)
    {
    }
}