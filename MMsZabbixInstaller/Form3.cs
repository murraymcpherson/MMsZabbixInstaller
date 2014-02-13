using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMsZabbixInstaller
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Textbox_CustomConfig.Clear();
        }

        public string ServerCustomConfig { get {return this.Textbox_CustomConfig.Text; } set { this.Textbox_CustomConfig.Text = value; } }

        private void Textbox_CustomConfig_KeyDown(object sender, KeyEventArgs e)
        {
          
            if (e.Control && e.KeyCode == Keys.A)
            {
                Textbox_CustomConfig.SelectAll();
            }
           
        }

    }
}
