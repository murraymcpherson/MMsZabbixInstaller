using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Security;
using System.Text;
using System.Threading;

// Concept and original design of this class goes to both
// CitizenInsane @ github https://gist.github.com/CitizenInsane/1739130
// and
// original solution by anandr_27 @ http://blogs.msdn.com/b/padmanr/archive/2010/05/08/execute-a-process-on-remote-machine-wait-for-it-to-exit-and-retrieve-its-exit-code-using-wmi.aspx

namespace MMsZabbixInstaller
{
 
    /// <summary>Performs various WMI operations.</summary>
    public static class WMIOperations
    {
        /// <summary>Runs some command.</summary>
        /// <param name="command">The command to run.</param>
        /// <param name="wmiScope"> The ManagementScope object to connect to. (default=none).</param>
        /// <param name="wait">Command's timeout expiration.</param>
        /// <remarks>IMPORTANT: 'domain/login/password' must have correct priviledges on the CIMV2 path ('Access denied' => see http://msdn.microsoft.com/en-us/library/windows/desktop/aa393613%28v=vs.85%29.aspx )</remarks>
        /// TODO: ?? Replace 'wait' parameter with some cancel callback ??
        public static int Run(string command,
                                ManagementScope wmiScope,
                                double wait = double.PositiveInfinity)
        {
            // We let internal functions check and make defaults
            if (double.IsNaN(wait) || (wait < 0.0)) { throw new ArgumentException("wait range is 1-9999"); }


            // Process survey
            var processId = new[] { (uint)0 };
            var exitCode = 0;
            var arguments = ((command ?? "")).Trim();
            var watcher = (ManagementEventWatcher)null;
            var scope = (ManagementScope)null;

            // Note for the following code by mmcpherson 2014/02/13: 
            // Originally I used the asynchronous implementation of WMI. Unfortunately using asynchronous would cause WMI access denied errors
            // if the source and target computers were not in the same domain!!! I could not find a simple solution for this.
            // 
            // I had to modify the solution so that it is now semi-synchronous, which is a compromise. Using this method prevents the UI
            // thread from freezing, and still allows for some feedback whether a remote process has started or stopped. This is reliant 
            // on that the WMI timeout period is set to wait for long enough of a time.

            try
            {
                // Connecting to WMI scope
                var span = TimeSpan.FromSeconds(0); // TODO: ?? relate to 'wait' or check cancel ??

                // Removing use of wmi scope options for my own built in RemoteConnect
                //scope = connectToWmiScope(machine, domain, username, password, securePassword, span);
                scope = wmiScope;
 
                // Begin process stop watcher
                Func<uint> getProcessId = () => processId[0];
                Action<int> setExitCode = (code) => exitCode = code;
           
                // Create the process
                processId[0] = createProcess(scope, arguments);

                // Create event query to be notified within 1 second of 
                // a change in a service
                WqlEventQuery query =
                    new WqlEventQuery("SELECT * From WIN32_ProcessStopTrace WHERE ProcessID=" + getProcessId());

                // Initialize an event watcher and subscribe to events 
                // that match this query
                watcher =
                    new ManagementEventWatcher(scope, query);
                // times out watcher.WaitForNextEvent in 5 seconds
                watcher.Options.Timeout = new TimeSpan(0, 0, (int)wait);


                // Block until the next event occurs 
                // Note: this can be done in a loop if waiting for 
                //        more than one occurrence 
                ManagementBaseObject e = watcher.WaitForNextEvent();
               
                //Cancel the subscription
                watcher.Stop();
                return exitCode;


  /*
   * // TODO: THe following can be implemented for detecting timeouts & restarted servers to prevent issues with timeout exceptions
   * http://stackoverflow.com/questions/12159989/asynchronous-wmi-event-handling-in-net
            ManagementEventWatcher w = new ManagementEventWatcher(managementScope, new WqlEventQuery("select * from Win32_ProcessStopTrace where ProcessId=" + ProcessId));
            w.Options.Timeout = new TimeSpan(0, 0, 0, 0, 1);
            DateTime start = DateTime.Now;
            while (Status == StatusNotStarted) //default status(just strings)
            {
                try
                {
                    var ev = w.WaitForNextEvent();
                    ReturnCode = (uint)ev.Properties["ExitStatus"].Value;
                    Status = (ReturnCode == 0) ? StatusOk : StatusFailed;
                }
                catch (ManagementException ex)
                {
                    if (!ex.Message.Contains("Timed out"))
                        throw ex;
                    try
                    {
                        Ping p = new Ping();
                        PingReply reply = p.Send(MachineIP);
                        if (reply.Status != IPStatus.Success)
                            Status = StatusFailed;
                        else
                        {
                            DateTime end = DateTime.Now;
                            TimeSpan duration = end - start;
                            if (duration.TotalMilliseconds > Timeout)
                            {
                                Status = StatusFailed;
                            }
                        }
                    }
   */
            }
 
        
            catch (Exception ex)
            {

                var msg = dumpRunArguments(command, wait);
                msg = string.Format("Command execution failed:\n{0}", msg);

                if (Log.WriteLog != null)
                {
                    Log.WriteLog("ERROR: " + msg);
                }

                if (ex is TimeoutException)
                {
                    if (Log.WriteLog != null)
                    {
                        Log.WriteLog("ERROR: Exception is timeout, trying to kill process: "+ ex.Message);
                    }

                    if ((scope != null) && (processId[0] != 0))
                    {
                        bool found;
                        tryKillProcess(scope, processId[0], out found);
                    }
                }
 
                throw new Exception(msg, ex);
            }
            finally
            {
                if (watcher != null)
                {
                    watcher.Stop();
                    watcher.Dispose();
                }
            }
         
        }
 
