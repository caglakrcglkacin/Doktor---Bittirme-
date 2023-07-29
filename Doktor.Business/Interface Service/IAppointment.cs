using DoktorKlinik.Business.Service_Base;
using DoktorKlinik.Bussiness;
using DoktorKlinik.Domain.Randevu;
using DoktorKlinik.Dto;
using DoktorKlinik.Summary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Business.Interface_Service
{
    public interface IAppointment:IBaseService<AppointmentDto, AppointmentSummray>
    {
        IEnumerable<AppointmentSummray> GetDefintId(int BolumId);
        IEnumerable<AppointmentSummray> GetDoctorId(int DoctorId);
        IEnumerable<AppointmentSummray> GetRandevu(int Randevu);
      
    }
}
