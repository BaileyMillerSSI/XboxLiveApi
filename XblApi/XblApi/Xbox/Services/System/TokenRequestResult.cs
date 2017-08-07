using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web.Core;

namespace Microsoft.Xbox.Services.System
{
    internal class TokenRequestResult
    {
        public WebProviderError ResponseError { get; set; }

        public WebTokenRequestStatus ResponseStatus { get; set; }

        public IDictionary<string, string> Properties { get; set; }

        public WebProviderError ProviderError { get; set; }

        public string Token { get; set; }

        public string WebAccountId { get; set; }

        public TokenRequestResult(WebTokenRequestResult result)
        {
            if (result != null)
            {
                this.ResponseStatus = result.ResponseStatus;
                this.ResponseError = result.ResponseError;

                var responseData = result.ResponseData?.FirstOrDefault();
                if (responseData != null)
                {
                    this.Properties = responseData.Properties;
                    this.ProviderError = responseData.ProviderError;
                    this.Token = responseData.Token;
                    this.WebAccountId = responseData.WebAccount.Id;
                }
            }
        }
    }
}
