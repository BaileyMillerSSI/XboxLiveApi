using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Xbox.Services
{
    public partial class XboxLive
    {
        public static bool UseMockServices
        {
            get { return false; }
        }

        public static bool UseMockHttp
        {
            get { return false; }
        }
    }
}
