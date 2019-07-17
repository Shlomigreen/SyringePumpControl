using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpControl
{
    class Parser
    {
        //Single pump communication functions
        public string Run(Pump p, string suffix = "\r\n")
        {
            string rtn = p.Address.ToString() + "RUN" + suffix;
            return rtn;
        }
        public string Stop(Pump p, string suffix = "\r\n")
        {
            string rtn = p.Address.ToString() + "STP" + suffix;
            return rtn;
        }
        public string Purge(Pump p, string suffix = "\r\n")
        {
            string rtn = p.Address.ToString() + "PUR" + suffix;
            return rtn;
        }

        public string Direction(Pump p, string suffix = "\r\n")
        {
            string rtn = p.Address.ToString() + "DIR" + p.Direction + suffix;
            return rtn;
        }
        public string Diameter(Pump p, string suffix = "\r\n")
        {
            string rtn = p.Address.ToString() + "DIA" + p.Diameter.ToString() + suffix;
            return rtn;
        }
        public string Rate(Pump p, string suffix = "\r\n")
        {
            string rtn = p.Address.ToString() + "RAT" + p.Rate.ToString() + p.RateUnits + suffix;
            return rtn;
        }
        public string Volume(Pump p, string suffix = "\r\n")
        {
            string rtn = p.Address.ToString() + "VOL" + p.Volume.ToString() + suffix;
            return rtn;
        }
        public string VolumeUnits(Pump p, string suffix = "\r\n")
        {
            string rtn = p.Address.ToString() + "VOL" + p.VolumeUnits + suffix;
            return rtn;
        }

        //Network communication functions
        public string Run(List<Pump> ps)
        {
            int i;
            string rtn = "";
            for (i = 0; i < (ps.Count - 1); i++)
            {
                rtn += Run(ps[i], "*");
            }
            rtn += Run(ps[i]);
            return rtn;
        }
        public string Stop(List<Pump> ps)
        {
            int i;
            string rtn = "";
            for (i = 0; i < (ps.Count - 1); i++)
            {
                rtn += Stop(ps[i], "*");
            }
            rtn += Stop(ps[i]);
            return rtn;
        }

        public string Direction(List<Pump> ps)
        {
            int i;
            string rtn = "";
            for (i = 0; i < (ps.Count - 1); i++)
            {
                rtn += Direction(ps[i], "*");
            }
            rtn += Direction(ps[i]);
            return rtn;
        }
        public string Diameter(List<Pump> ps)
        {
            int i;
            string rtn = "";
            for (i = 0; i < (ps.Count - 1); i++)
            {
                rtn += Diameter(ps[i], "*");
            }
            rtn += Diameter(ps[i]);
            return rtn;
        }
        public string Rate(List<Pump> ps)
        {
            int i;
            string rtn = "";
            for (i = 0; i < (ps.Count - 1); i++)
            {
                rtn += Rate(ps[i], "*");
            }
            rtn += Rate(ps[i]);
            return rtn;
        }
        public string Volume(List<Pump> ps)
        {
            int i;
            string rtn = "";
            for (i = 0; i < (ps.Count - 1); i++)
            {
                rtn += Volume(ps[i], "*");
            }
            rtn += Volume(ps[i]);
            return rtn;
        }
        public string VolumeUnits(List<Pump> ps)
        {
            int i;
            string rtn = "";
            for (i = 0; i < (ps.Count - 1); i++)
            {
                rtn += VolumeUnits(ps[i], "*");
            }
            rtn += VolumeUnits(ps[i]);
            return rtn;
        }

        public string ManualFeed(string st)
        {
            string st2 = st.Replace("|", "\r\n");
            return st2;
        }

        //Update all prase
        public List<string> MultiUpdate(Pump p)
        {
            List<string> rtn = new List<string>();
            rtn.Add(Direction(p));
            rtn.Add(Diameter(p));
            rtn.Add(Rate(p));
            rtn.Add(Volume(p));
            rtn.Add(VolumeUnits(p));
            return rtn;
        }
        public List<string> MultiUpdate(List<Pump> p)
        {
            List<string> rtn = new List<string>();
            rtn.Add(Direction(p));
            rtn.Add(Diameter(p));
            rtn.Add(Rate(p));
            rtn.Add(Volume(p));
            rtn.Add(VolumeUnits(p));
            return rtn;
        }
        public List<string> UpdateAll(List<Pump> p)
        {
            string dir, dia, rat, vol, volu;
            dir = dia = rat = vol = volu = "";

            int i;
            for (i = 0; i < (p.Count - 1); i++)
            {
                dir += Direction(p[i], "*");
                dia += Diameter(p[i], "*");
                rat += Rate(p[i], "*");
                vol += Volume(p[i], "*");
                volu += VolumeUnits(p[i], "*");
            }

            dir += Direction(p[i]);
            dia += Diameter(p[i]);
            rat += Rate(p[i]);
            vol += Volume(p[i]);
            volu += VolumeUnits(p[i]);

            List<string> rtn = new List<string>();
            rtn.Add(dir);
            rtn.Add(dia);
            rtn.Add(rat);
            rtn.Add(vol);
            rtn.Add(volu);

            return rtn;
        }

        //General all prases
        public string RunAll()
        {
            return ("*RUN\r\n");
        }
        public string StopAll()
        {
            return ("*STP\r\n");
        }
        public string ChangePhaseAll(int n)
        {
            return ("*PHN"+n.ToString()+"\r\n");
        }
    }
}
