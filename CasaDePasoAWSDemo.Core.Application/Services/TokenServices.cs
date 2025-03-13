using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using CasaDePasoAWSDemo.Core.Application.DTOs.Login;
using CasaDePasoAWSDemo.Core.Application.Interfaces.IServices;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Logging;
using CasaDePasoAWSDemo.Core.Application.Interfaces.IConfig;
using CasaDePasoAWSDemo.Core.Application.Config;
namespace CasaDePasoAWSDemo.Core.Application.Services
{
    public class TokenServices : ITokenServices
    {

        public IResult<string> GenerateToken(TokenConfigDTO tokenConfigDTO, string idUser, string name, string idRol, string rol, List<Claim> permisosMenu)
        {
            try
            {
                var claims = new[]
                          {
                            new Claim(JwtRegisteredClaimNames.UniqueName, idUser),
                            new Claim("User", name),
                            new Claim("IdRol", idRol),
                            new Claim(ClaimTypes.Role, rol),
                            }.Union(permisosMenu);
               
                IdentityModelEventSource.ShowPII = true;
                var keybuffer = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfigDTO.Key));
                DateTime expireTime = DateTime.Now.AddMinutes(int.Parse(tokenConfigDTO.DurationInMinutes));
                var token = new JwtSecurityToken(issuer: tokenConfigDTO.Issuer, audience: tokenConfigDTO.Audience, claims, expires: expireTime, signingCredentials: new SigningCredentials(keybuffer, SecurityAlgorithms.HmacSha256));

                string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
                return Result<string>.Success(tokenAsString, "TOKEN");
            }
            catch (Exception e)
            {

                return Result<string>.Fail("Error al generar el token: " + e.Message); 
            }

        }

    }
}
