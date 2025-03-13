using CasaDePasoAWSDemo.Core.Application.DTOs.Login;
using CasaDePasoAWSDemo.Core.Application.Interfaces.IConfig;
using System.Security.Claims;

namespace CasaDePasoAWSDemo.Core.Application.Interfaces.IServices
{
    public interface ITokenServices
    {
        IResult<string> GenerateToken(TokenConfigDTO tokenConfigDTO, string idUser, string name, string idRol, string rol, List<Claim> permisosMenu);


    }
}
