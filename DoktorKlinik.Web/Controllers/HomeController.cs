using DoktorKlinik.Business;
using DoktorKlinik.Business.Interface_Service;
using DoktorKlinik.DataAccess.Migrations;
using DoktorKlinik.Domain.User;
using DoktorKlinik.Dto;
using DoktorKlinik.Web.Models;
using DoktorKlinik.Web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace DoktorKlinik.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IRoleService _roleService;
        IUserServices _userService;
        SignInManager<KlinikUser> _signInManager;
        IUserStore<KlinikUser> _userStore;
        IRoleStore<KlinikRole> _roleStore;
        UserMangerSing _userManager;
        IPatientService _patient;
        IDoctorService _doctorService;


        public HomeController(ILogger<HomeController> logger,
            IRoleService roleService,
            IUserServices userServices,
           SignInManager<KlinikUser> signInManager,
           IUserStore<KlinikUser> userStore,
           IRoleStore<KlinikRole> roleStore,
           UserMangerSing userManager,
           IPatientService patient,
           IDoctorService doctorService
           )
        {
            _roleService = roleService;
            _userService = userServices;
            _signInManager = signInManager;
            _roleStore = roleStore;
            _userStore = userStore;
            _userManager = userManager;
            _logger = logger;
            _patient = patient;
            _doctorService = doctorService;

        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Doktorlar()
        {
           var doktor = _doctorService.GetSummary();
            
           
            return View(doktor);
        }
        public async Task<IActionResult> HastaLogin()
        {
            var kayit = _userService.GetUser("Admin");
            if (kayit == null)
            {
                var user = new UserDto();
                user.BirthDate =DateTime.Now;
                user.Phone = "05455225754";
                user.IdentityNumber = "11111111111";
                user.GenderId = 3;
                user.Name = "Admin";
                user.Surname = "Admin";
                user.UserName = "Admin";
                user.ProfileImage = " ";
                var kisi = _userService.MapEntitys(user);
                await _userManager.SetEmailAsync(kisi, "admin@mutluyuz.com");
                var result = await _userStore.CreateAsync(kisi, new CancellationToken());
                if (result.Succeeded)
                {
                    await _userManager.SetUserNameAsync(kisi, "Admin");

                    await _userManager.AddPasswordAsync(kisi, "Cagla1905.");
                    var sonuc = await _userManager.AddToRoleAsync(kisi, "Admin");
                }
                return View();
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> HastaLogin(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = await _userManager.FindByNameAsync(model.KullaniciAdı);
            if (user == null)
                return View(model);
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RembemberMe, false);


            var bul = _userService.GetUses(user.UserName);

            var role = _roleService.GetSummaryById(bul.RoleId);
            if (role.Name == "Hasta")
            {
                if (result.Succeeded)
                {
                    return RedirectToAction("Patients", "Patient");
                }
            }
            if (role.Name == "Doktor")
            {
                if (result.Succeeded)
                {
                    return RedirectToAction("Doctor", "Doctor");
                }
            }
            if (role.Name == "Admin")
            {
                if (result.Succeeded)
                {
                    return RedirectToAction("EmployeeAdd", "Employee");
                }
            }
            ViewBag.Hata = "Giriş Yapamadınız. Kullanıcı Adı Veya Şifre Yanlıştır.";
            return View(model);
        }
        [Authorize]
        [HttpGet]

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home",new {Area =" "}); // Çıkış yapıldıktan sonra yönlendirileceği sayfanın adresi.
        }

        public IActionResult HastaRegister()
        {
            var gender = new UserDto();
            gender.GendersList = Enum.GetValues(typeof(Genders)).Cast<Genders>().Select(v => new SelectListItem()
            {
                Text = v.ToString(),
                Value = Convert.ToString((int)v)
            }).ToList();
            return View(gender);
        }
        [HttpPost]
        public async Task<IActionResult> HastaRegister(UserDto model)
        {
            //var hastaUser = _userService.GetAll();
            var user = _userService.MapEntitys(model);
            user.ProfileImage = "/dist/img/avatar4.png";
            await _userManager.SetEmailAsync(user, model.Email);
                var result = await _userStore.CreateAsync(user, new CancellationToken());
                if (result.Succeeded)
                {
                    await _userManager.SetUserNameAsync(user, model.UserName);
                if (model.NewPassword != model.NewPasswordAgin)
                {
                    ViewBag.Hata = "Şifreler Uyuşmadı.";
                    return View();
                }
                    await _userManager.AddPasswordAsync(user, model.NewPassword);
                      var roleStore = _roleService.GetSummaryById(3);
                      var role = roleStore.Name;
                      user.RoleId = roleStore.Id;
                    var sonuc = await _userManager.AddToRoleAsync(user,role);
              
                    var deger = new PatientDto();
                    deger.RoleId = roleStore.Id;
                    deger.KlinikId = user.Id;
                    _patient.Create(deger);
                
                return RedirectToAction("HastaLogin", "Home");
                }
            
            return View(model);
        }
        public IActionResult HastaPasswordChange()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> HastaPasswordChange(UserDto model)
        {
            
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}