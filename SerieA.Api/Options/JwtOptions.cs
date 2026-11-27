namespace SerieA.WebApi.Options
{
    public class JwtOptions  
    {
        //Bu sınıf appsettings.json dosyasındaki jwt değerlerinin C# daki karşılığını tutuyor.
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public int ExpireInMinutes { get; set; }

    }
}
