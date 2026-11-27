using System.Net.Http.Headers;

namespace SerieA.WebUI.Handlers
{
    public class JwtTokenHandler(IHttpContextAccessor _httpContextAccessor) : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = _httpContextAccessor.HttpContext?.User.FindFirst("Token")?.Value;

            if(!string.IsNullOrEmpty(token) )
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
