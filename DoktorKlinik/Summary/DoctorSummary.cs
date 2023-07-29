using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Summary
{
  
    public class DoctorSummary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName => Name + " " + Surname;
        public string Identity { get; set; }
        public string ProfilPhoto { get; set; }
        public string RoleAdı { get; set; }
        public string BolumAdi { get; set; }
        public DateTime BirthDate { get; set; }
        public string KullanıcıPhoto { get; set; }
        public string Yorumlar { get; set; }
        public string Hakkında { get; set; }
    }
}
