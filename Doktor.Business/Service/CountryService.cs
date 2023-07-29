using DoktorKlinik.Business.Interface_Service;
using DoktorKlinik.Business.Service_Base;
using DoktorKlinik.DataAccess;
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
    public class CountryService : BaseService<CountryDto, CountrySummray, Country>, ICountryService
    {
        public CountryService(TourContext tourContext) : base(tourContext)
        {

        }

        protected override Expression<Func<Country, CountryDto>> DtoMapper => entity => new CountryDto()
        {
            Id = entity.Id,
            Name = entity.Name
        };

        protected override Expression<Func<Country, CountrySummray>> SummaryMapper => entity => new CountrySummray()
        {
            Id = entity.Id,
            Name = entity.Name
        };

        protected override Country MapEntity(CountryDto model)
        {
            return new Country()
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
