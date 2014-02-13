using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MMsZabbixInstaller
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            //DONE: Create error check for file path, close filestream NOTE: Filestream is closed as part of the File.ReadAllText and File.WriteAllText Methods
            Textbox_ZabbixAgentDefaultConfig.Clear();
            Textbox_ZabbixAgentDefaultConfig.Text = GlobalVariables.defaultConfig;

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Zabbix Config Files (*.conf)|*.conf|All Files (*.*)|*.*";
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory() + "\\";
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Select New Default Configuration";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("Are you sure you want to set the new default config file to:\r\n\r\n" + openFileDialog1.FileName, 
                    "Set New Default Agent Config File", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    GlobalVariables.defaultConfig = File.ReadAllText(openFileDialog1.FileName);
                    Textbox_ZabbixAgentDefaultConfig.Clear();
                    Textbox_ZabbixAgentDefaultConfig.Text = GlobalVariables.defaultConfig;
                    Textbox_ZabbixAgentDefaultConfig.Select(0, 0);

                    //Set the GlobalVariables to the new values respective of the new config file
                    GlobalVariables.defaultConfigPath = Path.GetDirectoryName(openFileDialog1.FileName) + @"\";
                    GlobalVariables.defaultConfigFileName = Path.GetFileName(openFileDialog1.FileName);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save your changes to the file:\r\n\r\n" + GlobalVariables.defaultConfigPath +
                GlobalVariables.defaultConfigFileName, "Save Changes To Agent Config File", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                if (!(File.Exists(GlobalVariables.defaultConfigPath + GlobalVariables.defaultConfigFileName)))
                {
                    if (MessageBox.Show("File does not exist, do you want to create it?\r\n\r\n",
                        "Create New File?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        GlobalVariables.defaultConfig = Textbox_ZabbixAgentDefaultConfig.Text;
                        File.WriteAllText(GlobalVariables.defaultConfigPath + GlobalVariables.defaultConfigFileName, GlobalVariables.defaultConfig);
                    }
                }
                else
                {
                    GlobalVariables.defaultConfig = Textbox_ZabbixAgentDefaultConfig.Text;
                    File.WriteAllText(GlobalVariables.defaultConfigPath + GlobalVariables.defaultConfigFileName, GlobalVariables.defaultConfig);
                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
