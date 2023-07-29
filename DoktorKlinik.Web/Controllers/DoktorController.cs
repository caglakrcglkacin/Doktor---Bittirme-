using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DoktorKlinik.Web.Controllers
{
    [Authorize(Roles = "Doktor")]
    public class DoktorController : Controller
    {
        [Authorize]
        public class AuthorizedController : Controller
        {

        }
    }
}
