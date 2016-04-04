using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDTO
{
    class Intake_DTO
    {
        public Intake_DTO()
        {
        }
        public string IntakeID { get; set; }
        public string ServiceLineID { get; set; }
        public string Name { get; set; }
        public string HospitalName { get; set; }
        public string HospitalAddress { get; set; }
    }
}
