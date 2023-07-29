using DoktorKlinik.Business;
using DoktorKlinik.Business.Interface_Service;
using DoktorKlinik.Business.Service;
using DoktorKlinik.Domain.User;
using DoktorKlinik.Dto;
using DoktorKlinik.Summary;
using DoktorKlinik.Web.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoktorKlinik.Web.Controllers
{
    public class PatientController : Controller
    {
        IAppointment _appointment;
        IPartService _partService;
        UserMangerSing _user;
        IAppointmentGet _appointmentGet;
        IPatientService _patient;
        IDoctorService _doctorService;
        IUserServices _userServices;
        IDoctorComment _doctorComment;
        public PatientController(
            IAppointment appointment, IPartService partService,
            UserMangerSing user, IAppointmentGet appointmentGet, 
            IPatientService patient, IDoctorService doctorService, 
            IUserServices userServices, IDoctorComment doctorComment)
        {
            _appointment = appointment;
            _partService = partService;
            _user = user;
            _appointmentGet = appointmentGet;
            _patient = patient;
            _doctorService = doctorService;
            _userServices = userServices;
           _doctorComment = doctorComment;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult Patients()
        {
            var bul = _patient.GetUsertId(_user.ActiveUser.Id);
            var model = new AppointmentGetDto();
            model.PatientId = bul.Id;
            ViewBag.Kisi = bul.Name + " " + bul.Surname;
           var randevu = _appointmentGet.GetSummaryId(model.PatientId);

            return View(randevu);
        }
      
        public IActionResult BolumRandevu()
        {
            var bolum = _partService.GetAll();
            ViewBag.Bolum = new SelectList(bolum, "Id", "Name");
            ViewBag.Kisi = _user.ActiveUser.Id;
            return View();
        }
        [HttpPost]
        public IActionResult BolumRandevu(AppointmentGetDto model)
        {
            var bul = _patient.GetUsertId(model.UserId);
           var ıd = _appointment.GetById(model.AppointmentId);
            model.PatientId = bul.Id;
           var deger = _appointmentGet.Create(model);
            var degıs = new AppointmentDto();
            degıs.Id = ıd.Id;
            degıs.DoctorId = ıd.DoctorId;
            degıs.DateOnly = ıd.DateOnly;
            degıs.TimeOnly = ıd.TimeOnly;
            degıs.PartId = ıd.PartId;
            degıs.RandevuAlindi = 1;
            _appointment.Update(degıs);
            if (deger.IsSuccess)
            {
                return RedirectToAction("Patients", "Patient");
            }
            return View();
        }

        public IActionResult DoktorRandevu()
        {
            var doctors = _doctorService.GetAll();
            ViewBag.Doctor = new SelectList(doctors, "Id", "Name");
            ViewBag.Kisi = _user.ActiveUser.Id;
            return View();
        }
        [HttpPost]
        public IActionResult DoktorRandevu(AppointmentGetDto model)
        {
            var bul = _patient.GetUsertId(model.UserId);
            var ıd = _appointment.GetById(model.AppointmentId);
            model.PatientId = bul.Id;
            var deger = _appointmentGet.Create(model);
           
            if (deger.IsSuccess)
            {
                var degıs = new AppointmentDto();
                degıs.Id = ıd.Id;
                degıs.DoctorId = ıd.DoctorId;
                degıs.DateOnly = ıd.DateOnly;
                degıs.TimeOnly = ıd.TimeOnly;
                degıs.PartId = ıd.PartId;
                degıs.RandevuAlindi = 1;
                _appointment.Update(degıs);
                return RedirectToAction("Patients", "Patient");
            }
            return View();
        }
        public IActionResult RandevuGetir(int partId)
        {
          var deger =  _appointment.GetDefintId(partId);

            return Json(deger);
        }

        public IActionResult DoktorRandevuGetir(int DoktorId)
        {
            var deger = _appointment.GetDoctorId(DoktorId);

            return Json(deger);
        }
        public IActionResult RandevySil(int id)
        {
            var ıds= _appointmentGet.GetById(id);
            var ıd = _appointment.GetById(ıds.AppointmentId);
           
            var deger = _appointmentGet.Delete(id);
            if (deger.IsSuccess)
            {

                var degıs = new AppointmentDto();
                degıs.Id = ıd.Id;
                degıs.DoctorId = ıd.DoctorId;
                degıs.DateOnly = ıd.DateOnly;
                degıs.TimeOnly = ıd.TimeOnly;
                degıs.PartId = ıd.PartId;
                degıs.RandevuAlindi = 0;
                _appointment.Update(ıd);
            }

            return Json(deger);
        }
        public IActionResult Profil()
        {
            var doctorId = _user.ActiveUser.Id;
            var bul = _patient.GetUsertId(doctorId);
            var doctor = _patient.GetSummaryById(bul.Id);
            var deger = _patient.MapEntitys(doctor);
            return View(deger);
        }
        public IActionResult ProfilDuzenle()
        {
            var doctorId = _user.ActiveUser.Id;
            var bul = _userServices.GetSummaryById(doctorId);
            var deger = _userServices.MapSummary(bul); ;
            return View(deger);
        }
        [HttpPost]
        public IActionResult ProfilDuzenle(UserSummary model)
        {
            var kullanici = _userServices.GetById(model.Id);
            string imagePath = model.ProfileImage;
            if (Request.Form.Files.Count > 0)
            {
                imagePath = ProfilUpdate.Photo(Request.Form.Files[0], "Profil");
            }

            var sonuc = _userServices.Photo(kullanici.Id, imagePath);
            if (sonuc != null)
            {
                return RedirectToAction("Patients", "Patient");
            }
            return View(sonuc);
        }
        public IActionResult SifreDegistir()
        {
            var doctorId = _user.ActiveUser.Id;
            var bul = _userServices.GetSummaryById(doctorId);
            var deger = _userServices.MapSummary(bul);

            return View(deger);
        }
        [HttpPost]
        public async Task<IActionResult> SifreDegistir(UserSummary model)
        {

            var bul = _userServices.GetById(model.Id);
            if (bul.Id == model.Id)
            {

                var pass = await _user.CheckPasswordAsync(_user.ActiveUser, model.OldPassword);
                if (!pass)
                {
                    ModelState.AddModelError("oldPassword", "Şifreler Hatalı Girdiniz");
                    return RedirectToAction("HastaLogin");
                }
                var result = await _user.ChangePasswordAsync(_user.ActiveUser, model.OldPassword, model.NewPassword);
                return RedirectToAction("Doctor", "Doctor");
            }
            return View();
        }
        public IActionResult DoktorYorum()
        {
          var gecmis =  _appointmentGet.GetSummaryRandevu();
            return View(gecmis);
        }
        
        public IActionResult Yorumla(int Id)
        {
            var gecmis = _appointmentGet.GetById(Id);
            ViewBag.RandevuId = gecmis.Id;
            var doktor = _appointment.GetSummaryById(gecmis.AppointmentId);
            ViewBag.Adı = doktor.DoctorName;
            return View();
        }
        [HttpPost]
        public IActionResult Yorumla(DoctorCommentDto model)
        {
          var sonuc =  _doctorComment.Create(model);
            if (sonuc.IsSuccess)
            {
                _appointmentGet.Yorum(model.AppointmentId);
                return RedirectToAction("Patients", "Patient");
            }
            return View();
        }
    }
}

