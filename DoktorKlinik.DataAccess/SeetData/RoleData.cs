
using DoktorKlinik.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.DataAccess.SeetData
{
    internal class RoleData
    {
        public readonly static KlinikRole Data01_Admin = new KlinikRole() { Id = 1, Name = "Admin", NormalizedName="ADMIN" };
        public readonly static KlinikRole Data02_Doctor = new KlinikRole() { Id = 2, Name = "Doktor", NormalizedName = "DOKTOR" };
        public readonly static KlinikRole Data03_Patient = new KlinikRole() { Id = 3, Name = "Hasta", NormalizedName = "HASTA" };
    }
}
