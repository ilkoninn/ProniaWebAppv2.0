using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaWebApp.Business.Exceptions.Common
{
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException(string? message) : base(message) { }
        public ObjectNotFoundException() : base("There is no like object in data!") { }
    }
}
