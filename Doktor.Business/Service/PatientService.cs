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
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Business.Service
{
    public class PatientService : BaseService<PatientDto, PatientSummray, Patients>, IPatientService
    {
        public PatientService(TourContext tourContext) : base(tourContext)
        {
        }

        protected override Expression<Func<Patients, PatientDto>> DtoMapper => entity => new PatientDto()
        {
            Id = entity.Id,
            RoleId = entity.KlinikUser.RoleId,
            Name= entity.KlinikUser.Name,
            Surname = entity.KlinikUser.Surname,
            Birthday = entity.KlinikUser.BirthDate,
            Identity = entity.KlinikUser.IdentityNumber,
           
            
    };

        protected override Expression<Func<Patients, PatientSummray>> SummaryMapper => entity => new PatientSummray()
        {


            RoleAdı = entity.KlinikRole.Name,
            Name = entity.KlinikUser.Name,
            Surname = entity.KlinikUser.Surname,
            BirthDate = entity.KlinikUser.BirthDate,
            Identity = entity.KlinikUser.IdentityNumber,
            ProfilPhoto=entity.KlinikUser.ProfileImage,
        };

        public IEnumerable<PatientSummray> GetSummaryId(int UserId)
        {
            var deger = _tourContext.Patient.Where(p => p.KlinikId == UserId).Select(SummaryMapper).ToList();
            return deger;
        }

        public PatientDto? GetUsertId(int UserId)
        {
            return _tourContext.Patient.Where(p=>p.KlinikId == UserId).Select(DtoMapper).First();
        }

        public PatientSummray MapEntitys(PatientSummray entity)
        {
           return new PatientSummray()
            {
                RoleAdı = entity.RoleAdı,
                Name = entity.Name,
                Surname = entity.Surname,
                BirthDate = entity.BirthDate,
                Identity = entity.Identity,
                ProfilPhoto= entity.ProfilPhoto
                
            };
        }

        protected override Patients MapEntity(PatientDto model)
        {
            return new Patients()
            {
                Id = model.Id,
                KlinikId = model.KlinikId,
                RoleId = model.RoleId
               
            };
        }

     

     
    }
}
