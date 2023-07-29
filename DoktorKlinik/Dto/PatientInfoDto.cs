using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Dto
{
    public class PatientInfoDto
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public int PatielId { get; set; }
        public string Comment { get; set; }
        

    }
}
