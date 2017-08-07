using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Xbox.Services
{
    internal static class JsonSerialization
    {
        internal static T FromJson<T>(string jsonInput)
        {
            return JsonConvert.DeserializeObject<T>(jsonInput);
        }

        internal static string ToJson<T>(T input)
        {
            return JsonConvert.SerializeObject(input);
        }
    }
}
