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
            components = new System.ComponentModel.Container();
            tmrCameraCheck = new System.Windows.Forms.Timer(components);
            lblCameraState = new Label();
            lblLightState = new Label();
            chkStartWithWindows = new CheckBox();
            niTray = new NotifyIcon(components);
            cmsTray = new ContextMenuStrip(components);
            tsmiOpen = new ToolStripMenuItem();
            tsmiExit = new ToolStripMenuItem();
            lbIPs = new ListBox();
            btnAddLight = new Button();
            btnRemoveLight = new Button();
            lblError = new Label();
            numUpDown = new NumericUpDown();
            lblDelay = new Label();
            cmsTray.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numUpDown).BeginInit();
            SuspendLayout();
            // 
            // tmrCameraCheck
            // 
            tmrCameraCheck.Enabled = true;
            tmrCameraCheck.Interval = 1000;
            tmrCameraCheck.Tick += tmrCameraCheck_Tick;
            // 
            // lblCameraState
            // 
            lblCameraState.AutoSize = true;
            lblCameraState.Location = new Point(12, 144);
            lblCameraState.Name = "lblCameraState";
            lblCameraState.Size = new Size(80, 15);
            lblCameraState.TabIndex = 0;
            lblCameraState.Text = "Camera is ON";
            // 
            // lblLightState
            // 
            lblLightState.AutoSize = true;
            lblLightState.Location = new Point(12, 166);
            lblLightState.Name = "lblLightState";
            lblLightState.Size = new Size(79, 15);
            lblLightState.TabIndex = 4;
            lblLightState.Text = "Lights are ON";
            // 
            // chkStartWithWindows
            // 
            chkStartWithWindows.AutoSize = true;
            chkStartWithWindows.Location = new Point(12, 237);
            chkStartWithWindows.Name = "chkStartWithWindows";
            chkStartWithWindows.Size = new Size(128, 19);
            chkStartWithWindows.TabIndex = 5;
            chkStartWithWindows.Text = "Start with Windows";
            chkStartWithWindows.UseVisualStyleBackColor = true;
            chkStartWithWindows.CheckedChanged += chkStartWithWindows_CheckedChanged;
            // 
            // niTray
            // 
            niTray.ContextMenuStrip = cmsTray;
            niTray.Text = "Auto Key Light";
            niTray.Visible = true;
            niTray.DoubleClick += niTray_DoubleClick;
            // 
            // cmsTray
            // 
            cmsTray.ImageScalingSize = new Size(24, 24);
            cmsTray.Items.AddRange(new ToolStripItem[] { tsmiOpen, tsmiExit });
            cmsTray.Name = "cmsTray";
            cmsTray.Size = new Size(104, 48);
            cmsTray.ItemClicked += cmsTray_ItemClicked;
            // 
            // tsmiOpen
            // 
            tsmiOpen.Name = "tsmiOpen";
            tsmiOpen.Size = new Size(103, 22);
            tsmiOpen.Text = "Open";
            // 
            // tsmiExit
            // 
            tsmiExit.Name = "tsmiExit";
            tsmiExit.Size = new Size(103, 22);
            tsmiExit.Text = "Exit";
            // 
            // lbIPs
            // 
            lbIPs.FormattingEnabled = true;
            lbIPs.ItemHeight = 15;
            lbIPs.Location = new Point(12, 12);
            lbIPs.Name = "lbIPs";
            lbIPs.Size = new Size(156, 94);
            lbIPs.TabIndex = 6;
            lbIPs.SelectedIndexChanged += lbIPs_SelectedIndexChanged;
            // 
            // btnAddLight
            // 
            btnAddLight.Location = new Point(12, 112);
            btnAddLight.Name = "btnAddLight";
            btnAddLight.Size = new Size(75, 23);
            btnAddLight.TabIndex = 7;
            btnAddLight.Text = "Add";
            btnAddLight.UseVisualStyleBackColor = true;
            btnAddLight.Click += btnAddLight_Click;
            // 
            // btnRemoveLight
            // 
            btnRemoveLight.Enabled = false;
            btnRemoveLight.Location = new Point(93, 112);
            btnRemoveLight.Name = "btnRemoveLight";
            btnRemoveLight.Size = new Size(75, 23);
            btnRemoveLight.TabIndex = 8;
            btnRemoveLight.Text = "Remove";
            btnRemoveLight.UseVisualStyleBackColor = true;
            btnRemoveLight.Click += btnRemoveLight_Click;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.ForeColor = Color.LightCoral;
            lblError.Location = new Point(12, 188);
            lblError.Name = "lblError";
            lblError.Size = new Size(37, 15);
            lblError.TabIndex = 9;
            lblError.Text = "Errors";
            lblError.Visible = false;
            // 
            // numUpDown
            // 
            numUpDown.Location = new Point(81, 208);
            numUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numUpDown.Name = "numUpDown";
            numUpDown.Size = new Size(73, 23);
            numUpDown.TabIndex = 10;
            numUpDown.ValueChanged += numUpDown_ValueChanged;
            // 
            // lblDelay
            // 
            lblDelay.AutoSize = true;
            lblDelay.Location = new Point(12, 210);
            lblDelay.Name = "lblDelay";
            lblDelay.Size = new Size(63, 15);
            lblDelay.TabIndex = 11;
            lblDelay.Text = "Delay (ms)";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(184, 267);
            Controls.Add(lblDelay);
            Controls.Add(numUpDown);
            Controls.Add(lblError);
            Controls.Add(btnRemoveLight);
            Controls.Add(btnAddLight);
            Controls.Add(lbIPs);
            Controls.Add(chkStartWithWindows);
            Controls.Add(lblLightState);
            Controls.Add(lblCameraState);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            Text = "Auto Key Light";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            Shown += MainForm_Shown;
            cmsTray.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();

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
        private NumericUpDown numUpDown;
        private Label lblDelay;
    }
}