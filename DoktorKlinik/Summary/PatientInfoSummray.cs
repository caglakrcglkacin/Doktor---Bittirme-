using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Summary
{
    public class PatientInfoSummray
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string PatientFulName => PatientName+" "+PatientSurname;
        public string DoktorName { get; set; }
        public DateTime Tarih { get; set; }
        public TimeSpan Time { get; set; }
        public string RandevuTarihVeSaat => Tarih + " " + Time;
        public string Comment { get; set; }
    }
}
