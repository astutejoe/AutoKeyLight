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
            this.lblLightState = new System.Windows.Forms.Label();
            this.chkStartWithWindows = new System.Windows.Forms.CheckBox();
            this.niTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.lbIPs = new System.Windows.Forms.ListBox();
            this.btnAddLight = new System.Windows.Forms.Button();
            this.btnRemoveLight = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
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
            this.lblCameraState.Location = new System.Drawing.Point(12, 144);
            this.lblCameraState.Name = "lblCameraState";
            this.lblCameraState.Size = new System.Drawing.Size(80, 15);
            this.lblCameraState.TabIndex = 0;
            this.lblCameraState.Text = "Camera is ON";
            // 
            // lblLightState
            // 
            this.lblLightState.AutoSize = true;
            this.lblLightState.Location = new System.Drawing.Point(12, 166);
            this.lblLightState.Name = "lblLightState";
            this.lblLightState.Size = new System.Drawing.Size(79, 15);
            this.lblLightState.TabIndex = 4;
            this.lblLightState.Text = "Lights are ON";
            // 
            // chkStartWithWindows
            // 
            this.chkStartWithWindows.AutoSize = true;
            this.chkStartWithWindows.Location = new System.Drawing.Point(12, 218);
            this.chkStartWithWindows.Name = "chkStartWithWindows";
            this.chkStartWithWindows.Size = new System.Drawing.Size(128, 19);
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
            this.cmsTray.Size = new System.Drawing.Size(104, 48);
            this.cmsTray.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsTray_ItemClicked);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(103, 22);
            this.tsmiOpen.Text = "Open";
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(103, 22);
            this.tsmiExit.Text = "Exit";
            // 
            // lbIPs
            // 
            this.lbIPs.FormattingEnabled = true;
            this.lbIPs.ItemHeight = 15;
            this.lbIPs.Location = new System.Drawing.Point(12, 12);
            this.lbIPs.Name = "lbIPs";
            this.lbIPs.Size = new System.Drawing.Size(156, 94);
            this.lbIPs.TabIndex = 6;
            this.lbIPs.SelectedIndexChanged += new System.EventHandler(this.lbIPs_SelectedIndexChanged);
            // 
            // btnAddLight
            // 
            this.btnAddLight.Location = new System.Drawing.Point(12, 112);
            this.btnAddLight.Name = "btnAddLight";
            this.btnAddLight.Size = new System.Drawing.Size(75, 23);
            this.btnAddLight.TabIndex = 7;
            this.btnAddLight.Text = "Add";
            this.btnAddLight.UseVisualStyleBackColor = true;
            this.btnAddLight.Click += new System.EventHandler(this.btnAddLight_Click);
            // 
            // btnRemoveLight
            // 
            this.btnRemoveLight.Enabled = false;
            this.btnRemoveLight.Location = new System.Drawing.Point(93, 112);
            this.btnRemoveLight.Name = "btnRemoveLight";
            this.btnRemoveLight.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveLight.TabIndex = 8;
            this.btnRemoveLight.Text = "Remove";
            this.btnRemoveLight.UseVisualStyleBackColor = true;
            this.btnRemoveLight.Click += new System.EventHandler(this.btnRemoveLight_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.LightCoral;
            this.lblError.Location = new System.Drawing.Point(12, 189);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(37, 15);
            this.lblError.TabIndex = 9;
            this.lblError.Text = "Errors";
            this.lblError.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 248);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnRemoveLight);
            this.Controls.Add(this.btnAddLight);
            this.Controls.Add(this.lbIPs);
            this.Controls.Add(this.chkStartWithWindows);
            this.Controls.Add(this.lblLightState);
            this.Controls.Add(this.lblCameraState);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
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
        private Label lblLightState;
        private CheckBox chkStartWithWindows;
        private NotifyIcon niTray;
        private ContextMenuStrip cmsTray;
        private ToolStripMenuItem tsmiOpen;
        private ToolStripMenuItem tsmiExit;
        private ListBox lbIPs;
        private Button btnAddLight;
        private Button btnRemoveLight;
        private Label lblError;
    }
}