using DoktorKlinik.Domain.Bölüm;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.DataAccess.SeetData
{
    internal class PartData
    {
        public readonly static Part Data01_Endodonti = new Part() { Id = 1, Name = " Endodonti" };
        public readonly static Part Data02_Periodontoloji = new Part() { Id = 2, Name = " Periodontoloji" };
        public readonly static Part Data03_Ağız = new Part() { Id = 3, Name = " Ağız ve Çene Cerrahisi" };
        public readonly static Part Data04_‌İmplantoloji = new Part() { Id = 4, Name = " ‌İmplantoloji " };
        public readonly static Part Data05_Estetik = new Part() { Id = 5, Name = " Estetik Diş Hekimliği" };
        public readonly static Part Data06_Protez = new Part() { Id = 6, Name = " ‌Protez " };
        public readonly static Part Data07_Ortodonti = new Part() { Id = 7, Name = " Ortodonti " };
    }
}
