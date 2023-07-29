using DoktorKlinik.Domain.Randevu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Dto
{
    public class DoctorCommentDto
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string Comment { get; set; }
        
    }
}
