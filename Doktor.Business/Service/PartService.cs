using DoktorKlinik.Business.Interface_Service;
using DoktorKlinik.Business.Service_Base;
using DoktorKlinik.DataAccess;
using DoktorKlinik.Domain.Bölüm;
using DoktorKlinik.Domain.Entity;
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
    public class PartService : BaseService<PartDto, PartSummray, Part>, IPartService
    {
        public PartService(TourContext tourContext) : base(tourContext)
        {
        }

        protected override Expression<Func<Part, PartDto>> DtoMapper => entity => new PartDto()
        {
            Id = entity.Id,
            Name = entity.Name
        };

        protected override Expression<Func<Part, PartSummray>> SummaryMapper => entity => new PartSummray()
        {
            Id = entity.Id,
            Name = entity.Name
        };

        protected override Part MapEntity(PartDto model)
        {
            return new Part()
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
