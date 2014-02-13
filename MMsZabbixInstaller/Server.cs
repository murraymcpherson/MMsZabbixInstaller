using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Management;
using System.Windows.Forms;
using System.IO;

namespace MMsZabbixInstaller
{
    [Serializable]
    public class Server
    {
        // DONE: Remove domain username password paramaters
        public Server(string computerName)
        {
            this.computerName = computerName;
            zabbixAgentVersion = "Not Checked";
            zabbixServiceState = "Not Checked";
            osArch = "Not Checked";
            zabbixAgentPath = "";
            zabbixConfigPath = "";
            statusOfLastAction = "";
            customConfigSelected = false;
            customisation = "";
        }

        private string computerName;
        public string ComputerName { get { return computerName; } }
        private string zabbixAgentVersion;
        public string ZabbixAgentVersion { get { return zabbixAgentVersion; } }
        private string zabbixServiceState;
        public string ZabbixServiceState { get { return zabbixServiceState; } }
        private string zabbixAgentPath;
        public string ZabbixAgentPath { get { return zabbixAgentPath; } }
        private string zabbixConfigPath;
        public string ZabbixConfigPath { get { return zabbixConfigPath; } }
        private string osArch;
        public string OSArch { get { return osArch; } }
        private string statusOfLastAction;
        public string StatusOfLastAction { get { return statusOfLastAction; } }
        private bool customConfigSelected;
        public bool CustomConfigSelected { get { return customConfigSelected; } set { customConfigSelected = value; } }
        private string customisation;
        public string Customisation { get { return customisation; } }

        [NonSerialized]
        private BackgroundWorker bw;

        public void CancelThreads()
        {
            if (bw != null)
            {
                bw.CancelAsync();
            }
        }
       
        // Configure the progress update event and delegate to provide visual feedback to the form while executing methods.
        public delegate void ProgressUpdate(bool finished);
        // The field keyword must be used here because we are marking an event as nonserialised.
        [field:NonSerialized]
        public event ProgressUpdate OnProgressUpdate;

        public void GetZabbixServiceInfo(RemoteConnect connection, bool refreshStatusOfLastAction)
        {
            // Create background worker to send WMI queries to another thread.
            bool finished = false;
            UpdateProgress(finished);
            bw = new BackgroundWorker();

            // this allows our worker to report progress during work
            bw.WorkerReportsProgress = true;

            // this allows us to cancel the thread and prevent an exception occuring
            // for events such as in when we need to quit the program
            bw.WorkerSupportsCancellation = true;

            // what to do in the background thread
            bw.DoWork += new DoWorkEventHandler(delegate(object o, DoWorkEventArgs args)
            {
                try
                {
                    ObjectQuery query;
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher();
                    int numberOfQueries = 3;

                    for (int i = 1; i <= numberOfQueries; i++)
                    {
                        if (bw.CancellationPending)
                        {
                            args.Cancel = true;
                            break;
                        }

                        if (refreshStatusOfLastAction == true)
                        {
                            this.statusOfLastAction = "";
                        }

                        switch (i)
                        {
                            case 1:
                                query = new ObjectQuery("Select * from Win32_OperatingSystem");
                                osArch = "Checking...";
                                bw.ReportProgress(i);
                                break;
                            case 2:
                                query = new ObjectQuery("SELECT * FROM Win32_Service Where Name = 'Zabbix Agent'");
                                zabbixServiceState = "Checking...";
                                bw.ReportProgress(i);
                                break;
                            case 3:
                                query = new ObjectQuery("SELECT * FROM CIM_DataFile WHERE name='" + zabbixAgentPath + "'");
                                zabbixAgentVersion = "Checking...";
                                bw.ReportProgress(i);
                                break;
                            default:
                                query = new ObjectQuery("");
                                break;
                        }

                        //Connect to server WMI scope and authenticate
                        connection.SetWMIScopeCIMv2(this);
                        connection.wmiScope.Connect();

                        switch (i)
                        {
                            case 1:
                                searcher = new ManagementObjectSearcher(connection.wmiScope, query);
                                WMIOperatingSystemSearcher(searcher);
                                if (osArch == "Checking...")
                                    osArch = "Not Detected";
                                break;
                            case 2:
                                searcher = new ManagementObjectSearcher(connection.wmiScope, query);
                                WMIServiceSearcher(searcher);
                                if (zabbixServiceState == "Checking...")
                                    zabbixServiceState = "Not Detected";
                                break;
                            case 3:
                                searcher = new ManagementObjectSearcher(connection.wmiScope, query);
                                WMIDataFileSearcher(searcher, connection);
                                if (zabbixAgentVersion == "Checking...")
                                    zabbixAgentVersion = "Not Detected";
                                break;
                            default:
                                break;
                        }

                        // Update the Form to display current values
                        bw.ReportProgress(i);                    
                        searcher.Dispose();
                    }
                }
                catch (ManagementException err)
                {
                    //MessageBox.Show("An error occured while querying for WMI data: " + err.Message);
                    statusOfLastAction = "An error occured while querying for WMI data: " + err.Message;
                    Console.WriteLine(err.ToString());
                    osArch = "Connection failed";
                }
                catch (System.UnauthorizedAccessException unauthorizedErr)
                {
                    // MessageBox.Show("Connection error " + "(user name or password might be incorrect): " + unauthorizedErr.Message);
                    statusOfLastAction = "WMI connection error - " + "access denied (incorrect credentials or insufficient privileges), error details: " + unauthorizedErr.Message;
                    Console.WriteLine(unauthorizedErr.ToString());
                    osArch = "Connection failed";
                }
                catch (System.Runtime.InteropServices.COMException COMExcepErr)
                {
                    // MessageBox.Show("Connection error " + "(The RPC server service may not be available), error details:" + COMExcepErr.Message);
                    statusOfLastAction = "WMI connection error " + "(The RPC server service may not be available), error details:" + COMExcepErr.Message;
                    Console.WriteLine(COMExcepErr.ToString());
                    osArch = "Connection failed";
                }


                if (statusOfLastAction == "")
                    statusOfLastAction = "Ok";

            });

            // what to do when worker completes its task (notify the user)
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
            delegate(object o, RunWorkerCompletedEventArgs args)
            {
                finished = true;
                UpdateProgress(finished);
            });

