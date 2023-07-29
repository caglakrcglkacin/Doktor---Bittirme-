using DoktorKlinik.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Domain.User
{
    public class KlinikRole:IdentityRole<int>,IEntity
    {
     
    }
}
