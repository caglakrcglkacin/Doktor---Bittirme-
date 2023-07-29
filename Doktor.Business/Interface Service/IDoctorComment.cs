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
    public interface IDoctorComment:IBaseService<DoctorCommentDto,DoctorCommentSummray>
    {
        IEnumerable<DoctorCommentSummray> GetRandevu(int UserId);
    }
}
