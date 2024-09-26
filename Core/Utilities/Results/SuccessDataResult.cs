using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace Core.Utilities.Results;

public class SuccessDataResult<T> : DataResult<T>
{
    public SuccessDataResult(T data, string message) : base(data, message, true)
    {
    }

    public SuccessDataResult(T data) : base(data, true)
    {
    }

    public SuccessDataResult(string message) : base(default, message, true)
    {
    }

    public SuccessDataResult() : base(default, default, true)
    {
    }
}