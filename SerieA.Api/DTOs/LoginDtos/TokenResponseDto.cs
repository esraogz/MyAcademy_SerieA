namespace SerieA.WebApi.DTOs.LoginDtos
{
    public class TokenResponseDto
    {
        public string Token { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}
