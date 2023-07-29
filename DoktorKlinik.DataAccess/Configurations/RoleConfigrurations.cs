using DoktorKlinik.DataAccess.SeetData;
using DoktorKlinik.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.DataAccess.Configurations
{
    public class RoleConfigrurations : IEntityTypeConfiguration<KlinikRole>
    {
        public void Configure(EntityTypeBuilder<KlinikRole> builder)
        {
            builder.HasData(RoleData.Data01_Admin,
                RoleData.Data02_Doctor,
                RoleData.Data03_Patient);
           
        }
    }
}
