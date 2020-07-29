using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _videoService;
        private Mock<IFileReader> _fileReader;
        private Mock<IVideoRepository> _videoRepository;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _videoRepository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReader.Object, _videoRepository.Object);
        }
        
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            _fileReader.Setup(fr => fr.ReadFile("video.txt")).Returns("");
            
            Assert.That(_videoService.ReadVideoTitle(), Does.Contain("error").IgnoreCase);
        }
        
        [Test]
        public void GetUnprocessedVideosAsCsv_FewUnprocessedVideos_ReturnScvIds()
        {
            var videos = new List<Video>
            {
                new Video{Id = 1},
                new Video{Id = 2},
                new Video{Id = 3}
            };
            _videoRepository.Setup(x => x.GetUnprocessedVideos()).Returns(videos.AsQueryable);
            
            Assert.That(_videoService.GetUnprocessedVideosAsCsv(), Is.EqualTo("1,2,3"));
        }
        
        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosProcessed_ReturnEmptyString()
        {
            var videos = Enumerable.Empty<Video>();
            _videoRepository.Setup(x => x.GetUnprocessedVideos()).Returns(videos.AsQueryable);
            
            Assert.That(_videoService.GetUnprocessedVideosAsCsv(), Is.EqualTo(string.Empty));
        }
    }
}