            // what to do when progress changed (update the progress bar for example)
            bw.ProgressChanged += new ProgressChangedEventHandler(
            delegate(object o, ProgressChangedEventArgs args)
            {
                UpdateProgress(finished);
            });
    
            
            bw.RunWorkerAsync();

            while (!(finished) && (!(bw.CancellationPending)))
            {
                // TODO: This is a terrible way to process threads, need to find a proper solution.
                Application.DoEvents();
                // Using thread.sleep here for 50ms will at least prevent the CPU from being wasted by this loop.
                Thread.Sleep(50 /* millisec */);
            }
        }


        public void getCustomisation()
        {
            // If no customisation has been created, load the default config file
            if (customisation == "")
                customisation = GlobalVariables.defaultConfig;

            using (Form3 form3 = new Form3())
            {
                form3.ServerCustomConfig = customisation;
                form3.ShowDialog();
                customisation = form3.ServerCustomConfig;

                if (customisation == "")
                    customisation = GlobalVariables.defaultConfig;
            }
            //Console.WriteLine("Contents of zabbix_agentd.conf =:");
            //Console.Write(customisation);

        }
        public void StartProgram(string nameOfProcess, RemoteConnect connection)
        {
            connection.SetWMIScopeCIMv2(this);
            connection.wmiScope.Connect();

            string[] processToRun = new[] { nameOfProcess };
            ManagementClass wmiProcess = new ManagementClass(connection.wmiScope, new ManagementPath("Win32_Process"), new ObjectGetOptions());
            wmiProcess.InvokeMethod("Create", processToRun);

        }

