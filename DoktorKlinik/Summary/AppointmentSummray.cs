using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Summary
{
    public class AppointmentSummray
    {
        public int Id { get; set; }
        public int BolumId { get; set; }
        public string DoctorName { get; set; }
        public string Bolum { get; set; }
        public DateTime DateOnly { get; set; }
        public TimeSpan TimeOnly { get; set; }
    }
}
