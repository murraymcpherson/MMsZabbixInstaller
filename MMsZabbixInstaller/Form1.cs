using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;


namespace MMsZabbixInstaller
{
    public partial class Form1 : Form
    {
        string version = "1.0";
        List<Server> servers = new List<Server>();
        RemoteConnect connection;
        bool serverExists = false;
        bool fileExists = false;
        bool connected = false;
        bool exiting = false;


        public Form1()
        {
            InitializeComponent();
            // Load Event handlers
            this.Load += new EventHandler(Disabled_Buttons_DataGridView);
            Add_Form_Events();
            Log.WriteLog += Write_Log;

            //Update and Prepare Form For Use
            Textbox_Log.AppendText("Log Messages: \r\n");
            this.Text = "MM's Zabbix Agent Installer" + OpenFileDialog_LoadConfig.SafeFileName;
            NumericUpDown_WMITimeout.Value = GlobalVariables.WMItimeOut;
            UpdateForm();

            //Testing Calls
            //Form_Testing_Sandbox();
        }

        public void UpdateForm()
        {
            //Set initial label values
            Label_ShowDefaultConfig.Text = GlobalVariables.defaultConfigPath + GlobalVariables.defaultConfigFileName;
            Label_Selected32bitZabbixAgent.Text = GlobalVariables.default32BitAgentPath + GlobalVariables.defautl32BitAgentFileName;
            Label_Selected64bitZabbixAgent.Text = GlobalVariables.default64BitAgentPath + GlobalVariables.defautl64BitAgentFileName;

            //Note: File.ReadAllText uses 'using' block so closing file stream not neccessary
            //Check if default config file exists, otherwise let it known it is missing.
            if (File.Exists(GlobalVariables.defaultConfigPath + GlobalVariables.defaultConfigFileName))
                GlobalVariables.defaultConfig = File.ReadAllText(GlobalVariables.defaultConfigPath + GlobalVariables.defaultConfigFileName);
            else
                Label_ShowDefaultConfig.Text = "The default config file " + GlobalVariables.defaultConfigFileName + " could not be found in the folder " + GlobalVariables.defaultConfigPath;

            try
            {
                Label_AgentVersion32bit.Text = FileVersionInfo.GetVersionInfo(GlobalVariables.default32BitAgentPath + GlobalVariables.defautl32BitAgentFileName).FileVersion;

                if (Label_AgentVersion32bit.Text == "")
                {
                    //Assemble command string
                    Process pProcess = new Process();
                    string strCmd = GlobalVariables.default32BitAgentPath + GlobalVariables.defautl32BitAgentFileName;
                    string strArgs = "--version";

                    //Set and start process object for command
                    pProcess.StartInfo.FileName = strCmd;
                    pProcess.StartInfo.Arguments = strArgs;
                    pProcess.StartInfo.UseShellExecute = false;
                    pProcess.StartInfo.RedirectStandardOutput = true;
                    pProcess.StartInfo.RedirectStandardError = true;
                    pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    pProcess.StartInfo.CreateNoWindow = true;
                    pProcess.Start();
                    string strOutput = pProcess.StandardOutput.ReadToEnd();
                    pProcess.WaitForExit();
                    Console.WriteLine("strOutput" + strOutput);

                    //Set zabbixAgentVersion to substring of output
                    string[] substrings = strOutput.Split(')');
                    Label_AgentVersion32bit.Text = substrings[1].TrimStart() + ')';
                    Console.WriteLine("Setting Zabbix Agent Version To: " + Label_AgentVersion32bit.Text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Label_AgentVersion32bit.Text = "File does not exist at specified path";
            }

            try
            {
                Label_AgentVersion64bit.Text = FileVersionInfo.GetVersionInfo(GlobalVariables.default64BitAgentPath + GlobalVariables.defautl64BitAgentFileName).FileVersion;

                if (Label_AgentVersion64bit.Text == "")
                {
                    //Assemble command string
                    Process pProcess = new Process();
                    string strCmd = GlobalVariables.default64BitAgentPath + GlobalVariables.defautl64BitAgentFileName;
                    string strArgs = "--version";

                    //Set and start process object for command
                    pProcess.StartInfo.FileName = strCmd;
                    pProcess.StartInfo.Arguments = strArgs;
                    pProcess.StartInfo.UseShellExecute = false;
                    pProcess.StartInfo.RedirectStandardOutput = true;
                    pProcess.StartInfo.RedirectStandardError = true;
                    pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    pProcess.StartInfo.CreateNoWindow = true;
                    pProcess.Start();
                    string strOutput = pProcess.StandardOutput.ReadToEnd();
                    pProcess.WaitForExit();
                    Console.WriteLine("strOutput" + strOutput);

                    //Set zabbixAgentVersion to substring of output
                    string[] substrings = strOutput.Split(')');
                    Label_AgentVersion64bit.Text = substrings[1].TrimStart() + ')';
                    Console.WriteLine("Setting Zabbix Agent Version To: " + Label_AgentVersion64bit.Text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Label_AgentVersion64bit.Text = "File does not exist at specified path";
            }

        }

        public void Disabled_Buttons_DataGridView(object sender, EventArgs e)
        {
            // The following adds the buttons with modified ability to suppot being disabled.
            DataGridViewCheckBoxColumn column0 =
                new DataGridViewCheckBoxColumn();
            DataGridViewDisableButtonColumn column1 =
                new DataGridViewDisableButtonColumn();
            column0.Name = "Enable Customisation";
            column1.Name = "Custom Config";
            dataGridView1.Columns.Add(column0);
            dataGridView1.Columns.Add(column1);
            // Rowcount needs to be set to avoid an out-of-bounds exception
            dataGridView1.RowCount = 0;

            // The following code is needed to make all columns in the datagridview sortable
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                dataGridView1.Columns[column.Name].SortMode = DataGridViewColumnSortMode.Automatic;
            }

            //The following code is needed to make sure the text is visible in the datagridview (can sometimes default to white and become invisible)
            dataGridView1.ForeColor = Color.Black;
        }

        public void Add_Form_Events()
        {

            dataGridView1.CellValueChanged +=
                new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
            dataGridView1.CurrentCellDirtyStateChanged +=
                new EventHandler(dataGridView1_CurrentCellDirtyStateChanged);
            dataGridView1.CellClick +=
                new DataGridViewCellEventHandler(dataGridView1_CellClick);
        }

        private void Form_Testing_Sandbox()
        {

            /*
            //add some test server objects to the list
            add some test code here
             */

        }

         private void Button_ScanLDAPComputers_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                if (LDAPBaseSearchPathBox.Text.Length > 0)
                {
                    Panel_ConnectedState.BackColor = Color.PaleGoldenrod;
                    Label_ConnectedState.Text = "Status: Scanning...";
                    Application.DoEvents();

                    int index = LDAPBaseSearchPathBox.Text.IndexOf("LDAP://");
                    string LDAPConnectionString = LDAPBaseSearchPathBox.Text.Insert(index + "LDAP://".Length, Textbox_Domain.Text + "/");

                    DirectoryEntry myLdapConnection = createDirectoryEntry(LDAPConnectionString, Textbox_UserName.Text, Textbox_Password.Text);
                    DirectorySearcher myLdapSearcher = new DirectorySearcher(myLdapConnection);


                    // To find a single computer based on textbox entry
                    //myLdapSearcher.Filter = "(&(objectCategory=Computer)(cn=" + computerBox.Text + "))";
                    //SearchResult myLdapResult = myLdapSearcher.FindOne();
                    //MessageBox.Show(myLdapResult.GetDirectoryEntry().Properties["cn"].Value.ToString());

                    List<string> dnsComputerNames = new List<string>();

                    if (Checkbox_ScanServersOnly.Checked)
                        myLdapSearcher.Filter = ("(&(objectCategory=computer)(operatingSystem=*server*))");
                    else
                        myLdapSearcher.Filter = ("(objectClass=computer)");

                    myLdapSearcher.SizeLimit = int.MaxValue;
                    myLdapSearcher.PageSize = int.MaxValue;


                    try
                    {
                        // Removed ComputerName and added dnsComputerName instead..
                        string dnsComputerName;
                        foreach (SearchResult myLdapSearchResult in myLdapSearcher.FindAll())
                        {
                            serverExists = false;
                            // Example return value
                            //"CN=SGSVG007DC"
                            //string ComputerName = myLdapSearchResult.GetDirectoryEntry().Name;
                            dnsComputerName = myLdapSearchResult.GetDirectoryEntry().Properties["dNSHostName"].Value.ToString();
                            //if (ComputerName.StartsWith("CN="))
                            //   ComputerName = ComputerName.Remove(0, "CN=".Length);

                            // Confirm server in manual add textbox is not already in dataGridView
                            foreach (Server server in servers)
                            {
                                if (dnsComputerName.ToUpper() == server.ComputerName.ToUpper())
                                {
                                    serverExists = true;
                                }
                            }
                            // If the server doesn't exist in the dataGridView yet, add it to the list
                            if (!(serverExists))
                            {
                                dnsComputerNames.Add(dnsComputerName);
                            }
                        }
                    }
                    catch (System.Runtime.InteropServices.COMException COMexcepErr)
                    {
                        // TODO: A better messagebox with drop down crash details would be nice
                        MessageBox.Show("Problem connecting with LDAP, please confirm the search path is valid, and domain name is correct under connection settings: \n\nOriginating error message: " + COMexcepErr.Message);
                    }

                    myLdapSearcher.Dispose();
                    myLdapConnection.Dispose();

                    // Clear the items in the list
                    SelectComputerListBox.Items.Clear();
                    foreach (String computer in dnsComputerNames)
                    {
                        // Check comptuer exists already in list, if not add it.
                        // Had  to copy ListBox.Items to a string list in order to access the overloaded .Contains method.
                        List<string> listBoxItems = new List<string>(SelectComputerListBox.Items.Cast<string>().ToList());
                        if (!(listBoxItems.Contains(computer, StringComparer.CurrentCultureIgnoreCase)))
                            SelectComputerListBox.Items.Add(computer);
                    }

                    Panel_ConnectedState.BackColor = Color.LightGreen;
                    Label_ConnectedState.Text = "  Status: Connected";

                }
                else
                {
                    MessageBox.Show("Please supply a valid LDAP search path ");
                }
            }
            else
            {
                MessageBox.Show("Not connected to domain, please use connect feature found within the setup tab.");
            }
        }

        static DirectoryEntry createDirectoryEntry(string LDAPpath, string userName, string password)
        {
            // create and return new LDAP connection with desired settings  

            DirectoryEntry ldapConnection = new DirectoryEntry(LDAPpath, userName, password);
            ldapConnection.AuthenticationType = AuthenticationTypes.Secure;
            return ldapConnection;
 
        }

        private void Button_ShowConfig_Click(object sender, EventArgs e)
        {
            using (Form2 form2 = new Form2())
            {
                this.Hide();
                form2.ShowDialog();
                this.Show();
                UpdateForm();
            }
        }

        private void Button_Add_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                // Cycle through selected items in listbox (contains LDAP scanned computers) and add them
                if ((Textbox_UserName.Text.Length > 0) && (Textbox_Password.Text.Length > 0) && (Textbox_Domain.Text.Length > 0))
                {
                    DisableControls();
                    // TODO: Properly implement the checked state removal without all boxes unticking
                    Checkbox_SelectAll.Checked = false;

                    for (int i = 0; i < SelectComputerListBox.SelectedItems.Count; i++)
                    {
                        // If quitting program, then cancel operation
                        if (exiting)
                        {
                            break;
                        }

                        //Check if server alreay exists in datagridview
                        bool serverNotExist = true;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells[1].Value.ToString().Equals(SelectComputerListBox.SelectedItems[i].ToString()))
                            {
                                serverNotExist = false;
                                break;
                            }
                        }
                        if (serverNotExist)
                        {
                            // Given server doesn't already exist in datagridview, and instantiate remoteconnect property using credentials supplied).
                            servers.Add(new Server(SelectComputerListBox.SelectedItems[i].ToString()));
                            servers.Last().OnProgressUpdate += Servers_OnProgressUpdate;

                            addServerToDataGridView(servers.Last());
                            if (servers.Last().CustomConfigSelected == false)
                            {
                                // Set the text for each button. 
                                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Custom Config"].Value = "None";

                            }
                            servers.Last().GetZabbixServiceInfo(connection, false);
                            refreshServersDataGridView();

                            // Remove corresponding server from server list
                            SelectComputerListBox.Items.Remove(SelectComputerListBox.SelectedItems[i]);
                            i--;

                        }
                    }
                    EnableControls();

                }
                else
                {
                    MessageBox.Show("User, Password or Domain not entered");
                }
            }
            else
            {
                MessageBox.Show("Not connected to domain, please use the connect feature in the setup tab.");
            }

        }

        // This event handler manually raises the CellValueChanged event 
        // by calling the CommitEdit method. 
        void dataGridView1_CurrentCellDirtyStateChanged(object sender,
            EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // If a check box cell is clicked, this event handler disables   
        // or enables the button in the same row as the clicked cell. 
        public void dataGridView1_CellValueChanged(object sender,
            DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Enable Customisation")
            {   
                DataGridViewDisableButtonCell buttonCell =
                    (DataGridViewDisableButtonCell)dataGridView1.
                    Rows[e.RowIndex].Cells["Custom Config"];

                DataGridViewCheckBoxCell checkCell =
                    (DataGridViewCheckBoxCell)dataGridView1.
                    Rows[e.RowIndex].Cells["Enable Customisation"];
                buttonCell.Enabled = (Boolean)checkCell.Value;

                dataGridView1.Invalidate();
                
                string server = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                servers.First(s => s.ComputerName == server).CustomConfigSelected = (Boolean)checkCell.Value;
                
            }
        }

        // If the user clicks on an enabled button cell, this event handler   
        // launches the editor for the Zabbix Agent Configuration Customisation
        void dataGridView1_CellClick(object sender,
            DataGridViewCellEventArgs e)
        {
            // The first if condition test prevents exceptions caused when datagridview has no entries.
            if ((!(e.ColumnIndex < 0)) && (!(e.RowIndex < 0)))
            {
            if ((dataGridView1.Columns[e.ColumnIndex].Name == "Custom Config") && (dataGridView1.Rows.Count > 0)) 
                {
                    DataGridViewDisableButtonCell buttonCell =
                        (DataGridViewDisableButtonCell)dataGridView1.
                        Rows[e.RowIndex].Cells["Custom Config"];

                    if (buttonCell.Enabled)
                    {
                        //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + " is enabled");

                        if (GlobalVariables.defaultConfig != null)
                        {
                            string server = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                            servers.First(s => s.ComputerName == server).getCustomisation();

                            // If customisation has occurred set the name of the button accordingly

                            if ((servers.First(s => s.ComputerName == server).Customisation == "") ||
                                (servers.First(s => s.ComputerName == server).Customisation.Equals(GlobalVariables.defaultConfig)))
                            {
                                dataGridView1.Rows[e.RowIndex].Cells["Custom Config"].Value = "None";
                            }
                            else
                            {
                                dataGridView1.Rows[e.RowIndex].Cells["Custom Config"].Value = "Customised";
                            }
                        }
                        else
                        {
                            MessageBox.Show("No default config found, please ensure default config has been set to an existing file before using customisation. The default config can be set in setup tab");

                        }
                    }
                }
            }
        }

        private void loadConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog_LoadConfig.Filter = "Zabbix Installer Config Files (*.zbx)|*.zbx";
            OpenFileDialog_LoadConfig.RestoreDirectory = true;
            OpenFileDialog_LoadConfig.FileName = "";

            if (OpenFileDialog_LoadConfig.ShowDialog() == DialogResult.OK)
            {
                //DONE: create setup dialgoue box for change to a proper path for loading

                using (Stream input = File.OpenRead(OpenFileDialog_LoadConfig.FileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(input, CompressionMode.Decompress))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        servers = (List<Server>)formatter.Deserialize(decompressionStream);

                        // Reassign a new event handler to each server object for progress update display.
                        foreach (Server server in servers)
                        {
                            server.OnProgressUpdate += Servers_OnProgressUpdate;
                        }

                        // TODO: I'm sure you could loop through the static fields in GlobalVariables somehow using relection, but doing manually for now...
                        GlobalVariables.defaultConfigFileName = (string)formatter.Deserialize(decompressionStream);
                        GlobalVariables.defaultConfigPath = (string)formatter.Deserialize(decompressionStream);
                        GlobalVariables.defaultConfig = (string)formatter.Deserialize(decompressionStream);
                        GlobalVariables.defautl32BitAgentFileName = (string)formatter.Deserialize(decompressionStream);
                        GlobalVariables.defautl64BitAgentFileName = (string)formatter.Deserialize(decompressionStream);
                        GlobalVariables.default32BitAgentPath = (string)formatter.Deserialize(decompressionStream);
                        GlobalVariables.default64BitAgentPath = (string)formatter.Deserialize(decompressionStream);
                        GlobalVariables.defaultDeployPath = (string)formatter.Deserialize(decompressionStream);
                        UpdateForm();

                        // Load additional files
                        ListBox_AdditionalInstallFiles.Items.Clear();
                        int numberOfAdditionalFiles = (int)formatter.Deserialize(decompressionStream);
                        for (int i = 0; i < numberOfAdditionalFiles; i++)
                        {
                            ListBox_AdditionalInstallFiles.Items.Add((string)formatter.Deserialize(decompressionStream));
                        }

                        // Load checkbox status for zabbix_get.exe and zabbix_sender.exe
                        Checkbox_AlsoInstallZabbixGet32bit.Checked = (bool)formatter.Deserialize(decompressionStream);
                        Checkbox_AlsoInstallZabbixSender32bit.Checked = (bool)formatter.Deserialize(decompressionStream);
                        Checkbox_AlsoInstallZabbixGet64bit.Checked = (bool)formatter.Deserialize(decompressionStream);
                        Checkbox_AlsoInstallZabbixSender64bit.Checked = (bool)formatter.Deserialize(decompressionStream);

                        // Load the domain name that was used for the deployment
                        Textbox_Domain.Text = (string)formatter.Deserialize(decompressionStream);

                        this.Text = "MM's Zabbix Agent Installer - " + OpenFileDialog_LoadConfig.FileName;
                        Textbox_UserName.Clear();
                        Textbox_Password.Clear();
                    }
                }
            }

            try
            {

            }
            catch (IOException ex)
            {
                MessageBox.Show("Error reading file. \n\nOriginating error message: " + ex.Message);
            }
            dataGridView1.Rows.Clear();
            foreach (Server server in servers)
            {
                addServerToDataGridView(server);
                // If customisation has occurred set the name of the button accordingly
                if ((server.Customisation == "") ||
                    (server.Customisation.Equals(GlobalVariables.defaultConfig)))
                {
                    dataGridView1.Rows[servers.IndexOf(server)].Cells["Custom Config"].Value = "None";
                }
                else
                {
                    dataGridView1.Rows[servers.IndexOf(server)].Cells["Custom Config"].Value = "Customised";
                }

                //Load the checkbox selections and enable the corresponding customize buttons
                dataGridView1.Rows[servers.IndexOf(server)].Cells["Enable Customisation"].Value = server.CustomConfigSelected;
                
            }
            SelectComputerListBox.Items.Clear();
            dataGridView1.Invalidate();
            Checkbox_SelectAll.Checked = false;
            connected = false;
            Label_ConnectionStatus.Text = "Status: Not Connected";
            Panel_ConnectedState.BackColor = Color.IndianRed;
            Label_ConnectedState.Text = "Status: Disconnected";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        // TODO: Encrypt save file data
        /*
        using (Stream innerStream = File.Create(this.GetFullFileNameForUser(securityContext.User, applicationName)))
                {
                using (Stream cryptoStream = new CryptoStream(innerStream, GetCryptoProvider().CreateEncryptor(), CryptoStreamMode.Write))
                {
                    // 3. write to the cryptoStream 
                    //BinaryFormatter bf = new BinaryFormatter();
                    //bf.Serialize(cryptoStream, securityContext);
                    XmlSerializer xs = new XmlSerializer(typeof(SecurityContextDTO));
                    xs.Serialize(cryptoStream, securityContext);
                }
            }

         using (Stream innerStream = File.Open(this.GetFullFileNameForUser(user, applicationName), FileMode.Open))
        {
            using (Stream cryptoStream = new CryptoStream(innerStream, GetCryptoProvider().CreateDecryptor(), CryptoStreamMode.Read))
            {
                //BinaryFormatter bf = new BinaryFormatter();
                //return (SecurityContextDTO)bf.Deserialize(cryptoStream);
                XmlSerializer xs = new XmlSerializer(typeof(SecurityContextDTO));
                //CryptographicException here
                return (SecurityContextDTO)xs.Deserialize(cryptoStream);
            }
        }
        */
        {
           // Test to prevent saving if defaultConfig has null value, which will cause an exception.
            if (GlobalVariables.defaultConfig != null)
            {

                SaveFileDialog_SaveConfig.Filter = "Zabbix Installer Config Files (*.zbx)|*.zbx";        
                // IF a file is configuration alrady loaded - set the initial directory to its location
                if (OpenFileDialog_LoadConfig.FileName != "")
                    SaveFileDialog_SaveConfig.InitialDirectory = Path.GetDirectoryName(OpenFileDialog_LoadConfig.FileName);
                else
                    SaveFileDialog_SaveConfig.RestoreDirectory = true;
                SaveFileDialog_SaveConfig.FileName = "";

                if (SaveFileDialog_SaveConfig.ShowDialog() == DialogResult.OK)
                {

                    try
                    {
                        //DONE: create setup dialog box for change to a proper path for saving file
                        using (Stream output = File.Create(SaveFileDialog_SaveConfig.FileName))
                        {
                            using (GZipStream compressionStream = new GZipStream(output, CompressionMode.Compress))
                            {
                                BinaryFormatter formatter = new BinaryFormatter();
                                formatter.Serialize(compressionStream, servers);

                                // TODO: I'm sure you could loop through the static fields in GlobalVariables somehow using relection, but doing manually for now...
                                // Load all the values in the globalvariables section
                                formatter.Serialize(compressionStream, GlobalVariables.defaultConfigFileName);
                                formatter.Serialize(compressionStream, GlobalVariables.defaultConfigPath);
                                formatter.Serialize(compressionStream, GlobalVariables.defaultConfig);
                                formatter.Serialize(compressionStream, GlobalVariables.defautl32BitAgentFileName);
                                formatter.Serialize(compressionStream, GlobalVariables.defautl64BitAgentFileName);
                                formatter.Serialize(compressionStream, GlobalVariables.default32BitAgentPath);
                                formatter.Serialize(compressionStream, GlobalVariables.default64BitAgentPath);
                                formatter.Serialize(compressionStream, GlobalVariables.defaultDeployPath);
                                UpdateForm();

                                // Save additional files
                                int numberOfAdditionalFiles = ListBox_AdditionalInstallFiles.Items.Count;
                                formatter.Serialize(compressionStream, numberOfAdditionalFiles);
                                for (int i = 0; i < numberOfAdditionalFiles; i++)
                                {
                                    formatter.Serialize(compressionStream, ListBox_AdditionalInstallFiles.Items[i].ToString());
                                }

                                // Save checkbox status for zabbix_get.exe and zabbix_sender.exe
                                formatter.Serialize(compressionStream, Checkbox_AlsoInstallZabbixGet32bit.Checked);
                                formatter.Serialize(compressionStream, Checkbox_AlsoInstallZabbixSender32bit.Checked);
                                formatter.Serialize(compressionStream, Checkbox_AlsoInstallZabbixGet64bit.Checked);
                                formatter.Serialize(compressionStream, Checkbox_AlsoInstallZabbixSender64bit.Checked);

                                formatter.Serialize(compressionStream, Textbox_Domain.Text);

                                this.Text = "MM's Zabbix Agent Installer - " + SaveFileDialog_SaveConfig.FileName;
                            }
                        }
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Error saving file. \n\nOriginating error message: " + ex.Message);
                    }
                    catch (System.UnauthorizedAccessException ex)
                    {
                        MessageBox.Show("Error saving file! \r\n\r\nOriginating error message: " + ex.Message + "\r\n\r\n(Note: Did you remeber to right click and run program as administrator?)");
                    }



                }
            }
            else
            {
                MessageBox.Show("Default config has not been set to valid file. Please ensure default config has been correctly set.");
            }
            
        }

        private void addServerToDataGridView(Server server)
        {
            int nextRow = dataGridView1.Rows.Count;
            dataGridView1.Rows.Add();
            dataGridView1.Rows[nextRow].Cells["ComputerName"].Value = server.ComputerName;
            dataGridView1.Rows[nextRow].Cells["OSArch"].Value = server.OSArch;
            dataGridView1.Rows[nextRow].Cells["ZabbixAgentVersion"].Value = server.ZabbixAgentVersion;
            dataGridView1.Rows[nextRow].Cells["ZabbixServiceState"].Value = server.ZabbixServiceState;
            dataGridView1.Rows[nextRow].Cells["StatusOfLastAction"].Value = server.StatusOfLastAction;
        }

        public void refreshServersDataGridView()
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["ComputerName"].Value = servers[row.Index].ComputerName;
                row.Cells["OSArch"].Value = servers[row.Index].OSArch;
                row.Cells["ZabbixAgentVersion"].Value = servers[row.Index].ZabbixAgentVersion;
                row.Cells["ZabbixServiceState"].Value = servers[row.Index].ZabbixServiceState;
                row.Cells["StatusOfLastAction"].Value = servers[row.Index].StatusOfLastAction;
            }
        }

        private void Checkbox_SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (Checkbox_SelectAll.Checked)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells["Selected"].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells["Selected"].Value = false;
                }
            }
        }

        private void Button_UnInstallService_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                DisableControls();
                // TODO: Create server object 'selected' field and redesign the following for easier reading
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Selected"].Value))
                    {
                        row.DefaultCellStyle.BackColor = Color.MistyRose;
                        string server = row.Cells["ComputerName"].Value.ToString();
                        Log.WriteLog("Uninstalling Zabbix agent from server: " + server);
                        servers.First(s => s.ComputerName == server).UninstallZabbixService(connection);
                        servers.First(s => s.ComputerName == server).GetZabbixServiceInfo(connection, false);
                        refreshServersDataGridView();
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
                EnableControls();
            }
            else
            {
                MessageBox.Show("Not connected to domain, please use the connect feature in the setup tab.");
            }

        }
        
        private void Button_DeploySelected_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                if (GlobalVariables.defaultConfig != "")
                {
                    DisableControls();
                    // TODO: Create server object 'selected' field and redesign the following for easier reading
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Selected"].Value))
                        {
                            row.DefaultCellStyle.BackColor = Color.PaleGreen;
                            string server = row.Cells["ComputerName"].Value.ToString();
                            Log.WriteLog("Deploying Zabbix agent to server: " + server);
                            string UNCDeployPath = GlobalVariables.defaultDeployPath.Replace(@":", @"$");
                            string fileName = "";
                            string filePath = "";
                            bool overwrite = true;
                            //Create and authenticate a UNC connection to remote server, and copy all deployment files to the remote computer....
                            using (NetworkShareAccesser.Access(server, Textbox_Domain.Text, Textbox_UserName.Text, Textbox_Password.Text))
                            {
                                //If folder doesn't exist - create it!
                                string checkFolderExists = @"\\" + server + @"\" + UNCDeployPath;
                                checkFolderExists = checkFolderExists.Remove(checkFolderExists.Length - 1);
                                if (!(System.IO.Directory.Exists(checkFolderExists)))
                                {
                                    Write_Log("Folder not found, creating folder: " + checkFolderExists);
                                    try
                                    {
                                        System.IO.Directory.CreateDirectory(checkFolderExists);
                                    }
                                    catch (System.IO.IOException err)
                                    {
                                        Write_Log("ERROR: Couldn't create folder due to IO error: " + err.Message);
                                    }
                                    catch (System.UnauthorizedAccessException err)
                                    {
                                        Write_Log("ERROR: Access denied to folder: " + err.Message);
                                    }
                                }

                                //DONE: Implement something to detect when the remote process start/stop/install/uninstall the remote process,
                                //as using a timer to 'guess' when the service has stopped is a poor solution.
                                servers.First(s => s.ComputerName == server).UninstallZabbixService(connection);

                                //Commented out following IF - not sure why i put it there, or what purpose it serves, as
                                //the status will not always be 'Ok', i.e. when the folder and agent doesn't yet exist on remote server.
                                //if (servers.First(s => s.ComputerName == server).StatusOfLastAction == "Ok")
                                //{

                                // Based on the architecture of the OS and selected options, deploy corresponding 32-bit or 64-bit agent files.
                                switch (row.Cells["OSArch"].Value.ToString().ToUpper())
                                {
                                    case "32-BIT":
                                        Console.WriteLine("Deploying file for 32-bit architecture");
                                        Log.WriteLog("Copying 32-bit agent executable");
                                        // Check if agent file not found
                                        // TODO: Will this also fail if file version cannot be detected? This needs further testing.
                                        if ((Label_AgentVersion32bit.Text.Trim().ToUpper() != "FILE DOES NOT EXIST AT SPECIFIED PATH"))
                                        {
                                            // Check if the 32-bit agent file location has been specified under the setup tab before deploying files.
                                            if ((Label_Selected32bitZabbixAgent.Text.Trim().Length != 0) && (Label_Selected32bitZabbixAgent.Text.Trim().ToUpper() != "NONE"))
                                            {
                                                filePath = Label_Selected32bitZabbixAgent.Text.Substring(0, Label_Selected32bitZabbixAgent.Text.LastIndexOf(@"\") + 1).Trim();
                                                fileName = Label_Selected32bitZabbixAgent.Text.Substring(Label_Selected32bitZabbixAgent.Text.LastIndexOf(@"\") + 1).Trim();
                                                try
                                                {
                                                    File.Copy(filePath + fileName, @"\\" + server + @"\" + UNCDeployPath + fileName, overwrite);
                                                }
                                                catch (System.IO.FileNotFoundException err)
                                                {
                                                    Console.WriteLine(err);
                                                    Log.WriteLog("ERROR: 32-bit agent executable not found, please correct and deploy again. \r\nOriginating error message: " + err.Message);
                                                }
                                                catch (System.UnauthorizedAccessException err)
                                                {
                                                    Console.WriteLine(err);
                                                    Log.WriteLog("ERROR: Access Denied, please check the connection credentials. \r\nOriginating error message: " + err.Message);
                                                }
                                                catch (System.IO.IOException err)
                                                {
                                                    Console.WriteLine(err);
                                                    Log.WriteLog("ERROR: Network path inaccessible, cannot access UNC path. \r\nOriginating error message: " + err.Message);
                                                }
                                                if (Checkbox_AlsoInstallZabbixGet32bit.Checked)
                                                {
                                                    fileName = "zabbix_get.exe";
                                                    try
                                                    {
                                                        File.Copy(filePath + fileName, @"\\" + server + @"\" + UNCDeployPath + fileName, overwrite);
                                                    }
                                                    catch (System.IO.FileNotFoundException err)
                                                    {
                                                        Console.WriteLine(err);
                                                        Log.WriteLog("ERROR: 32-bit zabbix_get.exe was not found in same folder as specified for Zabbix agent, please correct and deploy again. \r\nOriginating error message: " + err.Message);
                                                    }
                                                    catch (System.UnauthorizedAccessException err)
                                                    {
                                                        Console.WriteLine(err);
                                                        Log.WriteLog("ERROR: Access Denied, please check the connection credentials. \r\nOriginating error message: " + err.Message);
                                                    }
                                                    catch (System.IO.IOException err)
                                                    {
                                                        Console.WriteLine(err);
                                                        Log.WriteLog("ERROR: Network path inaccessible, cannot access UNC path. \r\nOriginating error message: " + err.Message);
                                                    }
                                                }
                                                if (Checkbox_AlsoInstallZabbixSender32bit.Checked)
                                                {
                                                    fileName = "zabbix_sender.exe";
                                                    try
                                                    {
                                                        File.Copy(filePath + fileName, @"\\" + server + @"\" + UNCDeployPath + fileName, overwrite);
                                                    }
                                                    catch (System.IO.FileNotFoundException err)
                                                    {
                                                        Console.WriteLine(err);
                                                        Log.WriteLog("ERROR: 32-bit zabbix_sender.exe was not found in same folder as specified for Zabbix agent, please correct and deploy again. \r\nOriginating error message: " + err.Message);
                                                    }
                                                    catch (System.UnauthorizedAccessException err)
                                                    {
                                                        Console.WriteLine(err);
                                                        Log.WriteLog("ERROR: Access Denied, please check the connection credentials. \r\nOriginating error message: " + err.Message);
                                                    }
                                                    catch (System.IO.IOException err)
                                                    {
                                                        Console.WriteLine(err);
                                                        Log.WriteLog("ERROR: Network path inaccessible, cannot access UNC path. \r\nOriginating error message: " + err.Message);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Log.WriteLog("ERROR: Server " + server + " has 32-bit OS architecture. A file path for the 32-bit Zabbix agent was not specified, agent files will not be deployed to this server. \r\n"
                                                    + "Please specify 32-bit agent file location under the SETUP tab and try again.");
                                            }
                                        }
                                        else
                                        {
                                            Log.WriteLog("ERROR: 32-bit agent not found at specified path, please select valid agent file path under setup tab");
                                        }
                                        break;
                                    case "64-BIT":
                                        Console.WriteLine("Deploying file for 64-bit architecture");
                                        Log.WriteLog("Copying 64-bit agent executable");
                                        // Check if agent file not found
                                        // TODO: Will this also fail if file version cannot be detected? This needs further testing.
                                        if ((Label_AgentVersion64bit.Text.Trim().ToUpper() != "FILE DOES NOT EXIST AT SPECIFIED PATH"))
                                        {
                                            // Check if the 64-bit agent file location has been specified under the setup tab before deploying files.
                                            if ((Label_Selected64bitZabbixAgent.Text.Trim().Length != 0) && (Label_Selected64bitZabbixAgent.Text.Trim().ToUpper() != "NONE"))
                                            {
                                                filePath = Label_Selected64bitZabbixAgent.Text.Substring(0, Label_Selected64bitZabbixAgent.Text.LastIndexOf(@"\") + 1).Trim();
                                                fileName = Label_Selected64bitZabbixAgent.Text.Substring(Label_Selected64bitZabbixAgent.Text.LastIndexOf(@"\") + 1).Trim();
                                                try
                                                {
                                                    File.Copy(filePath + fileName, @"\\" + server + @"\" + UNCDeployPath + fileName, overwrite);
                                                }
                                                catch (System.IO.DirectoryNotFoundException err)
                                                {
                                                    Console.WriteLine(err);
                                                    Log.WriteLog("ERROR: 64-bit agent executable not found, please correct and deploy again. \r\nOriginating error message: " + err.Message);

                                                }
                                                catch (System.UnauthorizedAccessException err)
                                                {
                                                    Console.WriteLine(err);
                                                    Log.WriteLog("ERROR: Access Denied, please check the connection credentials. \r\nOriginating error message: " + err.Message);
                                                }
                                                catch (System.IO.IOException err)
                                                {
                                                    Console.WriteLine(err);
                                                    Log.WriteLog("ERROR: Network path inaccessible, cannot access UNC path. \r\nOriginating error message: " + err.Message);
                                                }
                                                //catch (System.IO.IOException err)
                                                //{
                                                //    Console.WriteLine(err);
                                                // }

                                                if (Checkbox_AlsoInstallZabbixGet64bit.Checked)
                                                {
                                                    fileName = "zabbix_get.exe";
                                                    try
                                                    {
                                                        File.Copy(filePath + fileName, @"\\" + server + @"\" + UNCDeployPath + fileName, overwrite);
                                                    }
                                                    catch (System.IO.FileNotFoundException err)
                                                    {
                                                        Console.WriteLine(err);
                                                        Log.WriteLog("ERROR: 64-bit zabbix_get.exe was not found in same folder as specified for Zabbix agent, please correct and deploy again. \r\nOriginating error message: " + err.Message);
                                                    }
                                                    catch (System.UnauthorizedAccessException err)
                                                    {
                                                        Console.WriteLine(err);
                                                        Log.WriteLog("ERROR: Access Denied, please check the connection credentials. \r\nOriginating error message: " + err.Message);
                                                    }
                                                    catch (System.IO.IOException err)
                                                    {
                                                        Console.WriteLine(err);
                                                        Log.WriteLog("ERROR: Network path inaccessible, cannot access UNC path. \r\nOriginating error message: " + err.Message);
                                                    }
                                                }
                                                if (Checkbox_AlsoInstallZabbixSender64bit.Checked)
                                                {
                                                    fileName = "zabbix_sender.exe";
                                                    try
                                                    {
                                                        File.Copy(filePath + fileName, @"\\" + server + @"\" + UNCDeployPath + fileName, overwrite);
                                                    }
                                                    catch (System.IO.FileNotFoundException err)
                                                    {
                                                        Console.WriteLine(err);
                                                        Log.WriteLog("ERROR: 64-bit zabbix_sender.exe was not found in same folder as specified for Zabbix agent, please correct and deploy again. \r\nOriginating error message: " + err.Message);
                                                    }
                                                    catch (System.UnauthorizedAccessException err)
                                                    {
                                                        Console.WriteLine(err);
                                                        Log.WriteLog("ERROR: Access Denied, please check the connection credentials. \r\nOriginating error message: " + err.Message);
                                                    }
                                                    catch (System.IO.IOException err)
                                                    {
                                                        Console.WriteLine(err);
                                                        Log.WriteLog("ERROR: Network path inaccessible, cannot access UNC path. \r\nOriginating error message: " + err.Message);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Log.WriteLog("ERROR: Server " + server + " has 64-bit OS architecture. A file path for the 64-bit Zabbix agent was not specified, agent files will not be deployed to this server. \r\n"
                                                        + "Please specify 64-bit agent file location under the SETUP tab and try again.");
                                            }
                                        }
                                        else
                                        {
                                            Log.WriteLog("ERROR: 64-bit agent not found at specified path, please select valid agent file path under setup tab");
                                        }
                                        break;
                                    default:
                                        Log.WriteLog("WARNING: Defaulted to copying 32-bit agent executable, OS architecture not dectected");
                                        Console.WriteLine("OS Architecture not detected, defaulting to deploy files for 32-bit architecture");
                                        // DONE: Add to log file
                                        Log.WriteLog("WARNING: OS Architecture not detected on server: " + server + ", defaulting to deploy files for 32-bit architecture");
                                        // Check if agent file not found
                                        // TODO: Will this also fail if file version cannot be detected? This needs further testing.
                                        if ((Label_AgentVersion32bit.Text.Trim().ToUpper() != "FILE DOES NOT EXIST AT SPECIFIED PATH"))
                                        {
                                            // Check if the 32-bit agent file location has been specified under the setup tab before deploying files.
                                            if ((Label_Selected32bitZabbixAgent.Text.Trim().Length != 0) && (Label_Selected32bitZabbixAgent.Text.Trim().ToUpper() != "NONE"))
                                            {
                                                filePath = Label_Selected32bitZabbixAgent.Text.Substring(0, Label_Selected32bitZabbixAgent.Text.LastIndexOf(@"\") + 1).Trim();
                                                fileName = Label_Selected32bitZabbixAgent.Text.Substring(Label_Selected32bitZabbixAgent.Text.LastIndexOf(@"\") + 1).Trim();
                                                try
                                                {
                                                    File.Copy(filePath + fileName, @"\\" + server + @"\" + UNCDeployPath + fileName, overwrite);
                                                }
                                                catch (System.IO.FileNotFoundException err)
                                                {
                                                    Console.WriteLine(err);
                                                    Log.WriteLog("ERROR: 32-bit agent executable not found, please correct and deploy again. \r\nOriginating error message: " + err.Message);
                                                }
                                                catch (System.UnauthorizedAccessException err)
                                                {
                                                    Console.WriteLine(err);
                                                    Log.WriteLog("ERROR: Access Denied, please check the connection credentials. \r\nOriginating error message: " + err.Message);
                                                }
                                                catch (System.IO.IOException err)
                                                {
                                                    Console.WriteLine(err);
                                                    Log.WriteLog("ERROR: Network path inaccessible, cannot access UNC path. \r\nOriginating error message: " + err.Message);
                                                }
                                                if (Checkbox_AlsoInstallZabbixGet32bit.Checked)
                                                {
                                                    fileName = "zabbix_get.exe";
                                                    try
                                                    {
                                                        File.Copy(filePath + fileName, @"\\" + server + @"\" + UNCDeployPath + fileName, overwrite);
                                                    }
                                                    catch (System.IO.FileNotFoundException err)
                                                    {
                                                        Console.WriteLine(err);
                                                        Log.WriteLog("ERROR: 32-bit zabbix_get.exe was not found in same folder as specified for Zabbix agent. \r\nOriginating error message: " + err.Message);
                                                    }
                                                    catch (System.UnauthorizedAccessException err)
                                                    {
                                                        Console.WriteLine(err);
                                                        Log.WriteLog("ERROR: Access Denied, please check the connection credentials. \r\nOriginating error message: " + err.Message);
                                                    }
                                                    catch (System.IO.IOException err)
                                                    {
                                                        Console.WriteLine(err);
                                                        Log.WriteLog("ERROR: Network path inaccessible, cannot access UNC path. \r\nOriginating error message: " + err.Message);
                                                    }
                                                }
                                                if (Checkbox_AlsoInstallZabbixSender32bit.Checked)
                                                {
                                                    fileName = "zabbix_sender.exe";
                                                    try
                                                    {
                                                        File.Copy(filePath + fileName, @"\\" + server + @"\" + UNCDeployPath + fileName, overwrite);
                                                    }
                                                    catch (System.IO.FileNotFoundException err)
                                                    {
                                                        Console.WriteLine(err);
                                                        Log.WriteLog("ERROR: 2-bit zabbix_sender.exe was not found in same folder as specified for Zabbix agent. \r\nOriginating error message: " + err.Message);
                                                    }
                                                    catch (System.UnauthorizedAccessException err)
                                                    {
                                                        Console.WriteLine(err);
                                                        Log.WriteLog("ERROR: Access Denied, please check the connection credentials. \r\nOriginating error message: " + err.Message);
                                                    }
                                                    catch (System.IO.IOException err)
                                                    {
                                                        Console.WriteLine(err);
                                                        Log.WriteLog("ERROR: Network path inaccessible, cannot access UNC path. \r\nOriginating error message: " + err.Message);
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                Log.WriteLog("WARNING: Could not detect OS architecture for " + server + ", defaulting to 32-bit.\r\nERROR: A file path for the 32-bit Zabbix agent was not specified, agent files will not be deployed to this server.\r\n"
                                                    + "Please specify 32-bit agent file location under the SETUP tab and try again.");
                                            }
                                        }
                                        else
                                        {
                                            Log.WriteLog("ERROR: 32-bit agent not found at specified path, please select valid agent file path under setup tab");
                                        }
                                        break;
                                }

                                // Write the custom config to the server if selected, or otherwise write the default
                                if (servers.First(s => s.ComputerName == server).CustomConfigSelected)
                                {
                                    Log.WriteLog("Custom configuration detected, copying config");
                                    try
                                    {
                                        File.WriteAllText(@"\\" + server + @"\" + UNCDeployPath + GlobalVariables.defaultConfigFileName, servers.First(s => s.ComputerName == server).Customisation);
                                    }
                                    catch (System.IO.FileNotFoundException err)
                                    {
                                        Console.WriteLine(err);
                                        Log.WriteLog("ERROR: File copy error. \r\nOriginating error message: " + err.Message);
                                    }
                                    catch (System.UnauthorizedAccessException err)
                                    {
                                        Console.WriteLine(err);
                                        Log.WriteLog("ERROR: Access Denied, please check the connection credentials. \r\nOriginating error message: " + err.Message);
                                    }
                                    catch (System.IO.IOException err)
                                    {
                                        Console.WriteLine(err);
                                        Log.WriteLog("ERROR: Network path inaccessible, cannot access UNC path. \r\nOriginating error message: " + err.Message);
                                    }
                                }
                                else
                                {
                                    Log.WriteLog("Copying default config");
                                    try
                                    {
                                        File.WriteAllText(@"\\" + server + @"\" + UNCDeployPath + GlobalVariables.defaultConfigFileName, GlobalVariables.defaultConfig);
                                    }
                                    catch (System.IO.FileNotFoundException err)
                                    {
                                        Console.WriteLine(err);
                                        Log.WriteLog("ERROR: File copy error. \r\nOriginating error message: " + err.Message);
                                    }
                                    catch (System.UnauthorizedAccessException err)
                                    {
                                        Console.WriteLine(err);
                                        Log.WriteLog("ERROR: Access Denied, please check the connection credentials. \r\nOriginating error message: " + err.Message);
                                    }
                                    catch (System.IO.IOException err)
                                    {
                                        Console.WriteLine(err);
                                        Log.WriteLog("ERROR: Network path inaccessible, cannot access UNC path. \r\nOriginating error message: " + err.Message);
                                    }

                                }


                                try
                                {
                                    if (ListBox_AdditionalInstallFiles.Items.Count > 0)
                                        Log.WriteLog("Copying additional files");
                                    // Copy any additional file(s) as selected by user in setup
                                    foreach (string file in ListBox_AdditionalInstallFiles.Items)
                                    {
                                        //grab the filename from the end of the full file path
                                        fileName = file.Substring(file.LastIndexOf(@"\") + 1).Trim();
                                        //copy file
                                        try
                                        {
                                            File.Copy(file, @"\\" + server + @"\" + UNCDeployPath + fileName, overwrite);
                                        }
                                        catch (System.IO.FileNotFoundException err)
                                        {
                                            Console.WriteLine(err);
                                            Log.WriteLog("ERROR: File copy error. \r\nOriginating error message: " + err.Message);
                                        }
                                        catch (System.UnauthorizedAccessException err)
                                        {
                                            Console.WriteLine(err);
                                            Log.WriteLog("ERROR: Access Denied, please check the connection credentials. \r\nOriginating error message: " + err.Message);
                                        }
                                        catch (System.IO.IOException err)
                                        {
                                            Console.WriteLine(err);
                                            Log.WriteLog("ERROR: Network path inaccessible, cannot access UNC path. \r\nOriginating error message: " + err.Message);
                                        }
                                    }
                                }
                                catch (System.IO.IOException err)
                                {

                                    Log.WriteLog("ERROR: IO Error - " + err.Message);
                                }
                                catch (System.UnauthorizedAccessException err)
                                {
                                    Console.WriteLine(err);
                                    Log.WriteLog("ERROR: Access Denied, please check the connection credentials. \r\nOriginating error message: " + err.Message);
                                }
                                
                            }


                            //Start the Zabbix service on remote computer
                            if (row.Cells["OSArch"].Value.ToString().ToUpper() == "32-BIT")
                                servers.First(s => s.ComputerName == server).DeployZabbixService(connection, GlobalVariables.defautl32BitAgentFileName);
                            else
                                servers.First(s => s.ComputerName == server).DeployZabbixService(connection, GlobalVariables.defautl64BitAgentFileName);

                            servers.First(s => s.ComputerName == server).GetZabbixServiceInfo(connection, false);
                            refreshServersDataGridView();
                        }

                        row.DefaultCellStyle.BackColor = Color.White;
                    }

                    EnableControls();
                }
                else
                {
                    MessageBox.Show("Default config appears to be empty, please check default config file has been set correctly in the setup tab.");

                }
            }
            else
            {
                MessageBox.Show("Not connected to domain, please use connect feature found within the setup tab.");
            }
        }

        private void Button_Refresh_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                DisableControls();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Selected"].Value))
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCyan;
                        string server = row.Cells["ComputerName"].Value.ToString();
                        servers.First(s => s.ComputerName == server).GetZabbixServiceInfo(connection, true);
                        refreshServersDataGridView();
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
                EnableControls();
            }
            else
            {
                MessageBox.Show("Not connected to domain, please use connect feature found within the setup tab.");
            }
        }

        private void Button_Remove_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells["Selected"].Value))
                {
                    //Remove server object from server list
                    string server = dataGridView1.Rows[i].Cells["ComputerName"].Value.ToString();
                    servers.Remove(servers.First(s => s.ComputerName == server));
                    //Remove server from dataGridView
                    dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                    i--;
                    SelectComputerListBox.Items.Add(server);
                }
            }
         }



        private void Button_ManualAdd_Click(object sender, EventArgs e)
        {
            serverExists = false;
            // Confirm server name contains no white space
            if (Textbox_ManualAdd.Text.Trim() != "")
            {
                // Confirm 'if' server is not already in the listbox
                // Had  to copy ListBox.Items to a string list in order to access the overloaded .Contains method.
                List<string> listBoxItems = new List<string>(SelectComputerListBox.Items.Cast<string>().ToList());
                if (!(listBoxItems.Contains(Textbox_ManualAdd.Text.Trim(),StringComparer.CurrentCultureIgnoreCase)))
                {
                    // Confirm server in manual add textbox is not already in dataGridView
                    foreach (Server server in servers)
                    {
                        if (Textbox_ManualAdd.Text.Trim().ToUpper() == server.ComputerName.ToUpper())
                        {
                            serverExists = true;
                        }
                    }
                    // If the server doesn't exist anywhere yet, add it to the listbox
                    if (!(serverExists))
                    {
                        SelectComputerListBox.Items.Add(Textbox_ManualAdd.Text.Trim());
                    }
                    else
                        MessageBox.Show("Sever " + Textbox_ManualAdd.Text.Trim() + " already exists in deployment table");
                }
                else
                    MessageBox.Show("Sever " + Textbox_ManualAdd.Text.Trim() + " already exists in selection list");
            }
        }


        private void Button_Connect_Click(object sender, EventArgs e)
        {
            bool valid = false;
            Label_ConnectionStatus.Text = "Status: Connecting...";
            Panel_ConnectedState.BackColor = Color.PaleGoldenrod;
            Label_ConnectedState.Text = "Status: Conneting...";
            Application.DoEvents();
            try
            {
                using (PrincipalContext context = new PrincipalContext(ContextType.Domain, Textbox_Domain.Text))
                {
                    // Validate credentials before proceeding
                    valid = context.ValidateCredentials(Textbox_UserName.Text, Textbox_Password.Text);
                    if (valid)
                    {
                        Label_ConnectionStatus.Text = "Status: Connected to " + Textbox_Domain.Text;
                        //Show detected LDAP root connection path:
                        try
                        {
                            // TODO: Convert password to securepassword
                            // Detect root domain naming context
                            DirectoryEntry RootDSE = new DirectoryEntry(@"LDAP://" + Textbox_Domain.Text + @"/RootDSE");
                            RootDSE.Username = Textbox_UserName.Text;
                            RootDSE.Password = Textbox_Password.Text;
                            Label_Detect.Text = @"LDAP://" + RootDSE.Properties["defaultNamingContext"].Value.ToString();
                            LDAPBaseSearchPathBox.Text = Label_Detect.Text;

                            connection = new RemoteConnect(Textbox_Domain.Text, Textbox_UserName.Text, Textbox_Password.Text);
                            connected = true;

                        }
                        catch (System.Runtime.InteropServices.COMException)
                        {
                            Label_Detect.Text = "Domain Not Detected";
                            LDAPBaseSearchPathBox.Text = Label_Detect.Text;
                            connected = false;
                        }

                    }
                    else
                    {
                        Label_ConnectionStatus.Text = "Status: Incorrect username and/or password";
                        connected = false;
                    }
                }
            }
            catch (System.DirectoryServices.AccountManagement.PrincipalServerDownException err)
            {

                Console.WriteLine("Error: {0}", err);
                Label_ConnectionStatus.Text = "Status: The domain could not be contacted, please check your domain name. (Try using the FQDN, example: contoso.com)";

                //An unhandled exception of type 'System.DirectoryServices.AccountManagement.PrincipalServerDownException' occurred in System.DirectoryServices.AccountManagement.dll  
                //Additional information: The server could not be contacted.
                connected = false;
            }
            catch (System.DirectoryServices.Protocols.LdapException err)
            {
                Console.WriteLine("Error: {0}", err);
                Label_ConnectionStatus.Text = "The connection cannot be established. Note: This can happen if this executable is running from a network drive or blocked by antivirus/firewall.";
                connected = false;
            }

            if (connected)
            {
                Panel_ConnectedState.BackColor = Color.LightGreen;
                Label_ConnectedState.Text = "  Status: Connected";
                //Button_Refresh_Click(sender, e); Do i really wan't to wait for a refresh after connecting? The refresh button is always there.

            }
            else
            {
                Panel_ConnectedState.BackColor = Color.IndianRed;
                Label_ConnectedState.Text = "Status: Disconnected";
            }
                
        }

        private void Button_AddAdditionalFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog_AddAdditionalFile.Filter = "All Files (*.*)|*.*|Executable Files (*.exe)|*.exe|Zabbix Config Files (*.conf)|*.conf";
            OpenFileDialog_AddAdditionalFile.RestoreDirectory = true;
            OpenFileDialog_AddAdditionalFile.FileName = "";
            OpenFileDialog_AddAdditionalFile.Title = "Select Additional Files";

            if (OpenFileDialog_AddAdditionalFile.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in OpenFileDialog_AddAdditionalFile.FileNames)
                {
                    fileExists = false;
                    foreach (string existingFileName in ListBox_AdditionalInstallFiles.Items)
                    {
                        if (fileName == existingFileName)
                            fileExists = true;
                    }

                    if (fileExists)
                    {
                        MessageBox.Show("The following file is already selected for install: \n \n" + fileName);
                    }
                    else
                    {
                        ListBox_AdditionalInstallFiles.Items.Add(fileName);
                    }
                }
            }


        }

        private void Button_RemoveAdditionalFile_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ListBox_AdditionalInstallFiles.SelectedItems.Count; i++)
            {
                ListBox_AdditionalInstallFiles.Items.Remove(ListBox_AdditionalInstallFiles.SelectedItems[i]);
                i--;
            }
        }

        private void Selected32bitZabbixAgent_Click(object sender, EventArgs e)
        {

            OpenFileDialog_ZabbixAgent32bit.Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*";
            OpenFileDialog_ZabbixAgent32bit.InitialDirectory = Path.GetDirectoryName(Label_Selected32bitZabbixAgent.Text);
            OpenFileDialog_ZabbixAgent32bit.FileName = "";
            OpenFileDialog_ZabbixAgent32bit.Title = "Select 32-bit Zabbix Agent";

            if (OpenFileDialog_ZabbixAgent32bit.ShowDialog() == DialogResult.OK)
            {
                GlobalVariables.default32BitAgentPath = Path.GetDirectoryName(OpenFileDialog_ZabbixAgent32bit.FileName) + @"\";
                GlobalVariables.defautl32BitAgentFileName = Path.GetFileName(OpenFileDialog_ZabbixAgent32bit.FileName);
                Console.WriteLine("Set: " + GlobalVariables.default32BitAgentPath + GlobalVariables.defautl32BitAgentFileName);
                UpdateForm();
            }
        }

        private void Button_Selected64bitZabbixAgent_Click(object sender, EventArgs e)
        {


            OpenFileDialog_ZabbixAgent64bit.Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*";
            OpenFileDialog_ZabbixAgent64bit.InitialDirectory = Path.GetDirectoryName(Label_Selected64bitZabbixAgent.Text) + @"\";
            OpenFileDialog_ZabbixAgent64bit.FileName = "";
            OpenFileDialog_ZabbixAgent64bit.Title = "Select 64-bit Zabbix Agent";

            if (OpenFileDialog_ZabbixAgent64bit.ShowDialog() == DialogResult.OK)
            {
                GlobalVariables.default64BitAgentPath = Path.GetDirectoryName(OpenFileDialog_ZabbixAgent64bit.FileName) + @"\";
                GlobalVariables.defautl64BitAgentFileName = Path.GetFileName(OpenFileDialog_ZabbixAgent64bit.FileName);
                Console.WriteLine("Set: " + GlobalVariables.default64BitAgentPath + GlobalVariables.defautl64BitAgentFileName);
                UpdateForm();
            }

        }

        private void DisableControls()
        {
            panel1.Enabled = false;
            panel2.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            loadToolStripMenuItem.Enabled = false;
            
        }

        private void EnableControls()
        {
            panel1.Enabled = true;
            panel2.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            loadToolStripMenuItem.Enabled = true;

        }

        private void Servers_OnProgressUpdate(bool finished)
        {
            if (finished)
                progressBar1.Visible = false;
            else
                progressBar1.Visible = true;
   
            base.BeginInvoke((Action)delegate
            {
                refreshServersDataGridView();
            });

        }

        private void Write_Log(string logMessage)
        {

            base.BeginInvoke((Action)delegate
            {
                Textbox_Log.AppendText("* " + DateTime.Now + " " + logMessage + "\r\n");
            });

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {

            exiting = true;

            base.OnFormClosing(e);

            // DONE: Environment.Exit(0) is a bad way to close the program, but currently an exception will be thrown 
            // when quitting if the server object backgroundworker threads are running. Haven't been able to figure 
            // out how to cancel the backgroundworker threads when the form is closing? Need a proper solution!!


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string server = row.Cells["ComputerName"].Value.ToString();
                servers.First(s => s.ComputerName == server).CancelThreads();
            }

        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (Form4 form4 = new Form4())
            {
                form4.ShowDialog();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string writtenBy = "Written by Murray McPherson 2014";
            string versionInfo = "Version: " + version;
            MessageBox.Show("MM's Zabbix Agent Installer".PadLeft((writtenBy.Length)+1,' ') + "\r\n\r\n" + writtenBy + "\r\n\r\n" + versionInfo.PadLeft((writtenBy.Length)+1,' '));
        }

        private void NumericUpDown_WMITimeout_ValueChanged(object sender, EventArgs e)
        {
            GlobalVariables.WMItimeOut = NumericUpDown_WMITimeout.Value;
        }

        private void Textbox_UserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button_Connect_Click(null, null);
            }
        }

        private void Textbox_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button_Connect_Click(null, null);
            }
        }

        private void Textbox_Domain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button_Connect_Click(null, null);
            }
        }

    }
}