        private static string dumpRunArguments(string command, double wait)
        {
            command = command ?? "(null)";

            return string.Format(" > Command = {0}\n" +                                 
                                 " > Wait = {1}",
                                 command, wait);
        }

        private static uint createProcess(ManagementScope scope, string arguments)
        {
            var objectGetOptions = new ObjectGetOptions();
            var managementPath = new ManagementPath("Win32_Process");
            using (var processClass = new ManagementClass(scope, managementPath, objectGetOptions))
            {
                using (var inParams = processClass.GetMethodParameters("Create"))
                {
                    inParams["CommandLine"] = arguments;
                    using (var outParams = processClass.InvokeMethod("Create", inParams, null))
                    {
                        var err = (uint)outParams["returnValue"];
                        if (err != 0)
                        {
                            var info = "see http://msdn.microsoft.com/en-us/library/windows/desktop/aa389388(v=vs.85).aspx";
                            switch (err)
                            {
                                case 2: info = "Access Denied"; break;
                                case 3: info = "Insufficient Privilege"; break;
                                case 8: info = "Unknown failure"; break;
                                case 9: info = "Path Not Found"; break;
                                case 21: info = "Invalid Parameter"; break;
                            }
 
                            var msg = "Failed to create process, error = " + outParams["returnValue"] + " (" + info + ")";
                            Log.WriteLog(msg);
                            throw new Exception(msg);
                        }
                        Log.WriteLog("Successfully created process " + arguments + " with PID: " + (uint)outParams["processId"]);
                        return (uint)outParams["processId"];
                    }
                }
            }
        }
        private static bool tryKillProcess(ManagementScope scope, uint processId, out bool found)
        {
            found = false;
            var stopped = true;
 
            var sq = new SelectQuery("Select * from Win32_Process Where ProcessId = " + processId);
            using (var searcher = new ManagementObjectSearcher(scope, sq))
            {
                //searcher.Options.ReturnImmediately = true;
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    var errcode = (uint)queryObj.InvokeMethod("Terminate", null);
                    queryObj.Dispose();
 
                    found = true;
                    stopped &= (errcode == 0);
                }
            }
 
            return (found && stopped);
        }
    }
}
