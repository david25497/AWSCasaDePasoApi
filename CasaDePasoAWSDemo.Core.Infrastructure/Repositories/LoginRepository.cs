using CasaDePasoAWSDemo.Core.Application.Config;
using CasaDePasoAWSDemo.Core.Application.Interfaces.IConfig;
using CasaDePasoAWSDemo.Core.Application.Interfaces.IRepositories;
using CasaDePasoAWSDemo.Core.Application.Interfaces.IServices;
using CasaDePasoAWSDemo.Core.Domain.Functions.Modules.Login;
using CasaDePasoAWSDemo.Core.Infrastructure.Configurations.Persistence;
using CasaDePasoAWSDemo.Core.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CasaDePasoAWSDemo.Core.Infrastructure.Repositories.LoginRepository;

namespace CasaDePasoAWSDemo.Core.Infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly CasaDePasoContext _context;
        private readonly ErrorBD _errorBD;
        private readonly IPasswordHasherService _passwordHasher;
        public LoginRepository(CasaDePasoContext context, ErrorBD errorDBServices, IPasswordHasherService passwordHasher)
        {
            _context = context;
            _errorBD = errorDBServices;
            _passwordHasher= passwordHasher;
        }

        public async Task<IResult<Fn_GetUserAccess>> GetUserAccess(string userEmail, string password)
        {
            var parUserEmail = new Npgsql.NpgsqlParameter("p_email", userEmail);

            var sql = "SELECT * FROM casa_de_paso.fn_get_user_access(@p_email)";

            return await _errorBD.ExecuteOperationDB(async () =>
            {
                var result = await _context.GetUserAccess
                    .FromSqlRaw(sql, parUserEmail)
                    .FirstOrDefaultAsync();

                if(result==null)
                    throw new OperationFailedException("Usuario no encontrado");
               
                bool access= _passwordHasher.VerifyPassword(result.Password, password);
                
                if (access)
                {
                    result.Password = string.Empty;
                    return result;
                }
                throw new OperationFailedException("Contraseña Invalida");

            }, "Error en la consulta a la base de datos");

        }

        public async Task<IResult<IEnumerable<Fn_GetUserPermision>>> GetUserPermissions(int idRole)
        {
            var parIdRole = new Npgsql.NpgsqlParameter("p_id_role", idRole);

            var sql = "SELECT * FROM casa_de_paso.fn_get_user_permissions(@p_id_role)";

            return await _errorBD.ExecuteOperationDB(async () =>
            {
                var result = await _context.GetUserPermision
                    .FromSqlRaw(sql, parIdRole)
                    .ToListAsync();

                if (result.Any() != true)
                    throw new OperationFailedException("Sin Permisos Asignados");

                return result;

            }, "Error en la consulta a la base de datos");

        }

        public async Task<IResult<IEnumerable<Fn_GetUserPermision>>> GetUserHouses(int idUser)
        {
            var parIdUser = new Npgsql.NpgsqlParameter("p_id_user", idUser);

            var sql = "SELECT * FROM casa_de_paso.fn_get_user_houses(@p_id_user)";

            return await _errorBD.ExecuteOperationDB(async () =>
            {
                var result = await _context.GetUserPermision
                    .FromSqlRaw(sql, parIdUser)
                    .ToListAsync();

                if (result.Any() != true)
                    throw new OperationFailedException("Sin Sedes Asignadas");
               
                return result;

            }, "Error en la consulta a la base de datos");

        }


    }
}
