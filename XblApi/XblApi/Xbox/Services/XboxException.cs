using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Xbox.Services
{
    public class XboxException : Exception
    {
        public XboxException()
        {
        }

        public XboxException(string message) : base(message)
        {
        }

        public XboxException(int HResult, string message) : base(message)
        {
            this.HResult = HResult;
        }

        public XboxException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
