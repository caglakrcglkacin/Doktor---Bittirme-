using DoktorKlinik.Business.Interface_Service;
using DoktorKlinik.Business.Service_Base;
using DoktorKlinik.DataAccess;
using DoktorKlinik.DataAccess.Configurations;
using DoktorKlinik.DataAccess.Migrations;
using DoktorKlinik.Domain.Entity;
using DoktorKlinik.Domain.Randevu;
using DoktorKlinik.Dto;
using DoktorKlinik.Summary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Business.Service
{
    public class AppointmentGetService : BaseService<AppointmentGetDto, AppointmentGetSummary, Domain.Randevu.AppointmentGet>, IAppointmentGet
    {
        public AppointmentGetService(TourContext tourContext) : base(tourContext)
        {

        }

        protected override Expression<Func<Domain.Randevu.AppointmentGet, AppointmentGetDto>> DtoMapper => entity => new AppointmentGetDto()
        {
            Id = entity.Id,
            AppointmentId= entity.AppointmentId,
            PatientId= entity.PatientId,
            RandevuTamamlandımı = entity.RandevuTamamlandımı,
        };

        protected override Expression<Func<Domain.Randevu.AppointmentGet, AppointmentGetSummary>> SummaryMapper => entity => new AppointmentGetSummary()
        {
            PatientName = entity.Hasta.KlinikUser.Name,
            PatientSurname = entity.Hasta.KlinikUser.Surname,
            DoktorName = entity.Appointment.Doctors.KlinikUser.Name,
            Tarih = entity.Appointment.DateOnly,
            Time = entity.Appointment.TimeOnly,
            Id=entity.Id,
            

        };

        public Domain.Randevu.AppointmentGet Duzenle(int Id)
        {
            var resim = _tourContext.AppointmentGets.FirstOrDefault(p => p.Id == Id);
            resim.RandevuTamamlandımı = 1;

            _tourContext.SaveChanges();
            return resim;
        }

        public IEnumerable<AppointmentGetSummary> GetDoctor(int UserId)
        {

           return _tourContext.AppointmentGets.Where(p => p.Appointment.DoctorId == UserId && p.RandevuTamamlandımı == 0 && p.Appointment.DateOnly >= DateTime.Now.AddDays(2)).Select(SummaryMapper).ToList(); 
        }

        public IEnumerable<AppointmentGetSummary> GetDoctorSum(int UserId)
        {
            return _tourContext.AppointmentGets.Where(p => p.Appointment.DoctorId == UserId ).Select(SummaryMapper).ToList();

        }

        public IEnumerable<AppointmentGetSummary> GetSummaryId(int UserId)
        {
          return  _tourContext.AppointmentGets.Where(p=>p.PatientId == UserId && p.RandevuTamamlandımı == 0 && p.Appointment.DateOnly >= DateTime.Now).Select(SummaryMapper).ToList();
        }

        public IEnumerable<AppointmentGetSummary> GetSummaryRandevu(int doctorId)
        {
            return _tourContext.AppointmentGets.Where(p => p.RandevuTamamlandımı == 0 && p.Appointment.Doctors.KlinikUserId == doctorId && p.Appointment.DateOnly >= DateTime.Now).Select(SummaryMapper).ToList();
        }

        public IEnumerable<AppointmentGetSummary> GetSummaryRandevu()
        {
          return  _tourContext.AppointmentGets.Where(p => p.RandevuTamamlandımı == 1 && p.YorumYapıldımı == 0).Select(SummaryMapper).ToList();
        }

        public AppointmentGet Yorum(int Id)
        {
            var resim = _tourContext.AppointmentGets.FirstOrDefault(p => p.Id == Id);
            resim.YorumYapıldımı = 1;

            _tourContext.SaveChanges();
            return resim;
        }

        protected override Domain.Randevu.AppointmentGet MapEntity(AppointmentGetDto model)
        {
            return new Domain.Randevu.AppointmentGet()
            {
                Id = model.Id,
                AppointmentId = model.AppointmentId,
                PatientId = model.PatientId,
                RandevuTamamlandımı = model.RandevuTamamlandımı
            };
        }
    }
}
