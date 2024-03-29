﻿namespace Wimp.Proxy.Demo
{
    partial class Main
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
            this.StartFiddler = new System.Windows.Forms.Button();
            this.StopFiddler = new System.Windows.Forms.Button();
            this.Path = new System.Windows.Forms.TextBox();
            this.Browse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.Status = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Logo = new System.Windows.Forms.Label();
            this.Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Autoskip = new System.Windows.Forms.CheckBox();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Status.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartFiddler
            // 
            this.StartFiddler.Location = new System.Drawing.Point(120, 44);
            this.StartFiddler.Name = "StartFiddler";
            this.StartFiddler.Size = new System.Drawing.Size(96, 38);
            this.StartFiddler.TabIndex = 0;
            this.StartFiddler.Text = "Start Proxy";
            this.StartFiddler.UseVisualStyleBackColor = true;
            this.StartFiddler.Click += new System.EventHandler(this.StartFiddler_Click);
            // 
            // StopFiddler
            // 
            this.StopFiddler.Enabled = false;
            this.StopFiddler.Location = new System.Drawing.Point(222, 44);
            this.StopFiddler.Name = "StopFiddler";
            this.StopFiddler.Size = new System.Drawing.Size(96, 38);
            this.StopFiddler.TabIndex = 1;
            this.StopFiddler.Text = "Stop Proxy";
            this.StopFiddler.UseVisualStyleBackColor = true;
            this.StopFiddler.Click += new System.EventHandler(this.StopFiddler_Click);
            // 
            // Path
            // 
            this.Path.Location = new System.Drawing.Point(164, 12);
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(154, 20);
            this.Path.TabIndex = 2;
            this.Path.TextChanged += new System.EventHandler(this.Path_TextChanged);
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(324, 12);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(78, 20);
            this.Browse.TabIndex = 3;
            this.Browse.Text = "Browse";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Target:";
            // 
            // Status
            // 
            this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.Progress});
            this.Status.Location = new System.Drawing.Point(0, 93);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(414, 22);
            this.Status.TabIndex = 5;
            this.Status.Text = "statusStrip1";
            this.Status.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = false;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(120, 17);
            this.StatusLabel.Text = "Proxy stopped...";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Logo
            // 
            this.Logo.AutoSize = true;
            this.Logo.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logo.ForeColor = System.Drawing.Color.Red;
            this.Logo.Location = new System.Drawing.Point(12, 9);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(93, 73);
            this.Logo.TabIndex = 6;
            this.Logo.Text = "W";
            this.Logo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Progress
            // 
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // Autoskip
            // 
            this.Autoskip.AutoSize = true;
            this.Autoskip.Location = new System.Drawing.Point(324, 44);
            this.Autoskip.Name = "Autoskip";
            this.Autoskip.Size = new System.Drawing.Size(78, 17);
            this.Autoskip.TabIndex = 7;
            this.Autoskip.Text = "Auto Mode";
            this.Autoskip.UseVisualStyleBackColor = true;
            this.Autoskip.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(146, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 115);
            this.Controls.Add(this.Autoskip);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.StopFiddler);
            this.Controls.Add(this.StartFiddler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.Text = "Wimp Proxy Demo";
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartFiddler;
        private System.Windows.Forms.Button StopFiddler;
        private System.Windows.Forms.TextBox Path;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.StatusStrip Status;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.Label Logo;
        private System.Windows.Forms.ToolStripProgressBar Progress;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.CheckBox Autoskip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}

