using DoktorKlinik.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Domain.User
{
    public class KlinikUser:IdentityUser<int> ,IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public string Phone { get; set; }
        public int GenderId { get; set; }
        public int RoleId { get; set; }
        
        public string ProfileImage { get; set; }
        public DateTime BirthDate { get; set; }     
        public Genders GenderCode { get; set; }
    }
}
