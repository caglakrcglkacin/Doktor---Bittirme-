using DoktorKlinik.Business.Service;
using DoktorKlinik.Business.Service_Base;
using DoktorKlinik.DataAccess.Migrations;
using DoktorKlinik.Domain.Randevu;
using DoktorKlinik.Domain.User;
using DoktorKlinik.Dto;
using DoktorKlinik.Summary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Business.Interface_Service
{
    public interface IAppointmentGet:IBaseService<AppointmentGetDto, AppointmentGetSummary>
    {
        IEnumerable<AppointmentGetSummary> GetSummaryId(int UserId);
        IEnumerable<AppointmentGetSummary> GetSummaryRandevu();
        IEnumerable<AppointmentGetSummary> GetDoctor(int UserId);
        IEnumerable<AppointmentGetSummary> GetDoctorSum(int UserId);
        Domain.Randevu.AppointmentGet Duzenle(int Id);
        Domain.Randevu.AppointmentGet Yorum(int Id);
    }
}
