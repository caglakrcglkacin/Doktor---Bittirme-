using DoktorKlinik.Business.Interface_Service;
using DoktorKlinik.Business.Service_Base;
using DoktorKlinik.Bussiness;
using DoktorKlinik.DataAccess;
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
    public class AppointmentService : BaseService<AppointmentDto, AppointmentSummray, Appointment>, IAppointment
    {
        public AppointmentService(TourContext tourContext) : base(tourContext)
        {
        }

        protected override Expression<Func<Appointment, AppointmentDto>> DtoMapper => entity => new AppointmentDto()
        {
            Id = entity.Id,
            DateOnly = entity.DateOnly,
            DoctorId = entity.DoctorId,
            PartId = entity.PartId,
            TimeOnly = entity.TimeOnly,
            RandevuAlindi=entity.RandevuAlidimi
        };

        protected override Expression<Func<Appointment, AppointmentSummray>> SummaryMapper => entity => new AppointmentSummray()
        {
            DoctorName = entity.Doctors.KlinikUser.Name,
            Bolum = entity.Bolum.Name,
            DateOnly = entity.DateOnly,
            TimeOnly= entity.TimeOnly,
            BolumId = entity.Bolum.Id,
            Id= entity.Id,
            

        };

        public IEnumerable<AppointmentSummray> GetDefintId(int BolumId)
        {
           return _tourContext.Appointments.Where(p => p.PartId == BolumId && p.RandevuAlidimi==0/* && p.DateOnly >= DateTime.Now*/).Select(p => new AppointmentSummray()
            {
                DateOnly = p.DateOnly,
                DoctorName = p.Doctors.KlinikUser.Name,
                TimeOnly = p.TimeOnly,
                Bolum = p.Bolum.Name,
                Id=p.Id

            })
            .ToList();

            
        }

        public IEnumerable<AppointmentSummray> GetDoctorId(int DoctorId)
        {
            return _tourContext.Appointments.Where(p => p.DoctorId == DoctorId && p.RandevuAlidimi == 0 && p.DateOnly >= DateTime.Now).Select(p => new AppointmentSummray()
            {
                DateOnly = p.DateOnly,
                DoctorName = p.Doctors.KlinikUser.Name,
                TimeOnly = p.TimeOnly,
                Bolum = p.Bolum.Name,
                Id = p.Id

            })
         .ToList();
        }

        public IEnumerable<AppointmentSummray> GetRandevu(int Randevu)
        {

            return _tourContext.Appointments.Where(p => p.RandevuAlidimi == Randevu).Select(p => new AppointmentSummray()
            {
                DateOnly = p.DateOnly,
                DoctorName = p.Doctors.KlinikUser.Name,
                TimeOnly = p.TimeOnly,
                Bolum = p.Bolum.Name,
                Id = p.Id

            })
             .ToList();
        }

        public AppointmentDto UpdateId(int Id)
        {
           var deger  = _tourContext.Appointments.Where(p => p.Id == Id).Select(DtoMapper).First();
            _tourContext.Update(deger);
            _tourContext.SaveChanges();
            return deger;
           
        }

        protected override Appointment MapEntity(AppointmentDto model)
        {
            return new Appointment()
            {
                Id = model.Id,
                DateOnly = model.DateOnly,
                DoctorId = model.DoctorId,
                PartId = model.PartId,
                TimeOnly = model.TimeOnly,
                RandevuAlidimi=model.RandevuAlindi,

            };
        }
    }
}
