using System.Net;

namespace TestNinja.Mocking
{
    public interface IFileDownloader
    {
        void DownloadFile(string url, string destinationPath);
    }

    public class FileDownloader : IFileDownloader
    {
        public void DownloadFile(string url, string destinationPath)
        {
            using var client = new WebClient();
            client.DownloadFile(url, destinationPath);
        }
    }
}