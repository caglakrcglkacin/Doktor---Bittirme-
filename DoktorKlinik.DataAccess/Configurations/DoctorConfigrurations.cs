using DoktorKlinik.Domain.Randevu;
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
    public class DoctorConfigrurations : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable(nameof(Doctor));
            builder.HasKey(p=>p.Id);
            builder.HasOne(p=>p.klinikRole).WithMany().HasForeignKey(p => p.RoleId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.Bolum).WithMany().HasForeignKey(p => p.BolumId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.KlinikUser).WithMany().HasForeignKey(p => p.KlinikUserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
