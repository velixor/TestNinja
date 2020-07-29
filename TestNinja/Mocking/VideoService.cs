﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private readonly IFileReader _fileReader;
        private readonly IVideoRepository _videoRepository;

        public VideoService(IFileReader fileReader, IVideoRepository videoRepository)
        {
            _fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
            _videoRepository = videoRepository ?? throw new ArgumentNullException(nameof(videoRepository));
        }

        public string ReadVideoTitle()
        {
            var str = _fileReader.ReadFile("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            return video == null ? "Error parsing the video." : video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = _videoRepository.GetUnprocessedVideos().Select(x => x.Id);
            return string.Join(",", videoIds);
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}