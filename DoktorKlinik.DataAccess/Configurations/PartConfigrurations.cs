using DoktorKlinik.DataAccess.SeetData;
using DoktorKlinik.Domain.Bölüm;
using DoktorKlinik.Domain.Country;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.DataAccess.Configurations
{
    public class PartConfigrurations : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.ToTable(nameof(Part));
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasColumnType("varchar(50)");
            builder.HasData(
                PartData.Data01_Endodonti,
                PartData.Data02_Periodontoloji,
                PartData.Data06_Protez,
                PartData.Data03_Ağız,
                PartData.Data04_İmplantoloji,
                PartData.Data05_Estetik,
                PartData.Data07_Ortodonti);

        }
    }
}
