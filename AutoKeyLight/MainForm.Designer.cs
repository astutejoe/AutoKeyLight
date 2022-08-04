namespace AutoKeyLight
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrCameraCheck = new System.Windows.Forms.Timer(this.components);
            this.lblCameraState = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lblLightState = new System.Windows.Forms.Label();
            this.chkStartWithWindows = new System.Windows.Forms.CheckBox();
            this.niTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrCameraCheck
            // 
            this.tmrCameraCheck.Enabled = true;
            this.tmrCameraCheck.Interval = 1000;
            this.tmrCameraCheck.Tick += new System.EventHandler(this.tmrCameraCheck_Tick);
            // 
            // lblCameraState
            // 
            this.lblCameraState.AutoSize = true;
            this.lblCameraState.Location = new System.Drawing.Point(17, 93);
            this.lblCameraState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCameraState.Name = "lblCameraState";
            this.lblCameraState.Size = new System.Drawing.Size(121, 25);
            this.lblCameraState.TabIndex = 0;
            this.lblCameraState.Text = "Camera is ON";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Key Light IP";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(124, 20);
            this.txtIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(125, 31);
            this.txtIP.TabIndex = 3;
            this.txtIP.TextChanged += new System.EventHandler(this.txtIP_TextChanged);
            // 
            // lblLightState
            // 
            this.lblLightState.AutoSize = true;
            this.lblLightState.Location = new System.Drawing.Point(17, 155);
            this.lblLightState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLightState.Name = "lblLightState";
            this.lblLightState.Size = new System.Drawing.Size(100, 25);
            this.lblLightState.TabIndex = 4;
            this.lblLightState.Text = "Light is ON";
            // 
            // chkStartWithWindows
            // 
            this.chkStartWithWindows.AutoSize = true;
            this.chkStartWithWindows.Location = new System.Drawing.Point(17, 217);
            this.chkStartWithWindows.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkStartWithWindows.Name = "chkStartWithWindows";
            this.chkStartWithWindows.Size = new System.Drawing.Size(191, 29);
            this.chkStartWithWindows.TabIndex = 5;
            this.chkStartWithWindows.Text = "Start with Windows";
            this.chkStartWithWindows.UseVisualStyleBackColor = true;
            this.chkStartWithWindows.CheckedChanged += new System.EventHandler(this.chkStartWithWindows_CheckedChanged);
            // 
            // niTray
            // 
            this.niTray.ContextMenuStrip = this.cmsTray;
            this.niTray.Text = "Auto Key Light";
            this.niTray.Visible = true;
            this.niTray.DoubleClick += new System.EventHandler(this.niTray_DoubleClick);
            // 
            // cmsTray
            // 
            this.cmsTray.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpen,
            this.tsmiExit});
            this.cmsTray.Name = "cmsTray";
            this.cmsTray.Size = new System.Drawing.Size(129, 68);
            this.cmsTray.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsTray_ItemClicked);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(128, 32);
            this.tsmiOpen.Text = "Open";
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(128, 32);
            this.tsmiExit.Text = "Exit";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 268);
            this.Controls.Add(this.chkStartWithWindows);
            this.Controls.Add(this.lblLightState);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCameraState);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Auto Key Light";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.cmsTray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrCameraCheck;
        private Label lblCameraState;
        private Label label1;
        private TextBox txtIP;
        private Label lblLightState;
        private CheckBox chkStartWithWindows;
        private NotifyIcon niTray;
        private ContextMenuStrip cmsTray;
        private ToolStripMenuItem tsmiOpen;
        private ToolStripMenuItem tsmiExit;
    }
}