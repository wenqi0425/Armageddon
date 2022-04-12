using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armageddon
{
    public class Trace
    {
        public static TraceSource Source = new("GameApp"); // application to be traced        
        static Trace()
        {
            string path = "C: /Users/wenqi/Desktop/4th Semester/1.ASW/Assignment/Armageddon/GameConfigration.xml";
            string fileName = "ArmageddonLog";
            string fullPath = Path.Combine(path, fileName);
            Source.Switch = new SourceSwitch("GameLog", "All");  // Title of the log file. 
            TraceListener listener = new TextWriterTraceListener(new StreamWriter(fullPath)); // name of the log file
            listener.Filter = new EventTypeFilter(SourceLevels.All);
            Source.Listeners.Add(listener);
        }
        public static void TraceLog(TraceEventType eventType,string message)
        {
            Source.TraceEvent(eventType, 1, message);
            Source.Close();           
        }
    }
}
