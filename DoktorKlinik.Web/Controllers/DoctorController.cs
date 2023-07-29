using DoktorKlinik.Business;
using DoktorKlinik.Business.Interface_Service;
using DoktorKlinik.DataAccess.Migrations;
using DoktorKlinik.Dto;
using DoktorKlinik.Summary;
using DoktorKlinik.Web.Components;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Xml.Linq;

namespace DoktorKlinik.Web.Controllers
{
    public class DoctorController : DoktorController
    {
        IAppointmentGet _appointmentGet;
        IPatientInfo _patientInfo;
        IDoctorService _doctor;
        UserMangerSing _user;
        IUserServices _userServices;
        IDoctorComment _doctorComment;
        public DoctorController(IAppointmentGet appointmentGet,
            IPatientInfo patientInfo,
            IDoctorService doctor,
            UserMangerSing user,
            IUserServices userServices,
            IDoctorComment doctorComment)
        {
            _appointmentGet = appointmentGet;
            _patientInfo = patientInfo;
            _doctor = doctor;
            _user = user;
            _userServices = userServices;
            _doctorComment = doctorComment; 
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Doctor()
        {
            var bul = _user.ActiveUser.Id;
            var doktor = _doctor.GetDoctor(bul);
           var randevu = _appointmentGet.GetDoctorSum(doktor.Id);
            
            int sayac =0;
            for (int i = 0; i < randevu.Count(); i++)
            {
                sayac++;
            }
          var yorum =  _doctorComment.GetRandevu(doktor.Id);
            int yorumsayac = 0;
            for (int i = 0; i < yorum.Count(); i++)
            {
                yorumsayac++;
            }
            var aktifRandevu = _appointmentGet.GetDoctor(doktor.Id);
            int aktifsayac = 0;
            for (int i = 0; i < aktifRandevu.Count(); i++)
            {
                aktifsayac++;
            }
            ViewBag.RandevuToplam = sayac;
            ViewBag.YorumToplam = yorumsayac;
            ViewBag.AktifSayac = aktifsayac;
            ViewBag.GecmisSayac = sayac - aktifsayac;
            return View();
        }
        public IActionResult HastaRandevu()
        {
            var bul = _user.ActiveUser.Id;
            var doktor = _doctor.GetDoctor(bul);
            var randevu = _appointmentGet.GetDoctor(doktor.Id);
            return View(randevu);

        }
        public IActionResult HastaBilgi(int Id)
        {
            var Kisi = _appointmentGet.GetById(Id);
            var randevu = _appointmentGet.GetSummaryById(Id);
            ViewBag.AdıSoyAdı = randevu.PatientFulName;
            ViewBag.KisiId = Kisi.PatientId;
            ViewBag.Ids = randevu.Id;
            return View();

        }
        [HttpPost]
        public IActionResult HastaBilgi(PatientInfoDto model)
        {
            var sonuc = _appointmentGet.GetById(model.AppointmentId);

            var deger = _patientInfo.Create(model);
            if (deger.IsSuccess)
            {
               
                _appointmentGet.Duzenle(sonuc.Id);
                return RedirectToAction("HastaRandevu", "Doctor");
            }
            return View();

        }
        [HttpPost]
        public IActionResult GecmisBilgiler(PatientInfoDto model)
        {

            var deger = _patientInfo.GetPatientInfoSummrays(model.PatielId);
            if (deger != null)
            {
                return View(deger);
            }
            return View();

        }
        public IActionResult Profil()
        {
            var doctorId = _user.ActiveUser.Id;
            var bul = _doctor.GetDoctor(doctorId);
            var doctor = _doctor.GetSummaryById(bul.Id);
            var deger = _doctor.MapEntitys(doctor);
            var yorumlar = _doctorComment.GetRandevu(bul.Id);
            ViewBag.Yorumlas = yorumlar;
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
      
          var sonuc =  _userServices.Photo(kullanici.Id,imagePath);
            if (sonuc != null)
            {
                return RedirectToAction("Doctor", "Doctor");
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

    }
}
