using CasaDePasoAWSDemo.Core.Application.DTOs.Login;
using CasaDePasoAWSDemo.Core.Application.Interfaces.IConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaDePasoAWSDemo.Core.Application.Interfaces.IServices
{
    public interface ILoginService
    {
        Task<IResult<string>> LoginAsync(LoginDTO loginDTO, TokenConfigDTO tokenConfigDTO);
    }
}
