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
    public class PatientInfoService : BaseService<PatientInfoDto, PatientInfoSummray, PatientInfo>, IPatientInfo
    {
        public PatientInfoService(TourContext tourContext) : base(tourContext)
        {
        }

        protected override Expression<Func<PatientInfo, PatientInfoDto>> DtoMapper => entity => new PatientInfoDto()
        {
            Id = entity.Id,
            AppointmentId= entity.Id,
            Comment = entity.Comment
            
        };

        protected override Expression<Func<PatientInfo, PatientInfoSummray>> SummaryMapper =>entit => new PatientInfoSummray()
        {
            Id = entit.Id,
            DoktorName = entit.AppointmentGet.Appointment.Doctors.KlinikUser.Name,
            PatientName = entit.AppointmentGet.Hasta.KlinikUser.Name,
            PatientSurname= entit.AppointmentGet.Hasta.KlinikUser.Surname,
            Comment = entit.Comment,
            Tarih = entit.AppointmentGet.Appointment.DateOnly,
            Time = entit.AppointmentGet.Appointment.TimeOnly
            
        };

        public IEnumerable<PatientInfoSummray> GetPatientInfoSummrays(int Id)
        {
           return  _tourContext.PatientInfos.Where(p=>p.AppointmentGet.Hasta.Id == Id).Select(SummaryMapper).ToList();
        }

        protected override PatientInfo MapEntity(PatientInfoDto model)
        {
            return new PatientInfo()
            {
               
                AppointmentId = model.AppointmentId,
                Comment = model.Comment
            };

        }
    }
}
