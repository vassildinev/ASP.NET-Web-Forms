namespace YouTubePlaylistsSystem.Data.Helpers
{
    public class UrlHelper
    {
        private const string EmbeddedUrlBeginning = "https://www.youtube.com/embed/";

        public string GetEmbeddedUrl(string url)
        {
            int startOfVideoId = url.IndexOf("=") + 1;
            string videoId = url.Substring(startOfVideoId);
            return string.Concat(EmbeddedUrlBeginning, videoId);
        }
    }
}
