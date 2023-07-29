using DoktorKlinik.Business.Interface_Service;
using DoktorKlinik.Business.Service_Base;
using DoktorKlinik.DataAccess;
using DoktorKlinik.Domain.Entity;
using DoktorKlinik.Domain.User;
using DoktorKlinik.Dto;
using DoktorKlinik.Summary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Business.Service
{
    public class DoctorService : BaseService<DoctorDto, DoctorSummary, Doctor>,IDoctorService
    {
        public DoctorService(TourContext tourContext) : base(tourContext)
        {
        }

        protected override Expression<Func<Doctor, DoctorDto>> DtoMapper => entity => new DoctorDto()
        {
            Id = entity.Id,
            RoleId = entity.klinikRole.Id,
            Name = entity.KlinikUser.Name,
            Surname = entity.KlinikUser.Surname,
            BirthDate = entity.KlinikUser.BirthDate,
            Identity = entity.KlinikUser.IdentityNumber,
            BolumId = entity.BolumId,
            UserId = entity.KlinikUser.Id,
            
        };

        protected override Expression<Func<Doctor, DoctorSummary>> SummaryMapper => entity => new DoctorSummary()
        {
            RoleAdı = entity.klinikRole.Name,
            Name = entity.KlinikUser.Name,
            Surname = entity.KlinikUser.Surname,
            BirthDate = entity.KlinikUser.BirthDate,
            Identity = entity.KlinikUser.IdentityNumber,
            BolumAdi = entity.Bolum.Name,
            ProfilPhoto= entity.KlinikUser.ProfileImage,
            

        };

        

        public IEnumerable<DoctorDto> GetDefintId(int BolumId)
        {
            var deger = _tourContext.Doctors.Where(p=>p.BolumId == BolumId)
                .Select(p=> new DoctorDto()
                {
                    Id = p.Id,                  
                    Name = p.KlinikUser.Name,
                    BolumId = p.BolumId
                    
                }).ToList();
            return deger;
        }

        public DoctorDto? GetDoctor(int UserId)
        {
            var deger = _tourContext.Doctors.Where(p => p.KlinikUserId == UserId).Select(DtoMapper).SingleOrDefault();
            return deger;
        }

        public DoctorSummary MapEntitys(DoctorSummary entity)
        {
            return new DoctorSummary()
            {
                Id=entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                BirthDate = entity.BirthDate,
                Identity = entity.Identity,
                BolumAdi = entity.BolumAdi,
                RoleAdı=entity.RoleAdı,
                ProfilPhoto=entity.ProfilPhoto,



            };
        }

        protected override Doctor MapEntity(DoctorDto model)
        {
            return new Doctor()
            {
                Id = model.Id,
                RoleId = model.RoleId,              
                KlinikUserId = model.UserId,
                BolumId = model.BolumId
            };
        }
    }
}
