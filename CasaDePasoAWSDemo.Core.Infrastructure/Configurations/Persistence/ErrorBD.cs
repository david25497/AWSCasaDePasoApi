using CasaDePasoAWSDemo.Core.Application.Config;
using CasaDePasoAWSDemo.Core.Application.Interfaces.IConfig;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaDePasoAWSDemo.Core.Infrastructure.Configurations.Persistence
{
    public class ErrorBD
    {
        public async Task<IResult<T>> ExecuteOperationDB<T>(Func<Task<T>> dbOperation, string message = null)
        {
            try
            {
                message ??= "Sin registros encontrados";
                var result = await dbOperation();
                if (result == null )
                {
                    return result == null ? Result<T>.Fail(message) : Result<T>.Success(result);
                }

                return result == null ? Result<T>.Fail(message) : Result<T>.Success(result);
            }
            catch (PostgresException ex)
            {
                return Result<T>.Fail(ex.SqlState == "P0001" ? $"Error: {ex.MessageText}" : "Error interno en BD");
            }
            catch (OperationFailedException ex)
            {
                return Result<T>.Fail($"Error: {ex.Message}");
            }
            catch (Exception e)
            {
                return Result<T>.Fail("Error desconocido en BD");
            }
        }
    }
}
