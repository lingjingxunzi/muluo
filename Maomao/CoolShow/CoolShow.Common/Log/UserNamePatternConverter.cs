using System.IO;
using log4net.Core;
using log4net.Layout.Pattern;

namespace CoolShow.Common.Log
{
    internal sealed class UserNamePatternConverter : PatternLayoutConverter
    {
        override protected void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            LogMessage logMessage = loggingEvent.MessageObject as LogMessage;
            if (logMessage != null)
                writer.Write(logMessage.UserName);
        }
    }  
}
