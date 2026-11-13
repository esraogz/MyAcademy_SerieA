namespace SerieA.WebUI.DTOs.Results
{
    public class ApiResult
    {
        public bool IsSuccess { get; private set; }
        public string? Message { get; private set; } // iş kuralı hatası
        public Dictionary<string, string[]> FieldErrors { get; private set; } = new(); // doğrulama hataları

        public static ApiResult Success() => new() { IsSuccess = true };
        public static ApiResult Fail(string message) => new() { Message = message };
        public static ApiResult ValidationFail(Dictionary<string, string[]> errors) => new() { FieldErrors = errors };
    }
}
