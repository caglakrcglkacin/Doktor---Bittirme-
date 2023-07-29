
using DoktorKlinik.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Business.Service_Base
{
    public interface IBaseService<TDto,TSummary>
    {
        CommadResult Create(TDto model);
        CommadResult Update(TDto model);
        
        CommadResult Delete(TDto model);
        CommadResult Delete(int Id);
        TDto? GetById(int Id);
        IEnumerable<TDto> GetAll();
        TSummary? GetSummaryById(int id);
        IEnumerable<TSummary> GetSummary();

    }
}
