using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaDePasoAWSDemo.Core.Domain.Functions.Modules.Login
{
    public class Fn_GetUserPermision
    {
        public int IdPermission { get; set; }
        public required string Permission { get; set; }
    
    }
}
