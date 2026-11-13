namespace SerieA.WebUI.DTOs.ErrorDtos
{
    // API'nin ProblemDetails formatındaki hata cevabı (iş kuralı: Detail, doğrulama: Errors)
    public class ApiErrorDto
    {
        public int Status { get; set; }
        public string? Title { get; set; }
        public string? Detail { get; set; }
        public Dictionary<string, string[]>? Errors { get; set; }
    }
}
