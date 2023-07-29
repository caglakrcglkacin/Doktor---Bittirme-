using DoktorKlinik.Domain.Entity;
using DoktorKlinik.Domain.Randevu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Domain.Yorum
{
    public class PatientInfo:IEntity
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string Comment { get; set; }
        public AppointmentGet AppointmentGet { get; set; }
    }
}
