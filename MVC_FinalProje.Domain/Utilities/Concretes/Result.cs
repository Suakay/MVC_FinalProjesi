using MVC_FinalProje.Domain.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_FinalProje.Domain.Utilities.Concretes
{
    public class Result : IResult
    {
        public bool IsSuccess { get ;  }
        public string Message { get; }
        public Result()
        {
            IsSuccess = false;
            Message=string.Empty;   
        }
        public Result(bool isSucces)
        {
            IsSuccess=isSucces;
        }
        public Result(bool isSucces,string message): this(isSucces)
        {
            Message = message;    
                
                
        }
    }
}
