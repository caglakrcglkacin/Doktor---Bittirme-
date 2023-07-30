
using DoktorKlinik.Domain.Randevu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.DataAccess.Configurations
{
    public class AppointmentConfigrurations : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable(nameof(Appointment));
            builder.HasKey(p => p.Id);
            builder.HasOne(p=>p.Doctors).WithMany().HasForeignKey(p => p.DoctorId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.Bolum).WithMany().HasForeignKey(p => p.PartId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
