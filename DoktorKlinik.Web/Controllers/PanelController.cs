using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DoktorKlinik.Web.Controllers
{
    [Authorize(Roles = "Hasta")]
    public class PanelController : Controller
    {
      
       
        [Authorize]
        public class AuthorizedController : Controller
        {

        }
    }
}
