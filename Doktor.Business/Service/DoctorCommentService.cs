using DoktorKlinik.Business.Interface_Service;
using DoktorKlinik.Business.Service_Base;
using DoktorKlinik.DataAccess;
using DoktorKlinik.Domain.Entity;
using DoktorKlinik.Domain.Yorum;
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
    public class DoctorCommentService : BaseService<DoctorCommentDto, DoctorCommentSummray, DoctorComment>,
        IDoctorComment
    {
        public DoctorCommentService(TourContext tourContext) : base(tourContext)
        {
        }

        protected override Expression<Func<DoctorComment, DoctorCommentDto>> DtoMapper => entity => new DoctorCommentDto()
        {
            Id = entity.Id,
            AppointmentId = entity.AppointmentId,
            Comment = entity.Comment
        };

        protected override Expression<Func<DoctorComment, DoctorCommentSummray>> SummaryMapper => entity => new DoctorCommentSummray()
        {
            Comment = entity.Comment,
            DoktorName = entity.AppointmentGet.Appointment.Doctors.KlinikUser.Name,
            PatientName = entity.AppointmentGet.Hasta.KlinikUser.Name,
            PatientSurname = entity.AppointmentGet.Hasta.KlinikUser.Surname,
            Tarih = entity.AppointmentGet.Appointment.DateOnly,
            Time = entity.AppointmentGet.Appointment.TimeOnly,
            Photo = entity.AppointmentGet.Hasta.KlinikUser.ProfileImage
            
        };

        public IEnumerable<DoctorCommentSummray> GetRandevu(int UserId)
        {
           return _tourContext.DoctorComments.Where(p=>p.AppointmentGet.Appointment.DoctorId == UserId)
                .Select(SummaryMapper)
                .ToList();
        }

        protected override DoctorComment MapEntity(DoctorCommentDto model)
        {
            return new DoctorComment()
            {
                Id = model.Id,
                AppointmentId = model.AppointmentId,
                Comment = model.Comment
            };
        }
    }
}
