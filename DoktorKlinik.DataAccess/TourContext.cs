using DoktorKlinik.DataAccess.Configurations;
using DoktorKlinik.DataAccess.Setting;
using DoktorKlinik.Domain.Bölüm;

using DoktorKlinik.Domain.Randevu;
using DoktorKlinik.Domain.User;
using DoktorKlinik.Domain.Yorum;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.DataAccess
{
    public class TourContext: IdentityDbContext<KlinikUser,KlinikRole,int>
    {
        public TourContext()
        {

        }
        public TourContext(DbContextOptions op):base(op)
        {

        }
   
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentGet> AppointmentGets { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<DoctorComment> DoctorComments { get; set; }
        public DbSet<PatientInfo> PatientInfos { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patients> Patient { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            base.OnModelCreating(modelBuilder);//ıdenty kullanırken bu metodu kullanmak istiyorsak bunu kullanmamız gerekmektedir.

         
            modelBuilder.ApplyConfiguration(new AppointmentConfigrurations());
            modelBuilder.ApplyConfiguration(new AppointmentGetiConfigrurations());
            modelBuilder.ApplyConfiguration(new PatientInfoConfigrurations());
            modelBuilder.ApplyConfiguration(new DoctorCommentConfigrurations());
            modelBuilder.ApplyConfiguration(new PartConfigrurations());
            modelBuilder.ApplyConfiguration(new DoctorConfigrurations());
            modelBuilder.ApplyConfiguration(new PatientConfigrurations());
           
            modelBuilder.ApplyConfiguration(new RoleConfigrurations());



        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            optionsBuilder.UseSqlServer(DbSetting.DbConnectionString);///Constand olduğu için dbsetting sınıfından almamıza gerek yok
        }
    }
}
