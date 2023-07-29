using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Dto
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Identity { get; set; }
        public int RoleId { get; set; }
        public int KlinikId { get; set; }
        public DateTime Birthday { get; set; }
    }
}
