using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC403.Functions
{
    internal class IndicatorScale
    {
        public static string Err { get; set; }


        public static string getWeight(object sender)
        {
            string scaleName = "3590ET";
            string value = "";
            try
            {
                SerialPort serialPort1 = sender as SerialPort;
                switch (scaleName)
                {
                    case "X3":
                        string g = serialPort1.ReadExisting();
                        List<string> gg = new List<string>(g.Split('\x02'));
                        if (gg[1].Length == 10)
                        {
                            if (gg[1].Contains("CH"))
                            {
                                value = "0";
                            }
                            else if (gg[1].Contains("RH"))
                            {
                                value = "-" + gg[1].Substring(4, 5).Trim();
                            }
                            else if (gg[1].Contains("BH"))
                            {
                                value = gg[1].Substring(4, 5).Trim();
                            }
                        }
                        break;
                    case "IQ-355":
                        string a = serialPort1.ReadLine();
                        value = a.Substring(2, 7).Trim();
                        break;


                    case "RickLake 680":
                        string l = serialPort1.ReadLine();
                        if (l.Length == 13)
                        {
                            if (l.Contains('-'))
                            {
                                value = "-" + l.Substring(2, 7).Trim();
                            }
                            else
                            {
                                value = l.Substring(1, 8).Trim();
                            }
                        }
                        break;
                    case "RickLake 480":
                        string ll = serialPort1.ReadLine();
                        if (ll.Length == 13)
                        {
                            if (ll.Contains('-'))
                            {
                                value = "-" + ll.Substring(2, 7).Trim();
                            }
                            else
                            {
                                value = ll.Substring(1, 8).Trim();
                            }
                        }
                        break;

                    case "Leon Engineer LD5204-06":

                        string c = serialPort1.ReadExisting();
                        string[] cc = c.Split('\r');
                        if (cc[0].Length == 8)
                        {
                            if (cc[0].Contains('-'))
                            {
                                int cac = int.Parse(cc[0].Substring(3));
                                value = "-" + cac;
                            }
                            else
                            {
                                int cac = int.Parse(cc[0].Substring(3));
                                value = Convert.ToString(cac);
                            }
                        }
                        break;
                    case "Linear PM02":
                        string e = serialPort1.ReadExisting();
                        string[] eee = e.Split('');
                        if (eee[1].Contains("Z1"))
                        {
                            value = eee[1].Substring(1).Trim();
                        }
                        else
                        {
                            value = "-" + eee[1].Substring(1).Trim();
                        }
                        break;
                    case "Commander cadinal 210":
                        string f = serialPort1.ReadExisting();
                        string[] ff = f.Split('\r');
                        if (ff[0].Length == 17)
                        {
                            int fff = int.Parse(ff[0].Substring(0, 7).Trim());
                            value = Convert.ToString(fff);
                        }
                        break;
                    case "3590ET":
                        string h = serialPort1.ReadLine();
                        string[] hh = h.Split(',');
                        Console.WriteLine(h.Length);

                        int hhh = int.Parse(hh[2].Trim());
                        value = Convert.ToString(hhh);

                        break;
                    case "AND_4329 TRUCKSCALE":
                        string i = serialPort1.ReadLine();
                        string[] ii = i.Split(',');
                        if (ii[2].Contains('+'))
                        {
                            int iii = int.Parse(ii[2].Substring(1, 7));
                            value = Convert.ToString(iii);
                        }
                        else if (ii[2].Contains('-'))
                        {
                            int iii = int.Parse(ii[2].Substring(1, 7));
                            value = "-" + Convert.ToString(iii);
                        }
                        break;
                    case "AND_4327B PIONEER":
                        string j = serialPort1.ReadLine();
                        string[] jj = j.Split(',');
                        if (jj[2].Contains('+'))
                        {
                            double jjj = double.Parse(jj[2].Substring(1, 7));
                            value = Convert.ToString(jjj);
                        }
                        else if (jj[2].Contains('-'))
                        {
                            double jjj = double.Parse(jj[2].Substring(1, 7));
                            value = "-" + Convert.ToString(jjj);
                        }
                        break;
                    case "Commander PIONEER":
                        string k = serialPort1.ReadLine();
                        value = k.Substring(2, 7).Trim();
                        break;

                }
            }
            catch (Exception ex)
            {
                //   Log.Error("FuncMain RS232 Received " + ex.Message);
                return "ERROR";
            }
            return value;
        }
    }

}

