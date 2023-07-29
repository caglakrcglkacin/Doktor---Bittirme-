using Microsoft.AspNetCore.Mvc;

namespace DoktorKlinik.Web.Controllers
{
    public class GirisController : PanelController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
