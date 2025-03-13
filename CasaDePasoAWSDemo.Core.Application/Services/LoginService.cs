using AutoMapper;
using CasaDePasoAWSDemo.Core.Application.Config;
using CasaDePasoAWSDemo.Core.Application.DTOs.Login;
using CasaDePasoAWSDemo.Core.Application.Interfaces.IConfig;
using CasaDePasoAWSDemo.Core.Application.Interfaces.IRepositories;
using CasaDePasoAWSDemo.Core.Application.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CasaDePasoAWSDemo.Core.Application.Services
{

    public class LoginService:ILoginService
    {
        private readonly ILoginRepository _repository;    
        private readonly ITokenServices _service;

        public LoginService(ILoginRepository repository, ITokenServices service)
        {
            _repository = repository;
            _service = service;
        }

        public async Task<IResult<string>> LoginAsync(LoginDTO loginDTO, TokenConfigDTO tokenConfigDTO)
        {
            try
            {
                var resultUser = await _repository.GetUserAccess(loginDTO.User, loginDTO.Password);

                if (resultUser == null)
                    return Result<string>.Fail("Se ha producido un error al recuperar la información");

                if (!resultUser.Successed)
                    return Result<string>.Fail(resultUser.Message);
                
                var resultPermissions = await _repository.GetUserPermissions(resultUser.Data.IdRole);
               
                if (resultUser == null)
                    return Result<string>.Fail("Se ha producido un error al recuperar la información");
               
                if (!resultPermissions.Successed)
                    return Result<string>.Fail(resultPermissions.Message);                            

                var permissionsMenu = resultPermissions.Data.Select(item => new Claim("Permiso", item.IdPermission.ToString())).ToList();

                var token =  _service.GenerateToken( tokenConfigDTO, resultUser.Data.IdUser.ToString(), resultUser.Data.Name, resultUser.Data.IdRole.ToString(), resultUser.Data.Role, permissionsMenu);
                
                if(!token.Successed)
                    return Result<string>.Fail(resultUser.Message);

                return Result<string>.Success( token.Data, token.Message);
            }
            catch (Exception e)
            {

                return Result<string>.Fail("Se ha producido un error");

            }
        }
    }

}
