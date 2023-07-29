using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Summary
{
    public class UserSummary
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public string Phone { get; set; }       
        public string GenderName { get; set; }
        public string RoleName { get; set; }
        public string ProfileImage { get; set; }
        public DateTime BirthDate { get; set; }
        public string UserName { get; set; }
        public int Id { get; set; }
        public string NewPasswordAgin { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
    }
}
