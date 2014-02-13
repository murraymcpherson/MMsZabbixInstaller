using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMsZabbixInstaller
{
    class Log
    {
        //Write_Log event and delegate to send log messages back to form UI.
        public delegate void Write_Log(string logMessage);
        public static Write_Log WriteLog;


    }
}
