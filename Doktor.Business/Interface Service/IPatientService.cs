using DoktorKlinik.Business.Service_Base;
using DoktorKlinik.Dto;
using DoktorKlinik.Summary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Business.Interface_Service
{
    public interface IPatientService:IBaseService<PatientDto,PatientSummray>
    {
        PatientDto? GetUsertId(int UserId);
        public abstract PatientSummray MapEntitys(PatientSummray entity);
    }
}
