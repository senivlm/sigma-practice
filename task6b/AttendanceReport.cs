using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace sigma_t6_b
{
    class AttendanceReport
    {
        private List<Attendance> attendances;

        public AttendanceReport()
        {
            attendances = new List<Attendance>();
        }

        public AttendanceReport(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach(string line in lines)
            {
                attendances.Add(new Attendance(line));
            }
        }

        public Attendance this[int index]
        {
            get { return attendances[index]; }
            set { attendances[index] = value; }
        }
    }
}
