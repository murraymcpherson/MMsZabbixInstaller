using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MMsZabbixInstaller
{

    static class GlobalVariables
    {

        public static string defaultConfigFileName = "zabbix_agentd.conf";
        public static string defaultConfigPath = (Directory.GetCurrentDirectory() + @"\");
        public static string defaultConfig; //This variable is initialsed in Form1.UpdateForm();
        public static string defautl32BitAgentFileName = "zabbix_agentd.exe";
        public static string defautl64BitAgentFileName = "zabbix_agentd.exe";
        public static string default32BitAgentPath = (Directory.GetCurrentDirectory() + @"\win32\");
        public static string default64BitAgentPath = (Directory.GetCurrentDirectory() + @"\win64\");
        public static string defaultDeployPath = @"C:\Program Files\Zabbix\";
        public static decimal WMItimeOut = 30;

    }
}
