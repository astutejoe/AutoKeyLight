using Microsoft.Win32;
using System.Collections.Specialized;
using System.Text;
using System.Text.Json.Nodes;
using System.Xml;

namespace AutoKeyLight
{
    public partial class MainForm : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        const string webcamRegistryKey = @"Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\webcam";
        RegistryKey? startWithWindowsRegistry = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        bool areLightsOn = false;
        bool isCameraOn = false;
        CancellationTokenSource requestStateTokenSource;
        CancellationToken requestStateToken;
        Icon TrayIconUnlit;
        Icon TrayIconLit;
        DateTime cameraOnTime = DateTime.UtcNow;
        DateTime cameraOffTime = DateTime.UtcNow;
        decimal cameraOnDelay = Decimal.Zero;
        decimal cameraOffDelay = Decimal.Zero;
        DateTime lastAPICall = DateTime.UtcNow;

        public MainForm()
        {
            InitializeComponent();
            requestStateTokenSource = new CancellationTokenSource();
            requestStateToken = requestStateTokenSource.Token;

            TrayIconLit = Icon.FromHandle(Properties.Resources.TrayIconLit.GetHicon());
            TrayIconUnlit = Icon.FromHandle(Properties.Resources.TrayIconUnlit.GetHicon());
        }

        public static string? ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 200 };
            Button confirmation = new Button() { Text = "Ok", Left = 50, Width = 60, Top = 80, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "Cancel", Left = 110, Width = 60, Top = 80, DialogResult = DialogResult.Cancel };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            cancel.Click += (sender, e) => { textBox.Text = null; prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(cancel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text.Trim() : null;
        }

        void ReloadLights()
        {
            lbIPs.Items.Clear();
            lbIPs.ClearSelected();
            btnRemoveLight.Enabled = false;

            if (Properties.Settings.Default.IPs != null)
            {
                foreach (string? IP in Properties.Settings.Default.IPs)
                {
                    if (IP != null)
                        lbIPs.Items.Add(IP);
                }
            }
            else
            {
                Properties.Settings.Default.IPs = new StringCollection();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshLightsState();
            tmrCameraCheck_Tick(sender, e);

            ReloadLights();

            numUpDown.Value = cameraOnDelay = Properties.Settings.Default.CameraDelay;
            numUpDownOff.Value = cameraOffDelay = Properties.Settings.Default.CameraOffDelay;

            string elgatoSettingsFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Elgato", "ControlCenter", "Settings.xml");

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(elgatoSettingsFile);

                foreach (XmlNode outterNode in doc.ChildNodes)
                {
                    if (outterNode.Name == "AppSettings")
                    {
                        foreach (XmlNode node in outterNode.ChildNodes)
                        {
                            if (node.Name == "Application")
                            {
                                foreach (XmlNode innerNode in node.ChildNodes)
                                {
                                    if (innerNode.Name == "Accessories")
                                    {
                                        foreach (XmlNode accessoryNode in innerNode.ChildNodes)
                                        {
                                            foreach (XmlNode attribute in accessoryNode.ChildNodes)
                                            {
                                                if (attribute.Name == "IpAddress")
                                                {
                                                    if (!lbIPs.Items.Contains(attribute.InnerText.Trim()))
                                                    {
                                                        lbIPs.Items.Add(attribute.InnerText.Trim());
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            catch (FileNotFoundException) { }
            catch (DirectoryNotFoundException) { }

            niTray.Icon = TrayIconUnlit;
            Icon = Properties.Resources.Icon;
        }

        private void RefreshLightsState()
        {
            foreach (string IP in lbIPs.Items)
            {
                RefreshLightState(IP);
            }
        }

        private async void RefreshLightState(string IP)
        {
            lblError.Visible = false;

            try
            {
                string keylightURL = $"http://{IP}:9123/elgato/lights";

                HttpResponseMessage response = await httpClient.GetAsync(keylightURL, requestStateToken);

                if (response.IsSuccessStatusCode)
                {
                    bool success = false;

                    JsonNode? responseRoot = JsonNode.Parse(await response.Content.ReadAsStringAsync(requestStateToken));
                    if (responseRoot != null)
                    {
                        JsonNode? lightsArray = responseRoot.AsObject()["lights"];
                        if (lightsArray != null)
                        {
                            JsonNode? lightObject = lightsArray.AsArray()[0];
                            if (lightObject != null)
                            {
                                JsonNode? onProperty = lightObject.AsObject()["on"];
                                if (onProperty != null)
                                {
                                    areLightsOn = onProperty.GetValue<int>() == 1;
                                    lblLightState.Text = areLightsOn ? "Lights are ON" : "Lights are OFF";
                                    lblLightState.ForeColor = areLightsOn ? Color.LawnGreen : Color.IndianRed;
                                    success = true;
                                }
                            }
                        }
                    }

                    if (!success)
                    {
                        lblError.Visible = true;
                        lblError.Text = "Malformed JSON please\ncreate an Issue on GitHub";
                    }
                }
                else
                {
                    lblError.Visible = true;
                    lblLightState.Text = $"Error, check IP: {IP}";
                }
            }
            catch
            {
                lblError.Visible = true;
                lblError.Text = $"Error, check IP: {IP}";

                requestStateTokenSource = new CancellationTokenSource();
                requestStateToken = requestStateTokenSource.Token;
            }
        }

        private void ToggleLight(string IP, bool turnOn)
        {
            string keylightURL = $"http://{IP}:9123/elgato/lights";
            StringContent httpContent = new StringContent("{\"lights\": [{\"on\": " + (turnOn ? "1" : "0") + "}]}", Encoding.UTF8, "application/json");
            try
            {
                httpClient.PutAsync(keylightURL, httpContent);
            }
            catch { }
        }

        private void ToggleLights(bool turnOn)
        {
            foreach (string IP in lbIPs.Items)
            {
                ToggleLight(IP, turnOn);
            }
        }

        private void CameraIsOn()
        {
            RefreshLightsState();

            lblCameraState.Text = "Camera is ON";
            lblCameraState.ForeColor = Color.LawnGreen;
            niTray.Icon = TrayIconLit;

            if (!isCameraOn)
            {
                cameraOnTime = DateTime.UtcNow;
                isCameraOn = true;
            }

            if (cameraOnTime.AddMilliseconds(Decimal.ToDouble(cameraOnDelay)) > DateTime.UtcNow)
                return;

            if (lastAPICall.AddSeconds(1) > DateTime.UtcNow)
                return;

            ToggleLights(true);
        }

        private void CameraIsOff()
        {
            RefreshLightsState();
            niTray.Icon = TrayIconUnlit;

            lblCameraState.Text = "Camera is OFF";
            lblCameraState.ForeColor = Color.IndianRed;

            if (isCameraOn)
            {
                cameraOffTime = DateTime.UtcNow;
                isCameraOn = false;
            }

            if (cameraOffTime.AddMilliseconds(Decimal.ToDouble(cameraOffDelay)) > DateTime.UtcNow)
                return;

            if (lastAPICall.AddSeconds(1) > DateTime.UtcNow)
                return;

            ToggleLights(false);
        }

        private void tmrCameraCheck_Tick(object sender, EventArgs e)
        {
            RegistryKey? webcamAppsKey = Registry.CurrentUser.OpenSubKey(webcamRegistryKey);

            if (webcamAppsKey == null)
                return;

            string[] packagedKeys = webcamAppsKey.GetSubKeyNames();

            foreach (string key in packagedKeys)
            {
                RegistryKey? subKey = webcamAppsKey.OpenSubKey(key);

                if (subKey == null)
                    continue;

                Int64? timestamp = (Int64?)subKey.GetValue("LastUsedTimeStop");

                if (timestamp != null && timestamp == 0)
                {
                    CameraIsOn();
                    return;
                }
            }

            RegistryKey? nonPackagedKey;
            if ((nonPackagedKey = webcamAppsKey.OpenSubKey("NonPackaged")) != null)
            {
                string[] nonPackagedKeys = nonPackagedKey.GetSubKeyNames();

                foreach (string key in nonPackagedKeys)
                {
                    RegistryKey? subKey = nonPackagedKey.OpenSubKey(key);

                    if (subKey == null)
                        continue;

                    Int64? timestamp = (Int64?)subKey.GetValue("LastUsedTimeStop");

                    if (timestamp != null && timestamp == 0)
                    {
                        CameraIsOn();
                        return;
                    }
                }
            }

            CameraIsOff();
        }

        private void chkStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            if (startWithWindowsRegistry == null)
                return;

            if (chkStartWithWindows.Checked)
                startWithWindowsRegistry.SetValue("MyApp", Application.ExecutablePath);
            else
                startWithWindowsRegistry.DeleteValue("MyApp", false);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                niTray.Visible = true;
                this.Hide();
                e.Cancel = true;
            }
        }

        private void niTray_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            chkStartWithWindows.Checked = startWithWindowsRegistry != null && startWithWindowsRegistry.GetValue("MyApp") != null;

            if (chkStartWithWindows.Checked)
                this.Hide();
        }

        private void cmsTray_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == null)
                return;

            switch (e.ClickedItem.Name)
            {
                case "tsmiExit":
                    Application.Exit();
                    break;
                case "tsmiOpen":
                    Show();
                    break;
            }
        }

        private void btnAddLight_Click(object sender, EventArgs e)
        {
            string? newIP = ShowDialog("Light IP", "New Light");

            if (!string.IsNullOrEmpty(newIP))
            {
                Properties.Settings.Default.IPs.Add(newIP);
                Properties.Settings.Default.Save();
                ReloadLights();
            }
        }

        private void btnRemoveLight_Click(object sender, EventArgs e)
        {
            if (lbIPs.SelectedIndex >= 0)
            {
                Properties.Settings.Default.IPs.Remove((string?)lbIPs.SelectedItem);
                Properties.Settings.Default.Save();

                ReloadLights();
            }
        }

        private void lbIPs_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveLight.Enabled = lbIPs.SelectedIndex >= 0;
        }

        private void numUpDown_ValueChanged(object sender, EventArgs e)
        {
            cameraOnDelay = numUpDown.Value;
            Properties.Settings.Default.CameraDelay = cameraOnDelay;
            Properties.Settings.Default.Save();
        }

        private void numUpDownOff_ValueChanged(object sender, EventArgs e)
        {
            cameraOffDelay = numUpDownOff.Value;
            Properties.Settings.Default.CameraOffDelay = cameraOffDelay;
            Properties.Settings.Default.Save();
        }
    }
}