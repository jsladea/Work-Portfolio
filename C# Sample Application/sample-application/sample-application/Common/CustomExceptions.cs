using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sampleApp.Common.CustomExceptions
{
    public class UserAccessException : System.Exception
    {
        public UserAccessException(string message) : base(message)
        {
        }
    }
}
