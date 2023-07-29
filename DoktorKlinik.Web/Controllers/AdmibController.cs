using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoktorKlinik.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdmibController : Controller
    {
        [Authorize]
        public class AdminController:Controller
        {

        }
    }
}
