using CasaDePasoAWSDemo.Core.Application.Config;
using CasaDePasoAWSDemo.Core.Application.Interfaces.IConfig;
using CasaDePasoAWSDemo.Core.Domain.Functions.Modules.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaDePasoAWSDemo.Core.Application.Interfaces.IRepositories
{
    public interface ILoginRepository
    {
        Task<IResult<Fn_GetUserAccess>> GetUserAccess(string userEmail, string password);

        Task<IResult<IEnumerable<Fn_GetUserPermision>>> GetUserPermissions(int idRole);
        Task<IResult<IEnumerable<Fn_GetUserPermision>>> GetUserHouses(int idUser);


    }
}
