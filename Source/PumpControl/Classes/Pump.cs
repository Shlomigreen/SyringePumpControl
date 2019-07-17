using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpControl
{
    class Pump
    {
        public int Address { get; set; }
        public string Direction { get; private set; }
        public float Diameter { get; set; }
        public float Rate { get; set; }
        public string RateUnits { get; set; }
        public float Volume { get; set; }
        public string VolumeUnits { get; set; }

        public Pump(int adr, string dir, float dia, float rt, string rtuni, float vl, string vluni)
        {
            Address = adr;
            SetDirection(dir);
            Diameter = dia;
            Rate = rt;
            SetRateUnits(rtuni);
            Volume = vl;
            VolumeUnits = vluni;
        }

        public Pump() { }

        public void SetDirection(string str)
        {
            Direction = DirConvert(str);
        }
        private string DirConvert(string str)
        {
            if (str == "INF")
                return str;
            else
                if (str == "WDR")
                return str;
            else
                    if (str == "Infuse")
                return "INF";
            else
                if (str == "Withdraw")
                return "WDR";
            return "INF"; //default value
        }

        public void SetRateUnits(string str)
        {
            RateUnits = str.Substring(0, 2);
        }

        public void UpdateAll(int adr, string dir, float dia, float rt, string rtuni, float vl, string vluni)
        {
            Address = adr;
            Direction = dir;
            Diameter = dia;
            Rate = rt;
            RateUnits = rtuni;
            Volume = vl;
            VolumeUnits = vluni;
        }
    }
}
