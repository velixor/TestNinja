using System.IO;

namespace TestNinja.Mocking
{
    public class FileReader : IFileReader
    {
        public string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}