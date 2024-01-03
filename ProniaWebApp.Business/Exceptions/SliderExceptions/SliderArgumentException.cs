using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaWebApp.Business.Exceptions.SliderExceptions
{
    public class SliderArgumentException : Exception
    {
        public string ParamName { get; }
        public SliderArgumentException(string? message, string paramName) : base(message) 
        {
            ParamName = paramName;   
        }
    }
}
