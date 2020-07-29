using System.Collections.Generic;
using System.Linq;

namespace TestNinja.Mocking
{
    public class VideoRepository : IVideoRepository
    {
        public IQueryable<Video> GetUnprocessedVideos()
        {
            using var context = new VideoContext();

            return context.Videos
                .Where(video => !video.IsProcessed);
        }
    }
}