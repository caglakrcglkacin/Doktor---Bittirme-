using DoktorKlinik.Domain.Randevu;
using DoktorKlinik.Domain.Yorum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.DataAccess.Configurations
{
    public class DoctorCommentConfigrurations : IEntityTypeConfiguration<DoctorComment>
    {
        public void Configure(EntityTypeBuilder<DoctorComment> builder)
        {
            builder.ToTable(nameof(DoctorComment));
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Comment).IsRequired().HasColumnType("varchar(MAX)");
            builder.HasOne(p => p.AppointmentGet).WithMany().HasForeignKey(p => p.AppointmentId).OnDelete(DeleteBehavior.NoAction);
        
        }
    }
}
