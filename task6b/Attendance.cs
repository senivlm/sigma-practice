using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace sigma_t6_b
{
    class Attendance
    {
        public string IP_v4 { get; private set; }
        public DateTime Time { get; private set; }
        public Attendance()
        {
            IP_v4 = "127.0.0.1";
            Time = DateTime.Now;
        }
        public Attendance(string ip_v4, DateTime time)
        {
            IP_v4 = ip_v4;
            Time = time;
        }
        public Attendance(string info)
        {
            string[] args = info.Split(' '),
                time = args[1].Split(':');
            IP_v4 = args[0].Trim();
            int h = int.Parse(time[0]),
                m = int.Parse(time[1]),
                s = int.Parse(time[2]), d;
            switch (args[2].ToLower())
            {
                case "sunday":      d = 0; break;
                case "monday":      d = 1; break;
                case "tuesday":     d = 2; break;
                case "wednesday":   d = 3; break;
                case "thursday":    d = 4; break;
                case "friday":      d = 5; break;
                case "saturday":    d = 6; break;
                default: throw new FormatException();
            }
            Time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, h, m, s);
            d = (d - (int)Time.DayOfWeek + 7) % 7;
            Time = Time.AddDays(d);
        }

        public override string ToString()
        {
            return "User " + IP_v4 + " visited website on " + Time.ToString("dddd 'at' hh:mm:ss.");
        }
    }
}
