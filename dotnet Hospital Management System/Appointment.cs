using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_Hospital_Management_System
{
    public class Appointment
    {
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public string Description { get; set; }
    }
}
