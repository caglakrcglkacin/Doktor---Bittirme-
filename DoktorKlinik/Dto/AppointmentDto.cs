using DoktorKlinik.Domain.Bölüm;
using DoktorKlinik.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Dto
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PartId { get; set; }
        public int RandevuAlindi { get; set; }
        public DateTime DateOnly { get; set; }
        public TimeSpan TimeOnly { get; set; }
     
    }
}
