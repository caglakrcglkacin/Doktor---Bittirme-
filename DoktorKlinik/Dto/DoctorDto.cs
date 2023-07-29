using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Dto
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Identity { get; set; }
        public int RoleId { get; set; }
        public int BolumId { get; set; }
        public int UserId { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
