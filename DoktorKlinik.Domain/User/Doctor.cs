using DoktorKlinik.Domain.Bölüm;
using DoktorKlinik.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Domain.User
{
    public class Doctor:IEntity
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int KlinikUserId { get; set; }
        public int BolumId { get; set; }
        public KlinikUser KlinikUser { get; set; }
        public KlinikRole klinikRole { get; set; }
        public Part Bolum { get; set; }
    }
}
