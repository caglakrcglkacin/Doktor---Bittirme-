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
    public class AppointmentGetiConfigrurations : IEntityTypeConfiguration<AppointmentGet>
    {
        public void Configure(EntityTypeBuilder<AppointmentGet> builder)
        {
            builder.ToTable(nameof(AppointmentGet));
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Appointment).WithMany().HasForeignKey(p => p.AppointmentId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.Hasta).WithMany().HasForeignKey(p => p.PatientId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
