using System.Collections.Generic;
using System.Linq;

namespace TestNinja.Mocking
{
    public interface IVideoRepository
    {
        IQueryable<Video> GetUnprocessedVideos();
    }
}