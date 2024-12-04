using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalApp.Domain.Shared
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        public Result(T data)
        { 
            Success = true;
            Data = data;
        }

        private Result(string error) 
        {
            Success = false;
            Message = error;
        }

        public static Result<T> Ok(T data) => new(data);
        public static Result<T> OkMessage(string data) => new(data);
        public static Result<T> Fail(string error) => new(error);
    }
}
