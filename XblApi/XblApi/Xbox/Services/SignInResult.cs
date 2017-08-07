using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Xbox.Services
{
    public class SignInResult
    {
        public SignInResult(SignInStatus status)
        {
            this.Status = status;
        }

        public SignInStatus Status { get; internal set; }
    }
}
