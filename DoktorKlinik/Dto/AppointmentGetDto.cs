using DoktorKlinik.Domain.Randevu;
using DoktorKlinik.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Dto
{
    public class AppointmentGetDto
    
    {
         public int Id { get; set; }
        public int PartId { get; set; }
        public int DoctorId { get; set; }
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int UserId { get; set; }
        public int RandevuTamamlandımı { get; set; }
    }
}
