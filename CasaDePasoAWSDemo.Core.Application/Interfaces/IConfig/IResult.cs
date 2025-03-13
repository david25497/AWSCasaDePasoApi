using CasaDePasoAWSDemo.Core.Application.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaDePasoAWSDemo.Core.Application.Interfaces.IConfig
{
    public interface IResult
    {
        bool Successed { get; }
        string Message { get; }
    }
    public interface IResult<out T> : IResult
    {
        T Data { get; }
    }
}
