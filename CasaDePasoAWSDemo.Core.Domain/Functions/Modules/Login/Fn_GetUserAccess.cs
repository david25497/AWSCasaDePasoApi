using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaDePasoAWSDemo.Core.Domain.Functions.Modules.Login
{
    public class Fn_GetUserAccess
    {
        public int IdUser { get; set; }
        public required string Name { get; set; }
        public required string Password { get; set; }        
        public int IdRole { get; set; }
        public required string Role { get; set; }
        

        //si en la base de datos acepta null colocar 'string?' sino colocar solo strinh
    }
}
