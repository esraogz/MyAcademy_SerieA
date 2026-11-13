using Microsoft.AspNetCore.Mvc.ModelBinding;
using SerieA.WebUI.DTOs.Results;

namespace SerieA.WebUI.Extensions
{
    public static class ModelStateExtensions
    {
        public static void AddApiErrors(this ModelStateDictionary modelState, ApiResult result)
        {
            foreach (var (field, messages) in result.FieldErrors)
                foreach (var message in messages)
                    modelState.AddModelError(field, message);      // input altı mesaj

            if (!string.IsNullOrEmpty(result.Message))
                modelState.AddModelError(string.Empty, result.Message); // genel mesaj
        }
    }
}
