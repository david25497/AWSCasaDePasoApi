namespace CasaDePasoAWSDemo.Core.Application.DTOs.Login
{
    public class TokenConfigDTO
    {
        public required string Key { get; set; }
        public required string DurationInMinutes { get; set; }
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
    }

}
