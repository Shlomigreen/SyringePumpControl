using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PumpControl
{
    public partial class VolumeCalculator : Form
    {
        public string returnVolume { get; private set; }
        public string returnVolumeUnits { get; private set; }

        public VolumeCalculator(string rate, string rateUntis)
        {
            InitializeComponent();
            tb_rate.Text = rate;
            tb_units.Text = rateUntis;
            returnVolumeUnits = rateUntis.Substring(0, 1) + "L";


        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            returnVolume = tb_volume.Text;
        }

        private void tb_time_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float p = float.Parse(tb_time.Text);
                if (tb_units.Text.Substring(1, 1) == "M")
                    p = p * float.Parse(tb_rate.Text);
                else
                    if (tb_units.Text.Substring(1, 1) == "H")
                        p = p * float.Parse(tb_rate.Text) / 60;
                tb_volume.Text = p.ToString();
            }
            catch { }
        }

        private void tb_time_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
            {
                bt_ok.PerformClick();
            }
        }
    }
}
