namespace ContactManangement.Middleware
{
    public class InternalResponse
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = string.Empty;

    }
}
