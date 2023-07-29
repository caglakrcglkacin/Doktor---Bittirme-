using DoktorKlinik.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Domain.User
{
    public class Patients:IEntity
    {
        public int Id { get; set; }
        public int KlinikId { get; set; }
        public int RoleId { get; set; }
        public KlinikUser KlinikUser { get; set; }
        public KlinikRole KlinikRole { get; set; }

    }
}
