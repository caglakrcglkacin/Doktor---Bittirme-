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
    public class UserConfigurations : IEntityTypeConfiguration<KlinikUser>
    {
        public void Configure(EntityTypeBuilder<KlinikUser> builder)
        {
            builder.ToTable(nameof(KlinikUser));
            
            builder.HasKey(p=>p.Id);
            builder.Property(p=>p.Name).IsRequired().HasColumnType("varchar(50)");
            builder.Property(p => p.Surname).IsRequired().HasColumnType("varchar(50)");
            builder.Property(p => p.BirthDate).IsRequired().HasColumnType("Datetime");
           

        }
    }
}
