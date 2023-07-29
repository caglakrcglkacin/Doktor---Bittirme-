using DoktorKlinik.Business.Interface_Service;
using DoktorKlinik.Domain.User;
using DoktorKlinik.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DoktorKlinik.Web.Components
{
    public class PanelUserInfoViewComponent : ViewComponent
    {
        UserManager<KlinikUser> _userManager;
        IRoleService _role;
        IUserServices _userServices;
        public PanelUserInfoViewComponent(UserManager<KlinikUser> userManager,
            IRoleService role,
            IUserServices userServices)
        {
            _userManager = userManager;
            _role = role;
            _userServices = userServices;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var info = new PanelUserInfoViewModel();
            var userInfo = await _userManager.GetUserAsync(HttpContext.User);
            var kısı = _userServices.GetById(userInfo.Id);
            var role = _role.GetSummaryById(userInfo.RoleId);
            info.Role = role.Name;
            info.Name = userInfo.Name;
            info.Surname = userInfo.Surname;
            info.Id = userInfo.Id;
            info.ProfileImage= kısı.ProfileImage;
            return View(info);
        }
    }
}
