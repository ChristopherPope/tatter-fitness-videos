using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.Net.Http.Headers;
using TatterFitness.Bll.Interfaces.Services;

namespace TatterFitness.Videos.Controllers
{
    public class VideoController : Controller
    {
        private readonly IVideoService videoSvc;

        public VideoController(IVideoService videoSvc)
        {
            this.videoSvc = videoSvc;
        }

        public FileStreamResult Index(int id)
        {
            var videoData = videoSvc.ReadVideoData(id);
            var stream = new MemoryStream(videoData);
            var contentType = new MediaTypeHeaderValue("video/mp4");
            return new FileStreamResult(stream, contentType)
            {
                FileDownloadName = "workout.mp4"
            };

        }
    }
}
