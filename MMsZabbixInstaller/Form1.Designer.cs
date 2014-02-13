namespace MMsZabbixInstaller
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Panel_ConnectedState = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Label_ConnectedState = new System.Windows.Forms.Label();
            this.OpenFileDialog_AddAdditionalFile = new System.Windows.Forms.OpenFileDialog();
            this.deployTabPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ComputerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OSArch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZabbixServiceState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZabbixAgentVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusOfLastAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Textbox_Log = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Button_Refresh = new System.Windows.Forms.Button();
            this.Button_UnInstallService = new System.Windows.Forms.Button();
            this.Button_DeploySelected = new System.Windows.Forms.Button();
            this.Checkbox_SelectAll = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Textbox_ManualAdd = new System.Windows.Forms.TextBox();
            this.Button_ManualAdd = new System.Windows.Forms.Button();
            this.Checkbox_ScanServersOnly = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Label_Detect = new System.Windows.Forms.TextBox();
            this.Button_Add = new System.Windows.Forms.Button();
            this.Button_Remove = new System.Windows.Forms.Button();
            this.LDAPBaseSearchPathLabel = new System.Windows.Forms.Label();
            this.SelectComputerListBox = new System.Windows.Forms.ListBox();
            this.LDAPBaseSearchPathBox = new System.Windows.Forms.TextBox();
            this.Button_ScanLDAPComputers = new System.Windows.Forms.Button();
            this.setupTapePage = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ListBox_AdditionalInstallFiles = new System.Windows.Forms.ListBox();
            this.Button_RemoveAdditionalFile = new System.Windows.Forms.Button();
            this.Button_AddAdditionalFile = new System.Windows.Forms.Button();
            this.Label_AlsoInstall64bit = new System.Windows.Forms.Label();
            this.Label_AlsoInstall32bit = new System.Windows.Forms.Label();
            this.Checkbox_AlsoInstallZabbixSender64bit = new System.Windows.Forms.CheckBox();
            this.Checkbox_AlsoInstallZabbixGet64bit = new System.Windows.Forms.CheckBox();
            this.Checkbox_AlsoInstallZabbixSender32bit = new System.Windows.Forms.CheckBox();
            this.Checkbox_AlsoInstallZabbixGet32bit = new System.Windows.Forms.CheckBox();
            this.Label_AgentVersion64bit = new System.Windows.Forms.TextBox();
            this.Label_AgentVersion32bit = new System.Windows.Forms.TextBox();
            this.Label_AgentVersion64bitStatic = new System.Windows.Forms.Label();
            this.Label_AgentVersion32bitStatic = new System.Windows.Forms.Label();
            this.Button_Selected32bitZabbixAgent = new System.Windows.Forms.Button();
            this.Label_Selected32bitZabbixAgent = new System.Windows.Forms.TextBox();
            this.Button_Selected64bitZabbixAgent = new System.Windows.Forms.Button();
            this.Button_ShowConfig = new System.Windows.Forms.Button();
            this.Label_Selected64bitZabbixAgent = new System.Windows.Forms.TextBox();
            this.Label_ShowDefaultConfig = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Label_Seconds = new System.Windows.Forms.Label();
            this.NumericUpDown_WMITimeout = new System.Windows.Forms.NumericUpDown();
            this.Label_WMITimeout = new System.Windows.Forms.Label();
            this.Textbox_Domain = new System.Windows.Forms.TextBox();
            this.Textbox_UserName = new System.Windows.Forms.TextBox();
            this.Textbox_Password = new System.Windows.Forms.TextBox();
            this.domainLabel = new System.Windows.Forms.Label();
            this.Label_ConnectionStatus = new System.Windows.Forms.Label();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.Button_Connect = new System.Windows.Forms.Button();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Data2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tick2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Data1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tick1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OpenFileDialog_LoadConfig = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog_SaveConfig = new System.Windows.Forms.SaveFileDialog();
            this.OpenFileDialog_ZabbixAgent32bit = new System.Windows.Forms.OpenFileDialog();
            this.OpenFileDialog_ZabbixAgent64bit = new System.Windows.Forms.OpenFileDialog();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.menuStrip1.SuspendLayout();
            this.Panel_ConnectedState.SuspendLayout();
            this.deployTabPage.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.setupTapePage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_WMITimeout)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(89, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.loadToolStripMenuItem.Text = "Load Deployment";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadConfigToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.saveToolStripMenuItem.Text = "Save Deployment";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.helpToolStripMenuItem1.Text = "View Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Panel_ConnectedState
            // 
            this.Panel_ConnectedState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_ConnectedState.BackColor = System.Drawing.Color.IndianRed;
            this.Panel_ConnectedState.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel_ConnectedState.Controls.Add(this.progressBar1);
            this.Panel_ConnectedState.Controls.Add(this.Label_ConnectedState);
            this.Panel_ConnectedState.Location = new System.Drawing.Point(859, 13);
            this.Panel_ConnectedState.Name = "Panel_ConnectedState";
            this.Panel_ConnectedState.Size = new System.Drawing.Size(158, 22);
            this.Panel_ConnectedState.TabIndex = 47;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.BackColor = System.Drawing.Color.IndianRed;
            this.progressBar1.ForeColor = System.Drawing.Color.White;
            this.progressBar1.Location = new System.Drawing.Point(-1, -2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(158, 22);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 61;
            this.progressBar1.Visible = false;
            // 
            // Label_ConnectedState
            // 
            this.Label_ConnectedState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_ConnectedState.AutoSize = true;
            this.Label_ConnectedState.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_ConnectedState.ForeColor = System.Drawing.Color.Black;
            this.Label_ConnectedState.Location = new System.Drawing.Point(13, 1);
            this.Label_ConnectedState.Name = "Label_ConnectedState";
            this.Label_ConnectedState.Size = new System.Drawing.Size(128, 15);
            this.Label_ConnectedState.TabIndex = 0;
            this.Label_ConnectedState.Text = "Status: Disconnected";
            // 
            // OpenFileDialog_AddAdditionalFile
            // 
            this.OpenFileDialog_AddAdditionalFile.FileName = "abcdefghijklmnopqrstuv.txt";
            this.OpenFileDialog_AddAdditionalFile.Multiselect = true;
            // 
            // deployTabPage
            // 
            this.deployTabPage.Controls.Add(this.splitContainer1);
            this.deployTabPage.Controls.Add(this.panel2);
            this.deployTabPage.Controls.Add(this.panel1);
            this.deployTabPage.Location = new System.Drawing.Point(4, 22);
            this.deployTabPage.Name = "deployTabPage";
            this.deployTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.deployTabPage.Size = new System.Drawing.Size(1022, 479);
            this.deployTabPage.TabIndex = 2;
            this.deployTabPage.Text = "Deploy";
            this.deployTabPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.splitContainer1.Location = new System.Drawing.Point(0, 36);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Textbox_Log);
            this.splitContainer1.Size = new System.Drawing.Size(704, 443);
            this.splitContainer1.SplitterDistance = 354;
            this.splitContainer1.TabIndex = 47;
            this.splitContainer1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.ComputerName,
            this.OSArch,
            this.ZabbixServiceState,
            this.ZabbixAgentVersion,
            this.StatusOfLastAction});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(5, 3);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(694, 346);
            this.dataGridView1.TabIndex = 49;
            // 
            // Selected
            // 
            this.Selected.HeaderText = "Selected";
            this.Selected.Name = "Selected";
            this.Selected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Selected.Width = 80;
            // 
            // ComputerName
            // 
            this.ComputerName.HeaderText = "Computer Name";
            this.ComputerName.Name = "ComputerName";
            this.ComputerName.Width = 120;
            // 
            // OSArch
            // 
            this.OSArch.HeaderText = "OS (x86/x64)";
            this.OSArch.Name = "OSArch";
            // 
            // ZabbixServiceState
            // 
            this.ZabbixServiceState.HeaderText = "Zabbix Service State";
            this.ZabbixServiceState.Name = "ZabbixServiceState";
            this.ZabbixServiceState.Width = 140;
            // 
            // ZabbixAgentVersion
            // 
            this.ZabbixAgentVersion.HeaderText = "Zabbix Agent Version";
            this.ZabbixAgentVersion.Name = "ZabbixAgentVersion";
            this.ZabbixAgentVersion.Width = 140;
            // 
            // StatusOfLastAction
            // 
            this.StatusOfLastAction.HeaderText = "Status Of Last Action";
            this.StatusOfLastAction.Name = "StatusOfLastAction";
            this.StatusOfLastAction.Width = 200;
            // 
            // Textbox_Log
            // 
            this.Textbox_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Textbox_Log.BackColor = System.Drawing.SystemColors.Window;
            this.Textbox_Log.Location = new System.Drawing.Point(5, 3);
            this.Textbox_Log.Multiline = true;
            this.Textbox_Log.Name = "Textbox_Log";
            this.Textbox_Log.ReadOnly = true;
            this.Textbox_Log.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Textbox_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Textbox_Log.Size = new System.Drawing.Size(694, 77);
            this.Textbox_Log.TabIndex = 48;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.Button_Refresh);
            this.panel2.Controls.Add(this.Button_UnInstallService);
            this.panel2.Controls.Add(this.Button_DeploySelected);
            this.panel2.Controls.Add(this.Checkbox_SelectAll);
            this.panel2.Location = new System.Drawing.Point(3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(696, 29);
            this.panel2.TabIndex = 44;
            // 
            // Button_Refresh
            // 
            this.Button_Refresh.BackColor = System.Drawing.Color.LightCyan;
            this.Button_Refresh.Location = new System.Drawing.Point(456, 2);
            this.Button_Refresh.Name = "Button_Refresh";
            this.Button_Refresh.Size = new System.Drawing.Size(121, 23);
            this.Button_Refresh.TabIndex = 13;
            this.Button_Refresh.Text = "Refresh Selected";
            this.Button_Refresh.UseVisualStyleBackColor = false;
            this.Button_Refresh.Click += new System.EventHandler(this.Button_Refresh_Click);
            // 
            // Button_UnInstallService
            // 
            this.Button_UnInstallService.BackColor = System.Drawing.Color.MistyRose;
            this.Button_UnInstallService.Location = new System.Drawing.Point(279, 2);
            this.Button_UnInstallService.Name = "Button_UnInstallService";
            this.Button_UnInstallService.Size = new System.Drawing.Size(171, 23);
            this.Button_UnInstallService.TabIndex = 12;
            this.Button_UnInstallService.Text = "Uninstall Service From Selected";
            this.Button_UnInstallService.UseVisualStyleBackColor = false;
            this.Button_UnInstallService.Click += new System.EventHandler(this.Button_UnInstallService_Click);
            // 
            // Button_DeploySelected
            // 
            this.Button_DeploySelected.BackColor = System.Drawing.Color.PaleGreen;
            this.Button_DeploySelected.Location = new System.Drawing.Point(137, 2);
            this.Button_DeploySelected.Name = "Button_DeploySelected";
            this.Button_DeploySelected.Size = new System.Drawing.Size(136, 23);
            this.Button_DeploySelected.TabIndex = 11;
            this.Button_DeploySelected.Text = "Deploy To Selected";
            this.Button_DeploySelected.UseVisualStyleBackColor = false;
            this.Button_DeploySelected.Click += new System.EventHandler(this.Button_DeploySelected_Click);
            // 
            // Checkbox_SelectAll
            // 
            this.Checkbox_SelectAll.AutoSize = true;
            this.Checkbox_SelectAll.Location = new System.Drawing.Point(60, 9);
            this.Checkbox_SelectAll.Name = "Checkbox_SelectAll";
            this.Checkbox_SelectAll.Size = new System.Drawing.Size(70, 17);
            this.Checkbox_SelectAll.TabIndex = 10;
            this.Checkbox_SelectAll.Text = "Select All";
            this.Checkbox_SelectAll.UseVisualStyleBackColor = true;
            this.Checkbox_SelectAll.CheckedChanged += new System.EventHandler(this.Checkbox_SelectAll_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.Textbox_ManualAdd);
            this.panel1.Controls.Add(this.Button_ManualAdd);
            this.panel1.Controls.Add(this.Checkbox_ScanServersOnly);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.Button_Add);
            this.panel1.Controls.Add(this.Button_Remove);
            this.panel1.Controls.Add(this.LDAPBaseSearchPathLabel);
            this.panel1.Controls.Add(this.SelectComputerListBox);
            this.panel1.Controls.Add(this.LDAPBaseSearchPathBox);
            this.panel1.Controls.Add(this.Button_ScanLDAPComputers);
            this.panel1.Location = new System.Drawing.Point(705, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 473);
            this.panel1.TabIndex = 42;
            // 
            // Textbox_ManualAdd
            // 
            this.Textbox_ManualAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Textbox_ManualAdd.Location = new System.Drawing.Point(23, 143);
            this.Textbox_ManualAdd.Name = "Textbox_ManualAdd";
            this.Textbox_ManualAdd.Size = new System.Drawing.Size(188, 20);
            this.Textbox_ManualAdd.TabIndex = 40;
            // 
            // Button_ManualAdd
            // 
            this.Button_ManualAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_ManualAdd.Location = new System.Drawing.Point(217, 143);
            this.Button_ManualAdd.Name = "Button_ManualAdd";
            this.Button_ManualAdd.Size = new System.Drawing.Size(75, 23);
            this.Button_ManualAdd.TabIndex = 41;
            this.Button_ManualAdd.Text = "Manual Add";
            this.Button_ManualAdd.UseVisualStyleBackColor = true;
            this.Button_ManualAdd.Click += new System.EventHandler(this.Button_ManualAdd_Click);
            // 
            // Checkbox_ScanServersOnly
            // 
            this.Checkbox_ScanServersOnly.AutoSize = true;
            this.Checkbox_ScanServersOnly.Checked = true;
            this.Checkbox_ScanServersOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Checkbox_ScanServersOnly.Location = new System.Drawing.Point(134, 120);
            this.Checkbox_ScanServersOnly.Name = "Checkbox_ScanServersOnly";
            this.Checkbox_ScanServersOnly.Size = new System.Drawing.Size(158, 17);
            this.Checkbox_ScanServersOnly.TabIndex = 39;
            this.Checkbox_ScanServersOnly.Text = "Only include servers in scan";
            this.Checkbox_ScanServersOnly.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Label_Detect);
            this.groupBox1.Location = new System.Drawing.Point(23, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 36);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detected LDAP Root Domain Naming Context:";
            // 
            // Label_Detect
            // 
            this.Label_Detect.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Label_Detect.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Label_Detect.Location = new System.Drawing.Point(6, 17);
            this.Label_Detect.Name = "Label_Detect";
            this.Label_Detect.ReadOnly = true;
            this.Label_Detect.Size = new System.Drawing.Size(257, 13);
            this.Label_Detect.TabIndex = 0;
            this.Label_Detect.TabStop = false;
            this.Label_Detect.Text = "Not Detected";
            // 
            // Button_Add
            // 
            this.Button_Add.Location = new System.Drawing.Point(23, 172);
            this.Button_Add.Name = "Button_Add";
            this.Button_Add.Size = new System.Drawing.Size(75, 23);
            this.Button_Add.TabIndex = 42;
            this.Button_Add.Text = "<< Add";
            this.Button_Add.UseVisualStyleBackColor = true;
            this.Button_Add.Click += new System.EventHandler(this.Button_Add_Click);
            // 
            // Button_Remove
            // 
            this.Button_Remove.BackColor = System.Drawing.Color.Transparent;
            this.Button_Remove.Location = new System.Drawing.Point(23, 201);
            this.Button_Remove.Name = "Button_Remove";
            this.Button_Remove.Size = new System.Drawing.Size(75, 23);
            this.Button_Remove.TabIndex = 43;
            this.Button_Remove.Text = "Remove >>";
            this.Button_Remove.UseVisualStyleBackColor = false;
            this.Button_Remove.Click += new System.EventHandler(this.Button_Remove_Click);
            // 
            // LDAPBaseSearchPathLabel
            // 
            this.LDAPBaseSearchPathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LDAPBaseSearchPathLabel.AutoSize = true;
            this.LDAPBaseSearchPathLabel.Location = new System.Drawing.Point(31, 49);
            this.LDAPBaseSearchPathLabel.Name = "LDAPBaseSearchPathLabel";
            this.LDAPBaseSearchPathLabel.Size = new System.Drawing.Size(127, 13);
            this.LDAPBaseSearchPathLabel.TabIndex = 38;
            this.LDAPBaseSearchPathLabel.Text = "LDAP Base Search Path:";
            // 
            // SelectComputerListBox
            // 
            this.SelectComputerListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectComputerListBox.FormattingEnabled = true;
            this.SelectComputerListBox.Location = new System.Drawing.Point(104, 172);
            this.SelectComputerListBox.Name = "SelectComputerListBox";
            this.SelectComputerListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.SelectComputerListBox.Size = new System.Drawing.Size(188, 290);
            this.SelectComputerListBox.Sorted = true;
            this.SelectComputerListBox.TabIndex = 44;
            // 
            // LDAPBaseSearchPathBox
            // 
            this.LDAPBaseSearchPathBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LDAPBaseSearchPathBox.Location = new System.Drawing.Point(23, 65);
            this.LDAPBaseSearchPathBox.Name = "LDAPBaseSearchPathBox";
            this.LDAPBaseSearchPathBox.Size = new System.Drawing.Size(269, 20);
            this.LDAPBaseSearchPathBox.TabIndex = 37;
            // 
            // Button_ScanLDAPComputers
            // 
            this.Button_ScanLDAPComputers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_ScanLDAPComputers.Location = new System.Drawing.Point(126, 91);
            this.Button_ScanLDAPComputers.Name = "Button_ScanLDAPComputers";
            this.Button_ScanLDAPComputers.Size = new System.Drawing.Size(166, 23);
            this.Button_ScanLDAPComputers.TabIndex = 38;
            this.Button_ScanLDAPComputers.Text = "Scan LDAP for computers";
            this.Button_ScanLDAPComputers.UseVisualStyleBackColor = true;
            this.Button_ScanLDAPComputers.Click += new System.EventHandler(this.Button_ScanLDAPComputers_Click);
            // 
            // setupTapePage
            // 
            this.setupTapePage.Controls.Add(this.groupBox3);
            this.setupTapePage.Controls.Add(this.groupBox2);
            this.setupTapePage.Location = new System.Drawing.Point(4, 22);
            this.setupTapePage.Name = "setupTapePage";
            this.setupTapePage.Padding = new System.Windows.Forms.Padding(3);
            this.setupTapePage.Size = new System.Drawing.Size(1022, 479);
            this.setupTapePage.TabIndex = 1;
            this.setupTapePage.Text = "Setup";
            this.setupTapePage.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.ListBox_AdditionalInstallFiles);
            this.groupBox3.Controls.Add(this.Button_RemoveAdditionalFile);
            this.groupBox3.Controls.Add(this.Button_AddAdditionalFile);
            this.groupBox3.Controls.Add(this.Label_AlsoInstall64bit);
            this.groupBox3.Controls.Add(this.Label_AlsoInstall32bit);
            this.groupBox3.Controls.Add(this.Checkbox_AlsoInstallZabbixSender64bit);
            this.groupBox3.Controls.Add(this.Checkbox_AlsoInstallZabbixGet64bit);
            this.groupBox3.Controls.Add(this.Checkbox_AlsoInstallZabbixSender32bit);
            this.groupBox3.Controls.Add(this.Checkbox_AlsoInstallZabbixGet32bit);
            this.groupBox3.Controls.Add(this.Label_AgentVersion64bit);
            this.groupBox3.Controls.Add(this.Label_AgentVersion32bit);
            this.groupBox3.Controls.Add(this.Label_AgentVersion64bitStatic);
            this.groupBox3.Controls.Add(this.Label_AgentVersion32bitStatic);
            this.groupBox3.Controls.Add(this.Button_Selected32bitZabbixAgent);
            this.groupBox3.Controls.Add(this.Label_Selected32bitZabbixAgent);
            this.groupBox3.Controls.Add(this.Button_Selected64bitZabbixAgent);
            this.groupBox3.Controls.Add(this.Button_ShowConfig);
            this.groupBox3.Controls.Add(this.Label_Selected64bitZabbixAgent);
            this.groupBox3.Controls.Add(this.Label_ShowDefaultConfig);
            this.groupBox3.Location = new System.Drawing.Point(24, 194);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(940, 266);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Deployment options";
            // 
            // ListBox_AdditionalInstallFiles
            // 
            this.ListBox_AdditionalInstallFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBox_AdditionalInstallFiles.FormattingEnabled = true;
            this.ListBox_AdditionalInstallFiles.Location = new System.Drawing.Point(174, 175);
            this.ListBox_AdditionalInstallFiles.Name = "ListBox_AdditionalInstallFiles";
            this.ListBox_AdditionalInstallFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListBox_AdditionalInstallFiles.Size = new System.Drawing.Size(738, 82);
            this.ListBox_AdditionalInstallFiles.TabIndex = 60;
            // 
            // Button_RemoveAdditionalFile
            // 
            this.Button_RemoveAdditionalFile.Location = new System.Drawing.Point(22, 218);
            this.Button_RemoveAdditionalFile.Name = "Button_RemoveAdditionalFile";
            this.Button_RemoveAdditionalFile.Size = new System.Drawing.Size(130, 39);
            this.Button_RemoveAdditionalFile.TabIndex = 59;
            this.Button_RemoveAdditionalFile.Text = "Remove Additional File(s) To Install";
            this.Button_RemoveAdditionalFile.UseVisualStyleBackColor = true;
            this.Button_RemoveAdditionalFile.Click += new System.EventHandler(this.Button_RemoveAdditionalFile_Click);
            // 
            // Button_AddAdditionalFile
            // 
            this.Button_AddAdditionalFile.Location = new System.Drawing.Point(22, 175);
            this.Button_AddAdditionalFile.Name = "Button_AddAdditionalFile";
            this.Button_AddAdditionalFile.Size = new System.Drawing.Size(130, 39);
            this.Button_AddAdditionalFile.TabIndex = 58;
            this.Button_AddAdditionalFile.Text = "Add Additional File(s) To Install";
            this.Button_AddAdditionalFile.UseVisualStyleBackColor = true;
            this.Button_AddAdditionalFile.Click += new System.EventHandler(this.Button_AddAdditionalFile_Click);
            // 
            // Label_AlsoInstall64bit
            // 
            this.Label_AlsoInstall64bit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_AlsoInstall64bit.AutoSize = true;
            this.Label_AlsoInstall64bit.Location = new System.Drawing.Point(325, 109);
            this.Label_AlsoInstall64bit.Name = "Label_AlsoInstall64bit";
            this.Label_AlsoInstall64bit.Size = new System.Drawing.Size(141, 13);
            this.Label_AlsoInstall64bit.TabIndex = 56;
            this.Label_AlsoInstall64bit.Text = "Also install from this location:";
            // 
            // Label_AlsoInstall32bit
            // 
            this.Label_AlsoInstall32bit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_AlsoInstall32bit.AutoSize = true;
            this.Label_AlsoInstall32bit.Location = new System.Drawing.Point(325, 59);
            this.Label_AlsoInstall32bit.Name = "Label_AlsoInstall32bit";
            this.Label_AlsoInstall32bit.Size = new System.Drawing.Size(141, 13);
            this.Label_AlsoInstall32bit.TabIndex = 55;
            this.Label_AlsoInstall32bit.Text = "Also install from this location:";
            // 
            // Checkbox_AlsoInstallZabbixSender64bit
            // 
            this.Checkbox_AlsoInstallZabbixSender64bit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Checkbox_AlsoInstallZabbixSender64bit.AutoSize = true;
            this.Checkbox_AlsoInstallZabbixSender64bit.Location = new System.Drawing.Point(575, 108);
            this.Checkbox_AlsoInstallZabbixSender64bit.Name = "Checkbox_AlsoInstallZabbixSender64bit";
            this.Checkbox_AlsoInstallZabbixSender64bit.Size = new System.Drawing.Size(114, 17);
            this.Checkbox_AlsoInstallZabbixSender64bit.TabIndex = 54;
            this.Checkbox_AlsoInstallZabbixSender64bit.Text = "zabbix_sender.exe";
            this.Checkbox_AlsoInstallZabbixSender64bit.UseVisualStyleBackColor = true;
            // 
            // Checkbox_AlsoInstallZabbixGet64bit
            // 
            this.Checkbox_AlsoInstallZabbixGet64bit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Checkbox_AlsoInstallZabbixGet64bit.AutoSize = true;
            this.Checkbox_AlsoInstallZabbixGet64bit.Location = new System.Drawing.Point(472, 108);
            this.Checkbox_AlsoInstallZabbixGet64bit.Name = "Checkbox_AlsoInstallZabbixGet64bit";
            this.Checkbox_AlsoInstallZabbixGet64bit.Size = new System.Drawing.Size(97, 17);
            this.Checkbox_AlsoInstallZabbixGet64bit.TabIndex = 53;
            this.Checkbox_AlsoInstallZabbixGet64bit.Text = "zabbix_get.exe";
            this.Checkbox_AlsoInstallZabbixGet64bit.UseVisualStyleBackColor = true;
            // 
            // Checkbox_AlsoInstallZabbixSender32bit
            // 
            this.Checkbox_AlsoInstallZabbixSender32bit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Checkbox_AlsoInstallZabbixSender32bit.AutoSize = true;
            this.Checkbox_AlsoInstallZabbixSender32bit.Location = new System.Drawing.Point(575, 58);
            this.Checkbox_AlsoInstallZabbixSender32bit.Name = "Checkbox_AlsoInstallZabbixSender32bit";
            this.Checkbox_AlsoInstallZabbixSender32bit.Size = new System.Drawing.Size(114, 17);
            this.Checkbox_AlsoInstallZabbixSender32bit.TabIndex = 52;
            this.Checkbox_AlsoInstallZabbixSender32bit.Text = "zabbix_sender.exe";
            this.Checkbox_AlsoInstallZabbixSender32bit.UseVisualStyleBackColor = true;
            // 
            // Checkbox_AlsoInstallZabbixGet32bit
            // 
            this.Checkbox_AlsoInstallZabbixGet32bit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Checkbox_AlsoInstallZabbixGet32bit.AutoSize = true;
            this.Checkbox_AlsoInstallZabbixGet32bit.Location = new System.Drawing.Point(472, 58);
            this.Checkbox_AlsoInstallZabbixGet32bit.Name = "Checkbox_AlsoInstallZabbixGet32bit";
            this.Checkbox_AlsoInstallZabbixGet32bit.Size = new System.Drawing.Size(97, 17);
            this.Checkbox_AlsoInstallZabbixGet32bit.TabIndex = 51;
            this.Checkbox_AlsoInstallZabbixGet32bit.Text = "zabbix_get.exe";
            this.Checkbox_AlsoInstallZabbixGet32bit.UseVisualStyleBackColor = true;
            // 
            // Label_AgentVersion64bit
            // 
            this.Label_AgentVersion64bit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_AgentVersion64bit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Label_AgentVersion64bit.Location = new System.Drawing.Point(173, 106);
            this.Label_AgentVersion64bit.Name = "Label_AgentVersion64bit";
            this.Label_AgentVersion64bit.ReadOnly = true;
            this.Label_AgentVersion64bit.Size = new System.Drawing.Size(146, 20);
            this.Label_AgentVersion64bit.TabIndex = 50;
            this.Label_AgentVersion64bit.TabStop = false;
            this.Label_AgentVersion64bit.Text = "None";
            // 
            // Label_AgentVersion32bit
            // 
            this.Label_AgentVersion32bit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_AgentVersion32bit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Label_AgentVersion32bit.Location = new System.Drawing.Point(173, 56);
            this.Label_AgentVersion32bit.Name = "Label_AgentVersion32bit";
            this.Label_AgentVersion32bit.ReadOnly = true;
            this.Label_AgentVersion32bit.Size = new System.Drawing.Size(146, 20);
            this.Label_AgentVersion32bit.TabIndex = 49;
            this.Label_AgentVersion32bit.TabStop = false;
            this.Label_AgentVersion32bit.Text = "None";
            // 
            // Label_AgentVersion64bitStatic
            // 
            this.Label_AgentVersion64bitStatic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_AgentVersion64bitStatic.AutoSize = true;
            this.Label_AgentVersion64bitStatic.Location = new System.Drawing.Point(72, 109);
            this.Label_AgentVersion64bitStatic.Name = "Label_AgentVersion64bitStatic";
            this.Label_AgentVersion64bitStatic.Size = new System.Drawing.Size(80, 13);
            this.Label_AgentVersion64bitStatic.TabIndex = 48;
            this.Label_AgentVersion64bitStatic.Text = "Version (64-bit):";
            // 
            // Label_AgentVersion32bitStatic
            // 
            this.Label_AgentVersion32bitStatic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_AgentVersion32bitStatic.AutoSize = true;
            this.Label_AgentVersion32bitStatic.Location = new System.Drawing.Point(72, 59);
            this.Label_AgentVersion32bitStatic.Name = "Label_AgentVersion32bitStatic";
            this.Label_AgentVersion32bitStatic.Size = new System.Drawing.Size(80, 13);
            this.Label_AgentVersion32bitStatic.TabIndex = 47;
            this.Label_AgentVersion32bitStatic.Text = "Version (32-bit):";
            // 
            // Button_Selected32bitZabbixAgent
            // 
            this.Button_Selected32bitZabbixAgent.Location = new System.Drawing.Point(22, 28);
            this.Button_Selected32bitZabbixAgent.Name = "Button_Selected32bitZabbixAgent";
            this.Button_Selected32bitZabbixAgent.Size = new System.Drawing.Size(130, 23);
            this.Button_Selected32bitZabbixAgent.TabIndex = 37;
            this.Button_Selected32bitZabbixAgent.Text = "Zabbix Agent (32-bit)";
            this.Button_Selected32bitZabbixAgent.UseVisualStyleBackColor = true;
            this.Button_Selected32bitZabbixAgent.Click += new System.EventHandler(this.Selected32bitZabbixAgent_Click);
            // 
            // Label_Selected32bitZabbixAgent
            // 
            this.Label_Selected32bitZabbixAgent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Selected32bitZabbixAgent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Label_Selected32bitZabbixAgent.Location = new System.Drawing.Point(173, 30);
            this.Label_Selected32bitZabbixAgent.Name = "Label_Selected32bitZabbixAgent";
            this.Label_Selected32bitZabbixAgent.ReadOnly = true;
            this.Label_Selected32bitZabbixAgent.Size = new System.Drawing.Size(739, 20);
            this.Label_Selected32bitZabbixAgent.TabIndex = 46;
            this.Label_Selected32bitZabbixAgent.TabStop = false;
            this.Label_Selected32bitZabbixAgent.Text = "None";
            // 
            // Button_Selected64bitZabbixAgent
            // 
            this.Button_Selected64bitZabbixAgent.Location = new System.Drawing.Point(22, 80);
            this.Button_Selected64bitZabbixAgent.Name = "Button_Selected64bitZabbixAgent";
            this.Button_Selected64bitZabbixAgent.Size = new System.Drawing.Size(130, 23);
            this.Button_Selected64bitZabbixAgent.TabIndex = 41;
            this.Button_Selected64bitZabbixAgent.Text = "Zabbix Agent (64-bit)";
            this.Button_Selected64bitZabbixAgent.UseVisualStyleBackColor = true;
            this.Button_Selected64bitZabbixAgent.Click += new System.EventHandler(this.Button_Selected64bitZabbixAgent_Click);
            // 
            // Button_ShowConfig
            // 
            this.Button_ShowConfig.Location = new System.Drawing.Point(22, 132);
            this.Button_ShowConfig.Name = "Button_ShowConfig";
            this.Button_ShowConfig.Size = new System.Drawing.Size(130, 23);
            this.Button_ShowConfig.TabIndex = 45;
            this.Button_ShowConfig.Text = "Default Config";
            this.Button_ShowConfig.UseVisualStyleBackColor = true;
            this.Button_ShowConfig.Click += new System.EventHandler(this.Button_ShowConfig_Click);
            // 
            // Label_Selected64bitZabbixAgent
            // 
            this.Label_Selected64bitZabbixAgent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Selected64bitZabbixAgent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Label_Selected64bitZabbixAgent.Location = new System.Drawing.Point(173, 82);
            this.Label_Selected64bitZabbixAgent.Name = "Label_Selected64bitZabbixAgent";
            this.Label_Selected64bitZabbixAgent.ReadOnly = true;
            this.Label_Selected64bitZabbixAgent.Size = new System.Drawing.Size(739, 20);
            this.Label_Selected64bitZabbixAgent.TabIndex = 44;
            this.Label_Selected64bitZabbixAgent.TabStop = false;
            this.Label_Selected64bitZabbixAgent.Text = "None";
            // 
            // Label_ShowDefaultConfig
            // 
            this.Label_ShowDefaultConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_ShowDefaultConfig.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Label_ShowDefaultConfig.Location = new System.Drawing.Point(173, 134);
            this.Label_ShowDefaultConfig.Name = "Label_ShowDefaultConfig";
            this.Label_ShowDefaultConfig.ReadOnly = true;
            this.Label_ShowDefaultConfig.Size = new System.Drawing.Size(739, 20);
            this.Label_ShowDefaultConfig.TabIndex = 43;
            this.Label_ShowDefaultConfig.TabStop = false;
            this.Label_ShowDefaultConfig.Text = "None";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.Label_Seconds);
            this.groupBox2.Controls.Add(this.NumericUpDown_WMITimeout);
            this.groupBox2.Controls.Add(this.Label_WMITimeout);
            this.groupBox2.Controls.Add(this.Textbox_Domain);
            this.groupBox2.Controls.Add(this.Textbox_UserName);
            this.groupBox2.Controls.Add(this.Textbox_Password);
            this.groupBox2.Controls.Add(this.domainLabel);
            this.groupBox2.Controls.Add(this.Label_ConnectionStatus);
            this.groupBox2.Controls.Add(this.userNameLabel);
            this.groupBox2.Controls.Add(this.Button_Connect);
            this.groupBox2.Controls.Add(this.passwordLabel);
            this.groupBox2.Location = new System.Drawing.Point(24, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(940, 161);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connection Settings";
            // 
            // Label_Seconds
            // 
            this.Label_Seconds.AutoSize = true;
            this.Label_Seconds.Location = new System.Drawing.Point(585, 22);
            this.Label_Seconds.Name = "Label_Seconds";
            this.Label_Seconds.Size = new System.Drawing.Size(49, 13);
            this.Label_Seconds.TabIndex = 42;
            this.Label_Seconds.Text = "Seconds";
            // 
            // NumericUpDown_WMITimeout
            // 
            this.NumericUpDown_WMITimeout.Location = new System.Drawing.Point(490, 19);
            this.NumericUpDown_WMITimeout.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NumericUpDown_WMITimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown_WMITimeout.Name = "NumericUpDown_WMITimeout";
            this.NumericUpDown_WMITimeout.Size = new System.Drawing.Size(89, 20);
            this.NumericUpDown_WMITimeout.TabIndex = 41;
            this.NumericUpDown_WMITimeout.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown_WMITimeout.ValueChanged += new System.EventHandler(this.NumericUpDown_WMITimeout_ValueChanged);
            // 
            // Label_WMITimeout
            // 
            this.Label_WMITimeout.AutoSize = true;
            this.Label_WMITimeout.Location = new System.Drawing.Point(392, 22);
            this.Label_WMITimeout.Name = "Label_WMITimeout";
            this.Label_WMITimeout.Size = new System.Drawing.Size(74, 13);
            this.Label_WMITimeout.TabIndex = 40;
            this.Label_WMITimeout.Text = "WMI Timeout:";
            // 
            // Textbox_Domain
            // 
            this.Textbox_Domain.Location = new System.Drawing.Point(136, 70);
            this.Textbox_Domain.Name = "Textbox_Domain";
            this.Textbox_Domain.Size = new System.Drawing.Size(200, 20);
            this.Textbox_Domain.TabIndex = 26;
            this.Textbox_Domain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Textbox_Domain_KeyDown);
            // 
            // Textbox_UserName
            // 
            this.Textbox_UserName.Location = new System.Drawing.Point(136, 19);
            this.Textbox_UserName.Name = "Textbox_UserName";
            this.Textbox_UserName.Size = new System.Drawing.Size(200, 20);
            this.Textbox_UserName.TabIndex = 24;
            this.Textbox_UserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Textbox_UserName_KeyDown);
            // 
            // Textbox_Password
            // 
            this.Textbox_Password.Location = new System.Drawing.Point(136, 43);
            this.Textbox_Password.Name = "Textbox_Password";
            this.Textbox_Password.PasswordChar = '*';
            this.Textbox_Password.Size = new System.Drawing.Size(200, 20);
            this.Textbox_Password.TabIndex = 25;
            this.Textbox_Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Textbox_Password_KeyDown);
            // 
            // domainLabel
            // 
            this.domainLabel.AutoSize = true;
            this.domainLabel.Location = new System.Drawing.Point(19, 73);
            this.domainLabel.Name = "domainLabel";
            this.domainLabel.Size = new System.Drawing.Size(46, 13);
            this.domainLabel.TabIndex = 26;
            this.domainLabel.Text = "Domain:";
            // 
            // Label_ConnectionStatus
            // 
            this.Label_ConnectionStatus.AutoSize = true;
            this.Label_ConnectionStatus.Location = new System.Drawing.Point(19, 137);
            this.Label_ConnectionStatus.Name = "Label_ConnectionStatus";
            this.Label_ConnectionStatus.Size = new System.Drawing.Size(115, 13);
            this.Label_ConnectionStatus.TabIndex = 39;
            this.Label_ConnectionStatus.Text = "Status: Not Connected";
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(19, 22);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(58, 13);
            this.userNameLabel.TabIndex = 27;
            this.userNameLabel.Text = "Username:";
            // 
            // Button_Connect
            // 
            this.Button_Connect.Location = new System.Drawing.Point(22, 107);
            this.Button_Connect.Name = "Button_Connect";
            this.Button_Connect.Size = new System.Drawing.Size(130, 23);
            this.Button_Connect.TabIndex = 27;
            this.Button_Connect.Text = "Connect";
            this.Button_Connect.UseVisualStyleBackColor = true;
            this.Button_Connect.Click += new System.EventHandler(this.Button_Connect_Click);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(19, 46);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 28;
            this.passwordLabel.Text = "Password:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.setupTapePage);
            this.tabControl1.Controls.Add(this.deployTabPage);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1030, 505);
            this.tabControl1.TabIndex = 60;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(115, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Data2
            // 
            this.Data2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Data2.HeaderText = "Data2";
            this.Data2.Name = "Data2";
            // 
            // Tick2
            // 
            this.Tick2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Tick2.HeaderText = "Tick2";
            this.Tick2.Name = "Tick2";
            this.Tick2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Data1
            // 
            this.Data1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Data1.HeaderText = "Data1";
            this.Data1.Name = "Data1";
            // 
            // Tick1
            // 
            this.Tick1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Tick1.HeaderText = "Tick1";
            this.Tick1.Name = "Tick1";
            this.Tick1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // OpenFileDialog_ZabbixAgent32bit
            // 
            this.OpenFileDialog_ZabbixAgent32bit.FileName = "zabbix_agentd.exe";
            // 
            // OpenFileDialog_ZabbixAgent64bit
            // 
            this.OpenFileDialog_ZabbixAgent64bit.FileName = "zabbix_agentd.exe";
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewButtonColumn1.HeaderText = "Custom Config";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 532);
            this.Controls.Add(this.Panel_ConnectedState);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(550, 570);
            this.Name = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Panel_ConnectedState.ResumeLayout(false);
            this.Panel_ConnectedState.PerformLayout();
            this.deployTabPage.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.setupTapePage.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_WMITimeout)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.Panel Panel_ConnectedState;
        private System.Windows.Forms.Label Label_ConnectedState;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog_AddAdditionalFile;
        private System.Windows.Forms.TabPage deployTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Button_Refresh;
        private System.Windows.Forms.Button Button_UnInstallService;
        private System.Windows.Forms.Button Button_DeploySelected;
        private System.Windows.Forms.CheckBox Checkbox_SelectAll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox Textbox_ManualAdd;
        private System.Windows.Forms.Button Button_ManualAdd;
        private System.Windows.Forms.CheckBox Checkbox_ScanServersOnly;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Label_Detect;
        private System.Windows.Forms.Button Button_Add;
        private System.Windows.Forms.Button Button_Remove;
        private System.Windows.Forms.Label LDAPBaseSearchPathLabel;
        private System.Windows.Forms.ListBox SelectComputerListBox;
        private System.Windows.Forms.TextBox LDAPBaseSearchPathBox;
        private System.Windows.Forms.Button Button_ScanLDAPComputers;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage setupTapePage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox ListBox_AdditionalInstallFiles;
        private System.Windows.Forms.Button Button_RemoveAdditionalFile;
        private System.Windows.Forms.Button Button_AddAdditionalFile;
        private System.Windows.Forms.Label Label_AlsoInstall64bit;
        private System.Windows.Forms.Label Label_AlsoInstall32bit;
        private System.Windows.Forms.CheckBox Checkbox_AlsoInstallZabbixSender64bit;
        private System.Windows.Forms.CheckBox Checkbox_AlsoInstallZabbixGet64bit;
        private System.Windows.Forms.CheckBox Checkbox_AlsoInstallZabbixSender32bit;
        private System.Windows.Forms.CheckBox Checkbox_AlsoInstallZabbixGet32bit;
        private System.Windows.Forms.TextBox Label_AgentVersion64bit;
        private System.Windows.Forms.TextBox Label_AgentVersion32bit;
        private System.Windows.Forms.Label Label_AgentVersion64bitStatic;
        private System.Windows.Forms.Label Label_AgentVersion32bitStatic;
        private System.Windows.Forms.Button Button_Selected32bitZabbixAgent;
        private System.Windows.Forms.TextBox Label_Selected32bitZabbixAgent;
        private System.Windows.Forms.Button Button_Selected64bitZabbixAgent;
        private System.Windows.Forms.Button Button_ShowConfig;
        private System.Windows.Forms.TextBox Label_Selected64bitZabbixAgent;
        private System.Windows.Forms.TextBox Label_ShowDefaultConfig;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox Textbox_Domain;
        private System.Windows.Forms.TextBox Textbox_UserName;
        private System.Windows.Forms.TextBox Textbox_Password;
        private System.Windows.Forms.Label domainLabel;
        private System.Windows.Forms.Label Label_ConnectionStatus;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Button Button_Connect;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Tick2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Tick1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComputerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OSArch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZabbixServiceState;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZabbixAgentVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusOfLastAction;
        private System.Windows.Forms.TextBox Textbox_Log;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog_LoadConfig;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog_SaveConfig;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog_ZabbixAgent32bit;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog_ZabbixAgent64bit;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.NumericUpDown NumericUpDown_WMITimeout;
        private System.Windows.Forms.Label Label_WMITimeout;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label Label_Seconds;
    }
}

