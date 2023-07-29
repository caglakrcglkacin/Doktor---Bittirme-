using DoktorKlinik.Business.Interface_Service;
using DoktorKlinik.Business.Service_Base;
using DoktorKlinik.DataAccess;
using DoktorKlinik.Domain.Entity;
using DoktorKlinik.Domain.User;
using DoktorKlinik.Dto;
using DoktorKlinik.Summary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Business.Service
{
    public class UserService : BaseService<UserDto, UserSummary, KlinikUser>, IUserServices
    {
        public UserService(TourContext tourContext) : base(tourContext)
        {

        }

        protected override Expression<Func<KlinikUser, UserDto>> DtoMapper => entity =>new UserDto()
        {
            IdentityNumber = entity.IdentityNumber,
            RoleId=entity.RoleId,
            Id= entity.Id,
            BirthDate=entity.BirthDate,
            Name = entity.Name,
            Surname = entity.Surname,
            UserName = entity.UserName,
            Phone = entity.Phone,   
            ProfileImage = entity.ProfileImage,
            Email = entity.Email,
            NewPassword = entity.PasswordHash


        };

        protected override Expression<Func<KlinikUser, UserSummary>> SummaryMapper => entity => new UserSummary()
        {
            IdentityNumber = entity.IdentityNumber,
           
            GenderName = entity.GenderCode.ToString(),
            BirthDate = entity.BirthDate,
            Name = entity.Name,
            Surname = entity.Surname,
            UserName = entity.UserName,
            Phone = entity.Phone,
            ProfileImage = entity.ProfileImage,
            Id = entity.Id
          
        };

        public UserSummary? GetRoleId(int RoleId)
        {
            try
            {
                return _tourContext.Users.Where(p => p.RoleId == RoleId)
                    .Select(SummaryMapper).SingleOrDefault();
                
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return (UserSummary?)Enumerable.Empty<UserSummary>();
            }
        }

        public UserSummary? GetUser(string UserName)
        {
            try
            {
                return _tourContext.Users.Where(p => p.UserName == UserName)
                    .Select(SummaryMapper).SingleOrDefault();

            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return (UserSummary?)Enumerable.Empty<UserSummary>();
            }
        }

        public UserSummary? GetUserıd(int Id)
        {
            try
            {
                return _tourContext.Users.Where(p => p.Id == Id)
                    .Select(SummaryMapper).SingleOrDefault();

            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return (UserSummary?)Enumerable.Empty<UserSummary>();
            }
        }

        public UserDto? GetUses(string UserName)
        {
            try
            {
                return _tourContext.Users.Where(p => p.UserName == UserName)
                    .Select(DtoMapper).SingleOrDefault();

            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return (UserDto?)Enumerable.Empty<UserSummary>();
            }
        }

        public KlinikUser MapEntitys(UserDto model)
        {
            return new KlinikUser()
            {
                IdentityNumber = model.IdentityNumber,               
                BirthDate = model.BirthDate,
                Name = model.Name,
                Surname = model.Surname,
                Phone = model.Phone,
                ProfileImage = model.ProfileImage,
                RoleId= model.RoleId,
                Id = model.Id,
                
                


            };
        }

        public UserSummary MapSummary(UserSummary entity)
        {
            return new UserSummary()
            {
                IdentityNumber = entity.IdentityNumber,
                RoleName=entity.RoleName,
                GenderName = entity.GenderName,
                BirthDate = entity.BirthDate,
                Name = entity.Name,
                Surname = entity.Surname,
                UserName = entity.UserName,
                Phone = entity.Phone,
              
                Id = entity.Id,
               
            };
        }

        public KlinikUser? Photo(int Id, string photo)
        {
           var resim = _tourContext.Users.FirstOrDefault(p=>p.Id == Id );
            resim.ProfileImage =photo;

            _tourContext.SaveChanges();
            return resim;
        }

        protected override KlinikUser MapEntity(UserDto model)
        {
            return new KlinikUser()
            {
                IdentityNumber = model.IdentityNumber,
                Id = model.Id,
                BirthDate = model.BirthDate,
                Name = model.Name,
                Surname = model.Surname,
                Phone = model.Phone,
                ProfileImage = model.ProfileImage,
                RoleId = model.RoleId
                


            };
        }
    }
}
