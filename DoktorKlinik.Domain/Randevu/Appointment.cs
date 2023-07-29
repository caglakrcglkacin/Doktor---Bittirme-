using DoktorKlinik.Domain.Bölüm;
using DoktorKlinik.Domain.Entity;
using DoktorKlinik.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Domain.Randevu
{
    public class Appointment:IEntity
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int  PartId { get; set; }
        public int RandevuAlidimi { get; set; }
        public DateTime DateOnly { get; set; }
        public TimeSpan TimeOnly { get; set; }
        public Doctor Doctors { get; set; }
        public Part Bolum { get; set; }
    }
}
