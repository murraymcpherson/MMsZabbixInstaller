namespace MMsZabbixInstaller
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.Textbox_CustomConfig = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Textbox_CustomConfig
            // 
            this.Textbox_CustomConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Textbox_CustomConfig.Location = new System.Drawing.Point(0, 0);
            this.Textbox_CustomConfig.Multiline = true;
            this.Textbox_CustomConfig.Name = "Textbox_CustomConfig";
            this.Textbox_CustomConfig.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Textbox_CustomConfig.Size = new System.Drawing.Size(1029, 445);
            this.Textbox_CustomConfig.TabIndex = 0;
            this.Textbox_CustomConfig.TabStop = false;
            this.Textbox_CustomConfig.WordWrap = false;
            this.Textbox_CustomConfig.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Textbox_CustomConfig_KeyDown);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 445);
            this.Controls.Add(this.Textbox_CustomConfig);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.Text = "Customise Zabbix Agent Config For Server - (Note: delete all contents to reset to" +
    " default config)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Textbox_CustomConfig;


    }
}