using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_FinalProje.Domain.Utilities.Concretes
{
    public class ErrorResult:Result
    {
        public ErrorResult() : base() { }
        public ErrorResult(string message):base(false,message) { }
            
        
    }
}
