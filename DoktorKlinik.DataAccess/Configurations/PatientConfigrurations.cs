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
    public class PatientConfigrurations : IEntityTypeConfiguration<Patients>
    {
        public void Configure(EntityTypeBuilder<Patients> builder)
        {
            builder.ToTable(nameof(Patients));
            builder.HasKey(p=>p.Id);
            builder.HasOne(p => p.KlinikUser).WithMany().HasForeignKey(p=>p.KlinikId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.KlinikRole).WithMany().HasForeignKey(p => p.RoleId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
