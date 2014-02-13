using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Management;
using System.Security;
using System.Windows.Forms;


namespace MMsZabbixInstaller
{
    public class RemoteConnect
    {
        
        public RemoteConnect (string domain, string username, string password)
        {
            // Build an options object for the remote connection 
            // for connecting to the remote machine with username and password
            this.options = new ConnectionOptions();
            this.domain = domain;
            // Username format: "username";
            if (domain.Length > 0)
            {
                this.options.Username = domain + @"\" + username;
                workgroupComputer = false;
                this.options.Authentication = AuthenticationLevel.PacketPrivacy;
                this.options.Impersonation = ImpersonationLevel.Impersonate;
                this.options.EnablePrivileges = true;
                //Leave the timeout value at default this.options.Timeout = new TimeSpan(0, 0, 120);

                //Initialise Process object for querying zabbix server agent version info, if needed:
                pProcess = new Process();
                pProcess.StartInfo.Domain = domain;
                pProcess.StartInfo.UserName = username;
            }
            else
            {
                // TODO: Implement the following option to connect to a workgroup computer
                this.options.Username = username;
                workgroupComputer = true;
                //this.options.Authentication = AuthenticationLevel.Packet;
                //this.options.Impersonation = ImpersonationLevel.Impersonate;
                //this.options.EnablePrivileges = true;
            }
            // Password format: "Password";
            var secure = new SecureString();
            foreach (char c in password)
            {
                secure.AppendChar(c);
            }
            this.options.SecurePassword = secure;
            pProcess.StartInfo.Password = secure;

            secure = null;
         }

        private string domain;
        private bool workgroupComputer;
        private ConnectionOptions options;
        public ManagementScope wmiScope;
        public Process pProcess;

        public void SetWMIScopeCIMv2(Server server)
        {
            
            /*
            if (workgroupComputer)
            {
                this.options.Authority = "NTLMDomain:" + server.ComputerName;
            }
            else
            {
                this.options.Authority = "NTLMDomain:" + this.domain;
            }
             */
             

            // WMI connection string for \root\cimv2 
            wmiScope = new ManagementScope("\\\\" + server.ComputerName + "\\root\\cimv2", this.options);
            
        }

    }
}
