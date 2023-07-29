using DoktorKlinik.Domain.Entity;
using DoktorKlinik.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Domain.Randevu
{
    public class AppointmentGet:IEntity
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int RandevuTamamlandımı { get; set; }
        public int YorumYapıldımı { get; set; }
        public Appointment Appointment { get; set; }
        public Patients Hasta { get; set; }
    }
}
