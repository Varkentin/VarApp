namespace VarApp.Core.Models.Common
{
    public class Result<TValue>
    {
        internal Result(bool success, TValue value)
        {
            Value = value;
            IsSuccessful = success;
        }

        internal Result(bool success)
        {
            IsSuccessful = success;
        }

        public TValue Value { get; }
        public bool IsSuccessful { get; }

        public static Result<TValue> Success(TValue value) => new(true, value);
        public static Result<TValue> Fail() => new(false);
    }
}
