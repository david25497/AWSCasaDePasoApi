using CasaDePasoAWSDemo.Core.Application.Config;
using CasaDePasoAWSDemo.Core.Application.DTOs.Login;
using CasaDePasoAWSDemo.Core.Application.Interfaces.IConfig;
using CasaDePasoAWSDemo.Core.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CasaDePasoAWSDemo.Presentation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service; // ✅ _camelCase y readonly
        private readonly IConfiguration _configuration; // ✅ _camelCase y readonly
       

        public LoginController(IConfiguration configuration, ILoginService service, ILogger<LoginController> logger)
        {
            _configuration = configuration;
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResult<string>))]
        public async Task<IActionResult> Login(LoginDTO loginDTO) // ✅ camelCase para parámetros
        {
            TokenConfigDTO tokenConfigDTO = new TokenConfigDTO
            {
                Key = _configuration["AuthSettings:key"],
                DurationInMinutes = _configuration["AuthSettings:DurationInMinutes"],
                Issuer = _configuration["AuthSettings:Issuer"],
                Audience = _configuration["AuthSettings:Audience"]
            };

            var response = await _service.LoginAsync(loginDTO, tokenConfigDTO);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResult<string>))]
        public async Task<IActionResult> Prueba() // ✅ camelCase para parámetros
        {
            Result<string> result = Result<string>.Success("Data", "Prueba Mensaje YAML");
            var response = result;
            return Ok(response);
        }
    }
}

