namespace YoutubeDownloader.Logging;

public interface IYoutubeLogger
{
    void Log(string message);
    void Log(string message, Exception exception);
    void Log(Exception exception);
    void Log(Exception exception, string message);
    event EventHandler<string> OnLogArrives;

}