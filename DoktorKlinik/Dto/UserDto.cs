using DoktorKlinik.Domain.User;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public string Phone { get; set; }
        public int GenderId { get; set; }
        public int BolumId { get; set; }
        public IEnumerable<SelectListItem> GendersList { get; set; }
        public IEnumerable<SelectListItem> RoleList { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public string ProfileImage { get; set; }
        public DateTime BirthDate { get; set; }
        public string NewPasswordAgin { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
        public string Email { get; set; }
        public bool RememberMe { get; set; }

    }
}
