using DoktorKlinik.Business.Interface_Service;
using DoktorKlinik.Business.Service_Base;
using DoktorKlinik.DataAccess;
using DoktorKlinik.Domain.Country;
using DoktorKlinik.Domain.User;
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
    public class RoleService : BaseService<RoleDto, RoleSummary, KlinikRole>, IRoleService
    {
        public RoleService(TourContext tourContext):base(tourContext)
        {

        }
        protected override Expression<Func<KlinikRole, RoleDto>> DtoMapper => entity => new RoleDto()
        {
            Id = entity.Id,
            Name = entity.Name,
            Nomalize = entity.Name.ToUpperInvariant()
        };

        protected override Expression<Func<KlinikRole, RoleSummary>> SummaryMapper => entity => new RoleSummary()
        {
            Id = entity.Id,
            Name = entity.Name
            
        };

        protected override KlinikRole MapEntity(RoleDto model)
        {
            return new KlinikRole()
            {
                
                Name = model.Name,
                NormalizedName = model.Name.ToUpperInvariant()

            };
        }
    }
}
