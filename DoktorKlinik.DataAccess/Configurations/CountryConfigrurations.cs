using DoktorKlinik.DataAccess.SeetData;
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
    public class CountryConfigrurations : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable(nameof(Country));
            builder.HasKey(p=>p.Id);
            builder.Property(p => p.Name).IsRequired().HasColumnType("varchar(50)");
            builder.HasData(
                CountryData.Data01_Afganistan,
                CountryData.Data02_Almanya,
                CountryData.Data03_Us,
                CountryData.Data04_AMERİKAN,
                CountryData.Data05_ANDORRA,
                CountryData.Data06_ANGOLA,
                CountryData.Data07_Anguilla,
                CountryData.Data08_ANTİGUA,
                CountryData.Data09_ARJANTİN,
                CountryData.Data10_ARNAVUTLUK,
                CountryData.Data11_ARUBA,
                CountryData.Data12_AVUSTRALYA,
                CountryData.Data13_AZERBAYCAN,
                CountryData.Data14_BELCİKA,
                CountryData.Data15_BULGARİSTAN,
                CountryData.Data16_Turkiye,
                CountryData.Data17_Cin,
                CountryData.Data18_Yunanistan,
                CountryData.Data19_Rusya,
                CountryData.Data20_İtalya);

        }
    }
}
