using DoktorKlinik.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Domain.Bölüm
{
    public class Part:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
