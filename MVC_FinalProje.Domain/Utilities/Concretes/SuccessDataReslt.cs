using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_FinalProje.Domain.Utilities.Concretes
{
    public  class SuccessDataResult<T>:DataResult<T> where T: class
    {
        public SuccessDataResult() : base(default, false) { }
        public SuccessDataResult(string message) : base(default, false, message) { }
        public SuccessDataResult(T data, string message) : base(data, false, message) { }

    }
}
