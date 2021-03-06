﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web.Core;
using Windows.Security.Credentials;
using Windows.System;

namespace Microsoft.Xbox.Services.System
{
    internal class AccountProvider
    {
        private WebAccountProvider provider;

        public bool HasProvider { get { return provider != null; } }

        public async Task InitializeProvider(User user)
        {
            if (this.HasProvider)
            {
                return;
            }

            if (user == null)
            {
                provider = await WebAuthenticationCoreManager.FindAccountProviderAsync("https://xsts.auth.xboxlive.com");
            }
            else
            {
                provider = await WebAuthenticationCoreManager.FindAccountProviderAsync("https://xsts.auth.xboxlive.com", string.Empty, user);
            }
        }

        public virtual async Task<TokenRequestResult> RequestTokenAsync(WebTokenRequest request)
        {
            var result = await WebAuthenticationCoreManager.RequestTokenAsync(request);
            return new TokenRequestResult(result);
        }

        public virtual async Task<TokenRequestResult> GetTokenSilentlyAsync(WebTokenRequest request)
        {
            var result = await WebAuthenticationCoreManager.GetTokenSilentlyAsync(request);
            return new TokenRequestResult(result);
        }

        public WebTokenRequest CreateWebTokenRequest()
        {
            if (!this.HasProvider)
            {
                throw new XboxException("Xbox Live identity provider is not initialized");
            }
            return new WebTokenRequest(this.provider);
        }

        public async Task<WebAccount> FindAccountAsync(string webAccountId)
        {
            return await WebAuthenticationCoreManager.FindAccountAsync(this.provider, webAccountId);
        }
    }
}
