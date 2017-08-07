using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Xbox.Services
{
    public partial class XboxLiveAppConfiguration
    {
        public const string FileName = "XboxServices.config";

        private static readonly object instanceLock = new object();
        private static XboxLiveAppConfiguration instance;

        public static XboxLiveAppConfiguration Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (instanceLock)
                    {
                        if (instance == null)
                        {
                            instance = Load();
                        }
                    }
                }
                return instance;
            }
        }

        private XboxLiveAppConfiguration()
        {
        }

        public string PublisherId { get; set; }

        public string PublisherDisplayName { get; set; }

        public string PackageIdentityName { get; set; }

        public string DisplayName { get; set; }

        public string AppId { get; set; }

        public string ProductFamilyName { get; set; }

        internal string EnvironmentPrefix { get; set; }

        internal bool UseFirstPartyToken { get; set; }

        public string PrimaryServiceConfigId { get; set; }

        public uint TitleId { get; set; }

        public string Sandbox { get; set; }

        public string Environment { get; set; }

        public bool XboxLiveCreatorsTitle { get; set; }

        public string GetEndpointForService(string serviceName, string protocol = "https")
        {
            return string.Format("{0}://{1}{2}.xboxlive.com", protocol, serviceName, string.IsNullOrEmpty(this.Environment) ? string.Empty : ("." + this.Environment));
        }

        public static XboxLiveAppConfiguration Load()
        {
            try
            {
                // Attempt to load it from a file
                return Load(FileName);
            }
            catch (Exception e)
            {
                // If we're unable to load the file for some reason, we can just use an empty file
                // if mock data is enable.
                if (XboxLive.UseMockServices || XboxLive.UseMockHttp)
                {
                    return new XboxLiveAppConfiguration();
                }

                throw new XboxException(string.Format("Unable to find or load Xbox Live configuration.  Make sure a properly configured {0} exists.", FileName), e);
            }
        }
    }
    public partial class XboxLiveAppConfiguration
    {
        public static XboxLiveAppConfiguration Load(string path)
        {
            Windows.ApplicationModel.Package package = Windows.ApplicationModel.Package.Current;
            Windows.Storage.StorageFolder installedLocation = package.InstalledLocation;

            string fullPath = Path.Combine(installedLocation.Path, path);
            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException(string.Format("Unable to find Xbox Live app configuration file '{0}'.", path));
            }

            string content = File.ReadAllText(fullPath);
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new XboxException(string.Format("Xbox Live app configeration file '{0}' was empty.", path));
            }

            return JsonSerialization.FromJson<XboxLiveAppConfiguration>(content);
        }
    }
}
