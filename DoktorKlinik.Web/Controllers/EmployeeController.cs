using DoktorKlinik.Business.Interface_Service;
using DoktorKlinik.Domain.Country;
using DoktorKlinik.Domain.User;
using DoktorKlinik.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static DoktorKlinik.Web.Controllers.PanelController;

namespace DoktorKlinik.Web.Controllers
{
    public class EmployeeController : AdmibController
    {
        IRoleService _roleService;
        IUserServices _userService;
        SignInManager<KlinikUser> _signInManager;
        IUserStore<KlinikUser> _userStore;
        IRoleStore<KlinikRole> _roleStore;
        UserManager<KlinikUser> _userManager;
        IPatientService _patient;
        IDoctorService _doctorService;
        IPartService _partService;
        IAppointment _appointment;
        public EmployeeController(IRoleService roleService,
            IUserServices userServices,
           SignInManager<KlinikUser> signInManager,
           IUserStore<KlinikUser> userStore,
           IRoleStore<KlinikRole> roleStore,
           UserManager<KlinikUser> userManager,
           IPatientService patient,
           IDoctorService doctorService,
           IPartService partService,
           IAppointment appointment)
        {
            _roleService = roleService;
            _userService = userServices;
            _signInManager = signInManager;
            _roleStore = roleStore;
            _userStore = userStore;
            _userManager = userManager;
            _patient = patient;
            _doctorService = doctorService;
            _partService = partService;
            _appointment = appointment;
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult EmployeeAdd()
        {

            var gender = new UserDto();
            gender.GendersList = Enum.GetValues(typeof(Genders)).Cast<Genders>().Select(v => new SelectListItem()
            {
                Text = v.ToString(),
                Value = Convert.ToString((int)v)
            }).ToList();
            var bolum = _partService.GetAll();
            ViewBag.Bolum = new SelectList(bolum, "Id", "Name");
            var rol = _roleService.GetAll();
            ViewBag.Employee = new SelectList(rol, "Id", "Name");
            return View(gender);
        }
        [HttpPost]
        public async Task<IActionResult> EmployeeAdd(UserDto model)
        {
           
                
          var user =  _userService.MapEntitys(model);
            user.ProfileImage = "/dist/img/avatar4.png";
            await _userManager.SetEmailAsync(user,model.Email);
            var result = await _userStore.CreateAsync(user,new CancellationToken());
            if (result.Succeeded)
            {
                await _userManager.SetUserNameAsync(user,model.UserName);
                await _userManager.AddPasswordAsync(user,model.NewPassword);
                var roleStore = _roleService.GetSummaryById(model.RoleId);
                var role = roleStore.Name;
                var sonuc = await _userManager.AddToRoleAsync(user,role);
               
                if (role == "Hasta")
                {
                    var deger = new PatientDto();

                    deger.KlinikId = user.Id;
                    deger.RoleId = model.RoleId;                    
                    _patient.Create(deger);
                }
                if (role == "Doktor")
                {
                    var deger = new DoctorDto();
                    deger.RoleId = model.RoleId;
                    deger.BolumId = model.BolumId;
                    deger.UserId = user.Id;
                
                    _doctorService.Create(deger);
                }
                return RedirectToAction("Home", "Employee");
            }              

            
            return View(model);
        }
        public IActionResult RoleAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RoleAdd(RoleDto model)
        {
            
           var role = _roleService.Create(model);
            if (role.IsSuccess)
            {
                return RedirectToAction("Home", "Employee");
            }
            return View();
        }
        public IActionResult BolumAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BolumAdd(PartDto model)
        {
           var part = _partService.Create(model);
            if (part.IsSuccess)
            {
                return RedirectToAction("Home", "Employee");
            }
            return View();
        }
        public IActionResult RandevuOlustur()
        {
            var bolum = _partService.GetAll();
            ViewBag.Bolum = new SelectList(bolum, "Id", "Name");
            var doctor = _doctorService.GetSummary();
            ViewBag.Doctor = new SelectList(doctor, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult RandevuOlustur(AppointmentDto model)
        {
            var randevukaydet = _appointment.GetAll();
            var saat = randevukaydet.Where(x => x.DateOnly == model.DateOnly 
            && x.TimeOnly == model.TimeOnly && x.DoctorId == model.DoctorId).SingleOrDefault();
            if (saat == null)
            {
                if (model.DateOnly > DateTime.Now)
                {
                    var randevu = _appointment.Create(model);
                    if (randevu.IsSuccess)
                    {
                        return RedirectToAction("Home", "Employee");
                    }
                }
            }
            ViewBag.ErrorMessage = "Kaydetme İşlemi Tamamlanmadı";
            return View(model);
        }
        public IActionResult GetDoctorId(int PartId)
        {
           var doktor = _doctorService.GetDefintId(PartId);
            return Json(doktor);
        }
    }
}
