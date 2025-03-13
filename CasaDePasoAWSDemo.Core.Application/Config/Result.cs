using CasaDePasoAWSDemo.Core.Application.Interfaces.IConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaDePasoAWSDemo.Core.Application.Config
{
    public class Result : IResult
    {
        public bool Successed { get; private set; }
        public string Message { get; private set; }

        private Result(bool success, string message)
        {
            Successed = success;
            Message = message;
        }

        public static Result Success(string message = "")
        {
            return new Result(true, message);
        }

        public static Result Fail(string message)
        {
            return new Result(false, message);
        }
    }

    public class Result<T> : IResult<T>
    {
        public bool Successed { get; private set; }
        public string Message { get; private set; }
        public T Data { get; private set; }

        private Result(bool success, T data, string message)
        {
            Successed = success;
            Data = data;
            Message = message;
        }

        public static Result<T> Success(T data, string message = "")
        {
            return new Result<T>(true, data, message);
        }

        public static Result<T> Fail(string message)
        {
            return new Result<T>(false, default, message);
        }
    }


}
