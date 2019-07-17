using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PumpControl
{
    public partial class MainWindow : Form
    {
        private Port _port;
        private Parser _parse = new Parser();
        private List<Pump> _pumps = new List<Pump>();

        private About aboutForm;

        //Variables to store images for connected / disconnected & Run / Stop
        private Image img_connected = Properties.Resources.icons8_connected_26;
        private Image img_disconnected = Properties.Resources.icons8_disconnected_26;
        private Image img_run = Properties.Resources.media_playback_start;
        private Image img_stop = Properties.Resources.media_playback_stop;

        public MainWindow()
        {
            InitializeComponent();

            //fill up ports in combo box
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames())
            {
                combo_selectPort.Items.Add(s);
            }

            //Add 4 pumps
            for(int i = 0; i < 4; i++)
            {
                AddPumpControls(i);
            }

            //Disable all pumps controls
            DisableControls();
        }

        #region Make form movable
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion
        /*
        #region Drop Shadow to form
        private const int CS_DROPSHADOW = 0x20000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        #endregion
        */

        #region User Interface
        private void pic_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog dg = new OpenFileDialog();
            dg.Title = "Open a Pump Profile...";
            dg.Filter = "Pumps Profile|*.pp";
            DataSet ds = new DataSet("PumpProfile");
            if (dg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                tb_profilePath.Text = dg.FileName;
                ds.ReadXml(dg.FileName);

                try
                {
                    //Set choosen port
                    combo_selectPort.Text = ds.Tables["Port"].Rows[0]["COM"].ToString();

                    //Set Pump's Parameters
                    int n = 0;
                    foreach (DataRow row in ds.Tables["Pump"].Rows)
                    {
                        panel2.Controls["address" + n.ToString()].Text = row["Address"].ToString();
                        panel2.Controls["direction" + n.ToString()].Text = row["Direction"].ToString();
                        panel2.Controls["diameter" + n.ToString()].Text = row["Diameter"].ToString();
                        panel2.Controls["rate" + n.ToString()].Text = row["Rate"].ToString();
                        panel2.Controls["rateunits" + n.ToString()].Text = row["RateUnits"].ToString();
                        panel2.Controls["volume" + n.ToString()].Text = row["Volume"].ToString();
                        panel2.Controls["volumeunits" + n.ToString()].Text = row["VolumeUnits"].ToString();
                        n++;
                    }
                }
                catch { }
            }
        }
        private void pic_save_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet("PumpProfile");
            ds.Tables.Add(new DataTable("Port"));
            ds.Tables.Add(new DataTable("Pump"));

            ds.Tables["Port"].Columns.Add("COM");
            DataRow row = ds.Tables["Port"].NewRow();
            row["COM"] = combo_selectPort.Text;
            ds.Tables["Port"].Rows.Add(row);


            ds.Tables["Pump"].Columns.Add("Address");
            ds.Tables["Pump"].Columns.Add("Direction");
            ds.Tables["Pump"].Columns.Add("Diameter");
            ds.Tables["Pump"].Columns.Add("Rate");
            ds.Tables["Pump"].Columns.Add("RateUnits");
            ds.Tables["Pump"].Columns.Add("Volume");
            ds.Tables["Pump"].Columns.Add("VolumeUnits");

            for(int n=0; n < _pumps.Count; n++)
            {
                row = ds.Tables["Pump"].NewRow();
                row["Address"] = panel2.Controls["address" + n.ToString()].Text;
                row["Direction"] = panel2.Controls["direction" + n.ToString()].Text;
                row["Diameter"] = panel2.Controls["diameter" + n.ToString()].Text;
                row["Rate"] = panel2.Controls["rate" + n.ToString()].Text;
                row["RateUnits"] = panel2.Controls["rateunits" + n.ToString()].Text;
                row["Volume"] = panel2.Controls["volume" + n.ToString()].Text;
                row["VolumeUnits"] = panel2.Controls["volumeunits" + n.ToString()];
                ds.Tables["Pump"].Rows.Add(row);
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Pumps Profile|*.pp";
            saveFileDialog1.Title = "Save Pumps Profile...";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                ds.WriteXml(saveFileDialog1.FileName);
            }
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Dispose Images
            img_connected.Dispose();
            img_disconnected.Dispose();
            img_run.Dispose();
            img_stop.Dispose();

            try
            {
                _port.Disconnect();
            }
            catch { }
        }
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            //Open file dialog
            if (e.Control && e.KeyCode == Keys.O)
            {
                pic_load_Click(new object(), new EventArgs());
            }

            //Open save dialog
            if (pic_save.Enabled)
                if (e.Control && e.KeyCode == Keys.S)
                    pic_save_Click(new object(), new EventArgs());

            if(e.Control && e.Shift && e.KeyCode == Keys.A)
            {
                if (tb_manualfeed.Visible)
                {
                    tb_manualfeed.Visible = false;
                    but_manualfeed.Visible = false;
                }
                else
                {
                    tb_manualfeed.Visible = true;
                    but_manualfeed.Visible = true;
                }
            }
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            try
            {
                if (pic_connect.Image == img_connected)
                {
                    _port.Disconnect();
                    DisableControls();
                    pic_connect.Image = img_disconnected;
                    generalToolTip.SetToolTip(pic_connect, "Connect to Port");
                }
                else
                {
                    _port = new Port(combo_selectPort.Text);
                    _port.Connect();
                    EnableControls();
                    pic_connect.Image = img_connected;
                    generalToolTip.SetToolTip(pic_connect, "Disconnect from Port");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Connecting Error");
            }
        }
        private void DisableControls(bool disable_startall = true)
        {
            //Disable pump controls
            foreach (Control c in panel2.Controls)
                c.Enabled = false;

            //Disable start all button 
            if (disable_startall)
            {
                but_startall.Enabled = false;
            }
        }
        private void EnableControls()
        {
            //Enable pump controls
            foreach (Control c in panel2.Controls)
                c.Enabled = true;

            if (!but_startall.Enabled)
                but_startall.Enabled = true;
        }

        private void SendBuzz(int n)
        {
            _port.Send(_pumps[n].Address.ToString() + "BUZ1\r\n");
            Thread.Sleep(50);
            _port.Send(_pumps[n].Address.ToString() + "BUZ0\r\n");
        }
        private void SendBuzz()
        {
            _port.Send("*BUZ1\r\n");
            Thread.Sleep(50);
            _port.Send("*BUZ0\r\n");
        }

        private void but_startall_Click(object sender, EventArgs e)
        {
            try
            {
                if (but_startall.Text == "Start All")
                {
                    SendPumpUpdate();
                    SendBuzz();
                    _port.Send(_parse.RunAll());

                    but_startall.Text = "Stop All";
                    but_startall.BackColor = Color.Red;
                    DisableControls(false);
                }
                else
                {
                    string cmd = _parse.Stop(_pumps);
                    _port.Send(cmd);
                    but_startall.Text = "Start All";
                    but_startall.BackColor = Color.FromArgb(69, 92, 78);
                    EnableControls();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void but_manualfeed_Click(object sender, EventArgs e)
        {
            try
            {
                string st = _parse.ManualFeed(tb_manualfeed.Text);
                _port.Send(st);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error in Manual Feed");
            }
        }
        #endregion

        #region Strip Menu 
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void syringePumpUserManualPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[] PDF = Properties.Resources.NE_1600_Syringe_Pump_User_Manual;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(PDF);

            //Create PDF File From Binary of resources folders help.pdf
            System.IO.FileStream f = new System.IO.FileStream("Syringe Pump Manual.pdf", System.IO.FileMode.OpenOrCreate);

            //Write Bytes into Our Created help.pdf
            ms.WriteTo(f);
            f.Close();
            ms.Close();

            // Finally Show the Created PDF from resources 
            System.Diagnostics.Process.Start("Syringe Pump Manual.pdf");
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (aboutForm != null)
            {
                aboutForm.BringToFront();
            }
            else
            {
                aboutForm = new About();
                aboutForm.FormClosed += new FormClosedEventHandler(aboutForm_closed);
                aboutForm.Show();
            }
        }
        private void aboutForm_closed(object sender, EventArgs e)
        {
            aboutForm = null;
        }
        #endregion

        private void AddPumpControls(int n=0)
        {
            //n is the pump number or row number. Starts with zero.

            int y = 5; //top mirgin
            int fieldh = 20; //default field height
            int vspacer = fieldh + y; //vertical spacer

            //Address Text box
            TextBox textBox1 = new TextBox();
            textBox1.Location = new Point(3, y+(n* vspacer));
            textBox1.Name = "address" + n.ToString() ;
            textBox1.Size = new Size(30, fieldh);
            textBox1.Visible = true;
            textBox1.Show();
            panel2.Controls.Add(textBox1);
            //Direction Combo Box
            ComboBox combobox1 = new ComboBox();
            combobox1.Location = new Point(50, y+(n* vspacer));
            combobox1.Name = "direction" + n.ToString();
            combobox1.Size = new Size(100, fieldh);
            combobox1.DropDownStyle = ComboBoxStyle.DropDownList;
            combobox1.Items.AddRange(new object[] { "Infuse", "Withdraw" });
            combobox1.Visible = true;
            combobox1.Show();
            combobox1.SelectedIndexChanged += (sender, e) => direction_Changed(sender, e, n);
            panel2.Controls.Add(combobox1);

            //Diameter Text Box
            TextBox textBox2 = new TextBox();
            textBox2.Location = new Point(167, y+(n* vspacer));
            textBox2.Name = "diameter" + n.ToString();
            textBox2.Size = new Size(68, fieldh);
            textBox2.Visible = true;
            textBox2.Show();
            textBox2.TextChanged += (sender, e) => diameter_Changed(sender, e, n);
            textBox2.DoubleClick += (sender, e) => diameter_Click(sender, e, n);
            pumpsToolTip.SetToolTip(textBox2, "Type or Double click to choose diameter");
            panel2.Controls.Add(textBox2);

            //Rate Text Box
            TextBox textBox3 = new TextBox();
            textBox3.Location = new Point(252, y+(n* vspacer));
            textBox3.Name = "rate" + n.ToString();
            textBox3.Size = new Size(68, fieldh);
            textBox3.Visible = true;
            textBox3.Show();
            textBox3.TextChanged += (sender, e) => rate_Changed(sender, e, n);
            panel2.Controls.Add(textBox3);

            //Rate Units Combo box
            ComboBox combobox2 = new ComboBox();
            combobox2.Location = new Point(337, y+(n* vspacer));
            combobox2.Name = "rateunits" + n.ToString();
            combobox2.Size = new Size(100, fieldh);
            combobox2.DropDownStyle = ComboBoxStyle.DropDownList;
            combobox2.Items.AddRange(new object[] { "UM (\u03BCL/min)",
                "UH (\u03BCL/hr)",
                "MM (mL/min)",
                "MH (mL/hr)" });
            combobox2.Visible = true;
            combobox2.Show();
            combobox2.SelectedIndexChanged += (sender, e) => rateunits_Changed(sender, e, n);
            panel2.Controls.Add(combobox2);

            //Volume Text Box
            TextBox textBox4 = new TextBox();
            textBox4.Location = new Point(454, y+(n* vspacer));
            textBox4.Name = "volume" + n.ToString();
            textBox4.Size = new Size(68, fieldh);
            textBox4.Visible = true;
            textBox4.Show();
            textBox4.TextChanged += (sender, e) => volume_Changed(sender, e, n);
            panel2.Controls.Add(textBox4);

            //Volume Units Combo Box
            ComboBox combobox3 = new ComboBox();
            combobox3.Location = new Point(539, y+(n* vspacer));
            combobox3.Name = "volumeunits" + n.ToString();
            combobox3.Size = new Size(100, fieldh);
            combobox3.DropDownStyle = ComboBoxStyle.DropDownList;
            combobox3.Items.AddRange(new object[] { "UL", "ML" });
            combobox3.Visible = true;
            combobox3.Show();
            combobox3.SelectedIndexChanged += (sender, e) => volumeunits_Changed(sender, e, n);
            panel2.Controls.Add(combobox3);

            //Volume Calculator button (image)
            PictureBox picturebox3 = new PictureBox();
            picturebox3.Location = new Point(640, y + (n * vspacer) + fieldh / 16);
            picturebox3.Name = "volcalc_button" + n.ToString();
            picturebox3.Size = new Size(16, 16);
            picturebox3.Image = Properties.Resources.calculator;
            picturebox3.Visible = true;
            picturebox3.SizeMode = PictureBoxSizeMode.StretchImage;
            picturebox3.Show();
            picturebox3.Click += (sender, e) => volCalc_Click(sender, e, n);
            panel2.Controls.Add(picturebox3);
            pumpsToolTip.SetToolTip(picturebox3, "Volume Calculator");

            //Start or Stop button (image)
            PictureBox picturebox1 = new PictureBox();
            picturebox1.Location = new Point(665, y + (n * vspacer) + fieldh / 16);
            picturebox1.Name = "play_button" + n.ToString();
            picturebox1.Size = new Size(16, 16);
            picturebox1.Image = img_run;
            picturebox1.Click += (sender, e) => play_Click(sender, e, n);
            picturebox1.Visible = true;
            picturebox1.Show();
            panel2.Controls.Add(picturebox1);
            pumpsToolTip.SetToolTip(picturebox1, "Run pump " + n.ToString());

            //Purge button (image)
            PictureBox picturebox2 = new PictureBox();
            picturebox2.Location = new Point(685, y + (n * vspacer) + fieldh / 16);
            picturebox2.Name = "purge_button" + n.ToString();
            picturebox2.Size = new Size(16, 16);
            picturebox2.Image = Properties.Resources.media_seek_forward;
            picturebox2.Visible = true;
            picturebox2.Show();
            picturebox2.MouseDown += (sender, e) => purge_down(sender, e, n);
            picturebox2.MouseUp += (sender, e) => purge_up(sender, e, n);
            panel2.Controls.Add(picturebox2);
            pumpsToolTip.SetToolTip(picturebox2, "Purge pump " + n.ToString());

            //default values
            if (n<10)
                panel2.Controls["address" + n.ToString()].Text = "0" + n.ToString();
            else
                panel2.Controls["address" + n.ToString()].Text =  n.ToString();
            panel2.Controls["direction" + n.ToString()].Text = Properties.Settings.Default.defaulteDirection;
            panel2.Controls["diameter" + n.ToString()].Text = Properties.Settings.Default.defaultDiameter.ToString();
            panel2.Controls["rate" + n.ToString()].Text = Properties.Settings.Default.defaultRate.ToString();
            panel2.Controls["rateunits" + n.ToString()].Text = Properties.Settings.Default.defaultRateUnits;
            panel2.Controls["volume" + n.ToString()].Text = Properties.Settings.Default.defaultVolume.ToString();
            panel2.Controls["volumeunits" + n.ToString()].Text = Properties.Settings.Default.defaultVolumeUnits;
            //add new pump to list
            _pumps.Add(new Pump(int.Parse(panel2.Controls["address" + n.ToString()].Text),
                panel2.Controls["direction" + n.ToString()].Text,
                float.Parse(panel2.Controls["diameter" + n.ToString()].Text),
                float.Parse(panel2.Controls["rate" + n.ToString()].Text),
                panel2.Controls["rateunits" + n.ToString()].Text,
                float.Parse(panel2.Controls["volume" + n.ToString()].Text),
                panel2.Controls["volumeunits" + n.ToString()].Text));
        }
        private void SendPumpUpdate(int n)
        {
            List<string> cmds = _parse.MultiUpdate(_pumps[n]);
            foreach (string cmd in cmds)
            {
                _port.Send(cmd);
                Thread.Sleep(50);
            }
        }
        private void SendPumpUpdate()
        {
            List<string> cmds = _parse.UpdateAll(_pumps);
            foreach (string cmd in cmds)
            {
                _port.Send(cmd);
                Thread.Sleep(50);
            }
        }

        #region Single Pump Actions
        private void play_Click(object sender, EventArgs e, int n)
        {
           
            PictureBox t = (PictureBox)panel2.Controls["play_button" + n.ToString()];
            if (t.Image == img_run)
            {
                SendPumpUpdate(n);
                SendBuzz(n);
                string cmd = _parse.Run(_pumps[n]);
                _port.Send(cmd);
                t.Image = img_stop;
            }
            else
            {
                string cmd = _parse.Stop(_pumps[n]);
                _port.Send(cmd);
                t.Image = img_run;
            }
            
        }
        private void diameter_Changed(object sender, EventArgs e, int n)
        {
            try
            {
                _pumps[n].Diameter = float.Parse(panel2.Controls["diameter" + n.ToString()].Text);
            }
            catch { }
        }
        private void direction_Changed(object sender, EventArgs e, int n)
        {
            try
            {
                _pumps[n].SetDirection(panel2.Controls["direction" + n.ToString()].Text);
            }
            catch { }
        }
        private void rate_Changed(object sender, EventArgs e, int n)
        {
            try
            {
                _pumps[n].Rate = float.Parse(panel2.Controls["rate" + n.ToString()].Text);
            }
            catch { }
        }
        private void rateunits_Changed(object sender, EventArgs e, int n)
        {
            try
            {
                _pumps[n].SetRateUnits(panel2.Controls["rateunits" + n.ToString()].Text);
            }
            catch { }
        }
        private void volume_Changed(object sender, EventArgs e, int n)
        {
            try
            {
                _pumps[n].Volume = float.Parse(panel2.Controls["volume" + n.ToString()].Text);
            }
            catch { }
        }
        private void volumeunits_Changed(object sender, EventArgs e, int n)
        {
            try
            {
                _pumps[n].VolumeUnits = panel2.Controls["volumeunits" + n.ToString()].Text;
            }
            catch { }
        }

        private void purge_down(object sender, EventArgs e, int n)
        {
            try
            {
                SendPumpUpdate(n);
                _port.Send(_parse.Purge(_pumps[n]));
                PictureBox t = (PictureBox)panel2.Controls["purge_button" + n.ToString()];
                t.SizeMode = PictureBoxSizeMode.StretchImage;
                t.Size = new Size(15, 15);
            }
            catch { }
        }
        private void purge_up(object sender, EventArgs e, int n)
        {
            try
            {
                _port.Send(_parse.Stop(_pumps[n]));
                PictureBox t = (PictureBox)panel2.Controls["purge_button" + n.ToString()];
                t.SizeMode = PictureBoxSizeMode.StretchImage;
                t.Size = new Size(16, 16);
            }
            catch { }
        }

        private void volCalc_Click(object sender, EventArgs e, int n)
        {
            try
            {
                using (VolumeCalculator vc = new VolumeCalculator(panel2.Controls["rate" + n.ToString()].Text, panel2.Controls["rateunits" + n.ToString()].Text))
                {
                    if (vc.ShowDialog() == DialogResult.OK && vc.returnVolume != "")
                    {
                        panel2.Controls["volume" + n.ToString()].Text = vc.returnVolume;
                        panel2.Controls["volumeunits" + n.ToString()].Text = vc.returnVolumeUnits;
                    }
                }
            }
            catch { }
        }
        private void diameter_Click(object sender, EventArgs e, int n)
        {
            using (DiameterPickup dp = new DiameterPickup())
            {
                if (dp.ShowDialog() == DialogResult.OK && dp.returnVolume != "")
                {
                    panel2.Controls["diameter" + n.ToString()].Text = dp.returnVolume;
                }
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            LoadPPL lppl = new LoadPPL(2);
            lppl.ShowDialog();
            
        }
    }
}
