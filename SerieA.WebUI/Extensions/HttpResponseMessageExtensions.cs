using SerieA.WebUI.DTOs.ErrorDtos;
using SerieA.WebUI.DTOs.Results;
using System.Net.Http.Json;
using System.Text.Json;

namespace SerieA.WebUI.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<ApiResult> ToApiResultAsync(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return ApiResult.Success();


            ApiErrorDto? error = null;

            try { 
                error = await response.Content.ReadFromJsonAsync<ApiErrorDto>();
            }catch (JsonException) 
            {
                // gövde JSON değilse (ör. 500 HTML sayfası)
            }

            if (error?.Errors is { Count: > 0 })
                return ApiResult.ValidationFail(error.Errors);

            return ApiResult.Fail(error?.Detail ?? "İşlem sırasında bir hata oluştu");
        }
    }
}
