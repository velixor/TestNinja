using System;
using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private readonly string _setupDestinationFile;
        private readonly IFileDownloader _fileDownloader;
        public InstallerHelper(string setupDestinationFile, IFileDownloader fileDownloader)
        {
            _setupDestinationFile = setupDestinationFile ?? throw new ArgumentNullException(nameof(setupDestinationFile));
            _fileDownloader = fileDownloader ?? throw new ArgumentNullException(nameof(fileDownloader));
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                var url = $"http://example.com/{customerName}/{installerName}";
                _fileDownloader.DownloadFile(url, _setupDestinationFile);
                
                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }
}