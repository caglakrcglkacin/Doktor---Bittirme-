using DoktorKlinik.Business.Service_Base;
using DoktorKlinik.Domain.Entity;
using DoktorKlinik.Domain.User;
using DoktorKlinik.Dto;
using DoktorKlinik.Summary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Business.Interface_Service
{
    public interface IDoctorService:IBaseService<DoctorDto,DoctorSummary>
    {
        public abstract DoctorSummary MapEntitys(DoctorSummary entity);
        IEnumerable<DoctorDto> GetDefintId(int BolumId);
        DoctorDto? GetDoctor(int UserId);
    }
}