        public void UninstallZabbixService(RemoteConnect connection)
        {
            try
            {
                bool finished = false;
                UpdateProgress(finished);
                connection.SetWMIScopeCIMv2(this);
                string strCmd;
                

                bw = new BackgroundWorker();

                // this allows our worker to report progress during work
                bw.WorkerReportsProgress = true;

                // this allows us to cancel the thread and prevent an exception occuring
                // for events such as in when we need to quit the program
                bw.WorkerSupportsCancellation = true;

                // what to do in the background thread
                bw.DoWork += new DoWorkEventHandler(
                delegate(object o, DoWorkEventArgs args)
                {
                    if (bw.CancellationPending)
                    {
                        args.Cancel = true;
                    }

                    //Configure paths if not dected by service
                    if (zabbixAgentPath == "")
                    {
                        zabbixAgentPath = GlobalVariables.defaultDeployPath + GlobalVariables.defautl32BitAgentFileName;
                        zabbixAgentPath = zabbixAgentPath.Replace(@"\", @"\\");
                    }
                    if (zabbixConfigPath == "")
                    {
                        zabbixConfigPath = GlobalVariables.defaultDeployPath + GlobalVariables.defaultConfigFileName;
                        zabbixConfigPath = zabbixConfigPath.Replace(@"\", @"\\");
                    }


                    //Stop Zabbix Service
                    strCmd = "\"" + zabbixAgentPath + "\" --config \"" + zabbixConfigPath + "\" --stop";
                    runCommand(strCmd.Replace(@"\\", @"\"), connection.wmiScope);

                    //Uninstall Zabbix Service
                    strCmd = "\"" + zabbixAgentPath + "\" --config \"" + zabbixConfigPath + "\" --uninstall";
                    runCommand(strCmd.Replace(@"\\", @"\"), connection.wmiScope);                  

                });

                // what to do when worker completes its task (notify the user)
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                delegate(object o, RunWorkerCompletedEventArgs args)
                {
                    finished = true;
                    //UpdateProgress(finished);
                });


                bw.RunWorkerAsync();


                while (!(finished) && (!(bw.CancellationPending)))
                {
                    // TODO: This is a terrible way to process threads, need to find a proper solution.
                    Application.DoEvents();
                    // Using thread.sleep here for 50ms will at least prevent the CPU from being wasted by this loop.
                    Thread.Sleep(50 /* millisec */);
                }

                
            }
            catch (System.UnauthorizedAccessException unauthErr)
            {
                //DONE: Update the status of last action instead
                //MessageBox.Show("Insufficient permissions for computer: " + this.computerName + " Please try another credential. \n\nOriginating error message: " + unauthErr.Message);
                statusOfLastAction = "Insufficient permissions for computer: " + this.computerName + " Please try another credential. Originating error message: " + unauthErr.Message;
            }


        }

        public void DeployZabbixService(RemoteConnect connection, String agentFileName)
        {
            try
            {
                bool finished = false;
                UpdateProgress(finished);
                connection.SetWMIScopeCIMv2(this);
                string strCmd;

                bw = new BackgroundWorker();

                // this allows our worker to report progress during work
                bw.WorkerReportsProgress = true;

                // this allows us to cancel the thread and prevent an exception occuring
                // for events such as in when we need to quit the program
                bw.WorkerSupportsCancellation = true;

                // what to do in the background thread
                bw.DoWork += new DoWorkEventHandler(
                delegate(object o, DoWorkEventArgs args)
                {
                    if (bw.CancellationPending)
                    {
                        args.Cancel = true;
                    }

                    //Install Zabbix Service
                    strCmd = "\"" + GlobalVariables.defaultDeployPath + agentFileName + "\" --config \"" +
                        GlobalVariables.defaultDeployPath + GlobalVariables.defaultConfigFileName + "\" --install";
                    runCommand(strCmd.Replace(@"\\", @"\"), connection.wmiScope);

                    //Start Zabbix Service
                    strCmd = "\"" + GlobalVariables.defaultDeployPath + agentFileName + "\" --config \"" +
                        GlobalVariables.defaultDeployPath + GlobalVariables.defaultConfigFileName + "\" --start";
                    runCommand(strCmd.Replace(@"\\", @"\"), connection.wmiScope);
                    
                });


                // what to do when worker completes its task (notify the user)
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                delegate(object o, RunWorkerCompletedEventArgs args)
                {
                    finished = true;
                    //UpdateProgress(finished);
                });

                bw.RunWorkerAsync();


                while (!(finished) && (!(bw.CancellationPending)))
                {
                    // TODO: This is a terrible way to process threads, need to find a proper solution.
                    Application.DoEvents();
                    // Using thread.sleep here for 50ms will at least prevent the CPU from being wasted by this loop.
                    Thread.Sleep(50 /* millisec */);
                }

                //Copy files NOTE: This method does work to copy remote files, but ended up instead preferring the use of NetworkShareAccesserClass. The following method requies the use of xcopy to pull files from client to server, and thus requiring additional credential validation on the client computer.
                /*
                strCmd = "cmd /C net use \"\\\\computername.contoso.com\\c$\" /user:domain\\username password /yes && xcopy /Y \"\\\\computername.contoso.com\\c$\\testfile.txt\" \"" + GlobalVariables.defaultDeployPath + "\" && net use \"\\\\computername.contoso.com\\c$\" /delete /yes";
                inParams["CommandLine"] = strCmd;
                Console.WriteLine("Deploy cmd: {0}", strCmd);
                outParams = wmiProcess.InvokeMethod("Create", inParams, null);
                Console.WriteLine(outParams["returnvalue"]);
                Console.WriteLine(outParams["processid"]);
                 * */


            }
            catch (System.UnauthorizedAccessException unauthErr)
            {
                //DONE: Update the status of last action instead
                //MessageBox.Show("Insufficient permissions for computer: " + this.computerName + " Please try another credential. \n\nOriginating error message: " + unauthErr.Message);
                statusOfLastAction = "Insufficient permissions for computer: " + this.computerName + " Please try another credential. Originating error message: " + unauthErr.Message;
                Console.WriteLine(unauthErr);
            }
        }

        private void runCommand(string strCmd, ManagementScope wmiScope)
        {
            try
            {
                var exitStatus = WMIOperations.Run(strCmd, wmiScope, wait: (double)GlobalVariables.WMItimeOut);
                Console.WriteLine(exitStatus);

                if (exitStatus == 0)
                {
                    this.statusOfLastAction = "Ok";
                }
                else
                {
                    this.statusOfLastAction = "Error starting service, please check and confirm config and server has no issues";
                }
            }
            catch (Exception ex)
            {
                var inn = ex;
                while (inn != null)
                {
                    Console.WriteLine(ex.GetType() + ": " + inn.Message);
                    this.statusOfLastAction = (inn.Message);
                    inn = inn.InnerException;
                }
            }

        }

         private void WMIServiceSearcher(ManagementObjectSearcher searcher)
        {
            try
            {

                foreach (ManagementObject queryObj in searcher.Get())
                {

                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Win32_Service instance");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Caption: {0}", queryObj["Caption"]);
                    Console.WriteLine("Description: {0}", queryObj["Description"]);
                    Console.WriteLine("Name: {0}", queryObj["Name"]);
                    Console.WriteLine("PathName: {0}", queryObj["PathName"]);
                    Console.WriteLine("State: {0}", queryObj["State"]);
                    Console.WriteLine("Status: {0}", queryObj["Status"]);

                    zabbixServiceState = Convert.ToString(queryObj["State"]);
                    zabbixAgentPath = Convert.ToString(queryObj["PathName"]);
                    Match zabbixAgentPathArray = Regex.Match(zabbixAgentPath, @"([A-Za-z]:\\|\\\\).+\.[eE][xX][eE]");
                    zabbixAgentPath = zabbixAgentPathArray.Value;
                    zabbixAgentPath = zabbixAgentPath.Replace("\"", "");
                    zabbixAgentPath = zabbixAgentPath.Replace(@"\", @"\\");
                    zabbixConfigPath = zabbixAgentPath.Replace(".exe", ".conf");

                    //MessageBox.Show(zabbixAgentPath);
                }

            }
            catch (ManagementException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

        }

         private void WMIDataFileSearcher(ManagementObjectSearcher searcher, RemoteConnect connection)
        {
            try
            {
                foreach (ManagementObject queryObj in searcher.Get())
                {

                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("CIM_DataFile instance");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("File Caption: " +
                    Convert.ToString(queryObj["Caption"]));
                    Console.WriteLine("File Version: " +
                    Convert.ToString(queryObj["version"]));
                    Console.WriteLine("Archive: " + Convert.ToString(queryObj["Archive"]));
                    Console.WriteLine("Compressed: " +
                    Convert.ToString(queryObj["Compressed"]));
                    Console.WriteLine("File Name: " +
                    Convert.ToString(queryObj["FileName"]));
                    Console.WriteLine("File Extension: " +
                    Convert.ToString(queryObj["Extension"]));
                    Console.WriteLine("File Size: " +
                    Convert.ToString(queryObj["FileSize"]));
                    Console.WriteLine("File Type: " +
                    Convert.ToString(queryObj["FileType"]));
                    Console.WriteLine("Last Modified: " +
                    Convert.ToString(queryObj["LastModified"]));
                    Console.WriteLine("File Size: " +
                    Convert.ToString(queryObj["FileSize"]));
                    Console.WriteLine("Name: " + Convert.ToString(queryObj["Name"]));
                    Console.WriteLine("Path: " + Convert.ToString(queryObj["Path"]));
                    Console.WriteLine("Name: " + Convert.ToString(queryObj["Name"]));
                    Console.WriteLine("System: " + Convert.ToString(queryObj["System"]));
                    Console.WriteLine("Manufaturer: " +
                    Convert.ToString(queryObj["Manufacturer"]));

                    zabbixAgentVersion = Convert.ToString(queryObj["version"]);

                    // Try getting file version by running --service paramater on agent executable
                    if (zabbixAgentVersion == "")
                    {
                        try
                        {
                            //Assemble command string
                            string uncZabbixAgentPath = zabbixAgentPath.Replace(@":", @"$");
                            uncZabbixAgentPath = @"\\" + this.computerName + @"\\" + uncZabbixAgentPath;
                            string strCmd = "\"" + uncZabbixAgentPath + "\""; 
                            string strArgs =  "--version";
                            Console.WriteLine("Running command to get Zabbix Agent Version: " + strCmd + " " + strArgs);   
                            Log.WriteLog("Running command to get Zabbix Agent Version: " + strCmd + " " + strArgs);   

     
                            //Set and start process object for command
                            //Note: a command window will pop open and close, this is impossible to prevent when using any of the following properties:
                            //StartInfo.UserName != null (has been set in RemoteConnect)
                            //StartInfo.Password != null (has been set in RemoteConnect)
                            //StartInfo.UseShellExecute = true;
                            connection.pProcess.StartInfo.FileName = strCmd;
                            connection.pProcess.StartInfo.Arguments = strArgs;
                            connection.pProcess.StartInfo.UseShellExecute = false;
                            connection.pProcess.StartInfo.RedirectStandardOutput = true;
                            connection.pProcess.StartInfo.RedirectStandardError = true;
                            connection.pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            connection.pProcess.StartInfo.CreateNoWindow = true;
                            connection.pProcess.Start();
                            string strOutput = connection.pProcess.StandardOutput.ReadToEnd();
                            connection.pProcess.WaitForExit();
                            Console.WriteLine("strOutput" + strOutput);

                            //Set zabbixAgentVersion to substring of output
                            string[] substrings = strOutput.Split(')');
                            zabbixAgentVersion = substrings[1].TrimStart() + ')';
                            Console.WriteLine("Setting Zabbix Agent Version To: " + zabbixAgentVersion);

                            if (zabbixAgentVersion != "")
                                Log.WriteLog("INFO: Unable to get zabbix version info from file properties (agent version < v2.0), trying to determine using --version parameter on agent. (Note: You will see a command window quickly pop open and close again)");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            Log.WriteLog("INFO: Could not get zabbix version from service zabbix_agentd.exe --version paramater. Note: zabbix_agentd.exe --version is invoked from local computer, therefore this function will only work if account specified under setup tab also has permission to the local computer." + "\r\nOriginating error message: " + ex.Message);
                        }
                    }
                }

            }
            catch (ManagementException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

        }

        private void WMIOperatingSystemSearcher(ManagementObjectSearcher searcher)
        {
            try
            {
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    String Ver = Convert.ToString(queryObj["version"]);
                    osArch = "32-bit";
                    if (Convert.ToSingle(Ver.Substring(0, 3)) >= 6.0)    //5.x doesn't support this property  
                    {
                        osArch = Convert.ToString(queryObj["OSArchitecture"]);
                    }
                }

            }
            catch (ManagementException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

        }

        private void UpdateProgress(bool finished)
        {
            if (OnProgressUpdate != null)
            {
                OnProgressUpdate(finished);
            }

        }

 
    }
}
