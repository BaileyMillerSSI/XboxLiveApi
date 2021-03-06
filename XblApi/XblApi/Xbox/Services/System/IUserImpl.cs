﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Xbox.Services.System
{
    internal interface IUserImpl
    {
        bool IsSignedIn { get; }
        string XboxUserId { get; }
        string Gamertag { get; }
        string AgeGroup { get; }
        string Privileges { get; }
        string WebAccountId { get; }
        AuthConfig AuthConfig { get; }
#if WINDOWS_UWP
        Windows.System.User CreationContext { get; }
#endif

        Task<SignInResult> SignInImpl(bool showUI, bool forceRefresh);

        Task<TokenAndSignatureResult> InternalGetTokenAndSignatureAsync(string httpMethod, string url, string headers, byte[] body, bool promptForCredentialsIfNeeded, bool forceRefresh);
    }
}
