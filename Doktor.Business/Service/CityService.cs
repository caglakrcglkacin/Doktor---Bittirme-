using DoktorKlinik.Business.Interface_Service;
using DoktorKlinik.Business.Service_Base;
using DoktorKlinik.DataAccess;
using DoktorKlinik.DataAccess.Configurations;
using DoktorKlinik.Domain.Country;
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
    public class CityService : BaseService<CityDto, CitySummray, City>, ICityService
    {
        public CityService(TourContext tourContext):base(tourContext)
        {

        }
        protected override Expression<Func<City, CityDto>> DtoMapper => entity => new CityDto()
        {
            Id = entity.Id,
            Name = entity.Name,
            CountryId = entity.CountryId,   
        };

        protected override Expression<Func<City, CitySummray>> SummaryMapper => entity => new CitySummray()
        {
            Id = entity.Id,
            Name = entity.Name,
            CountryName = entity.Country.Name
        };

        protected override City MapEntity(CityDto model)
        {
            return new City()
            {
                Id = model.Id,
                Name = model.Name,
                CountryId = model.CountryId

            };
        }
    }
}
