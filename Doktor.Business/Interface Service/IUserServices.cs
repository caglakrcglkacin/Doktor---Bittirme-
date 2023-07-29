using DoktorKlinik.Business.Service_Base;
using DoktorKlinik.Bussiness;
using DoktorKlinik.Domain.Entity;
using DoktorKlinik.Domain.User;
using DoktorKlinik.Dto;
using DoktorKlinik.Summary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Business.Interface_Service
{
    public interface IUserServices:IBaseService<UserDto,UserSummary>
    {
        KlinikUser? Photo(int Id,string photo);
        UserSummary? GetRoleId(int RoleId);
        UserSummary? GetUser(string UserName);
        UserSummary? GetUserıd(int Id);
        UserDto? GetUses(string UserName);
        
        public abstract KlinikUser MapEntitys(UserDto model);
        public abstract UserSummary MapSummary(UserSummary entity);
    }
}
