using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeDownloader.Logging;

namespace YoutubeDownloader
{
    internal class LoggingService : IYoutubeLogger
    {
        public void Log(string message)
        {
            OnLogArrives?.Invoke(this, message);
        }

        public void Log(string message, Exception exception)
        {
            throw new NotImplementedException();
        }

        public void Log(Exception exception)
        {
            throw new NotImplementedException();
        }

        public void Log(Exception exception, string message)
        {
            throw new NotImplementedException();
        }

        public event EventHandler<string>? OnLogArrives;
    }
}
