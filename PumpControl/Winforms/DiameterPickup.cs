using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PumpControl
{
    public partial class DiameterPickup : Form
    {
        private DataSet pickupTable = new DataSet();
        public string returnVolume { get; private set; }
        public DiameterPickup()
        {
            InitializeComponent();
            pickupTable.ReadXml(XDocument.Parse(Properties.Resources.diameterpickup).CreateReader());

            string previous = "";
            foreach(DataRow row in pickupTable.Tables[0].Rows)
            {
                if(previous != row["Manufacturer"].ToString())
                    combo_manufacturer.Items.Add(row["Manufacturer"]);
                previous = row["Manufacturer"].ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_syringeVolume.Items.Clear();
            combo_syringeVolume.Text = "";
            lb_submitDiameter.Text = "";
            string manufacturer = combo_manufacturer.Text;
            int i = 0;
            while (pickupTable.Tables[0].Rows[i]["Manufacturer"].ToString() != manufacturer)
                i++;
            while (i < pickupTable.Tables[0].Rows.Count && pickupTable.Tables[0].Rows[i]["Manufacturer"].ToString() == manufacturer)
            {
                combo_syringeVolume.Items.Add(pickupTable.Tables[0].Rows[i]["SyringeVolume"]);
                i++;
            }
        }

        private void combo_syringeVolume_TextChanged(object sender, EventArgs e)
        {
            if (combo_syringeVolume.Text != "")
            {
                int i = 0;
                string manufacturer = combo_manufacturer.Text;
                string syringeVolume = combo_syringeVolume.Text;
                while (pickupTable.Tables[0].Rows[i]["Manufacturer"].ToString() != manufacturer || pickupTable.Tables[0].Rows[i]["SyringeVolume"].ToString() != syringeVolume)
                    i++;
                lb_submitDiameter.Text = pickupTable.Tables[0].Rows[i]["Diameter"].ToString();
                lb_mlhr.Text = pickupTable.Tables[0].Rows[i]["MaxRate"].ToString();
                lb_mlmin.Text = System.Math.Round(float.Parse(lb_mlhr.Text) / 60, 4).ToString();
                lb_minulhr.Text = pickupTable.Tables[0].Rows[i]["MinRate"].ToString();
                lb_minulmin.Text = System.Math.Round(float.Parse(lb_minulhr.Text) / 60, 3).ToString();
            }
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            returnVolume = lb_submitDiameter.Text;
        }
    }
}
