using MyEvernote.BusinessLayer;
using MyEverNote.BusinessLayer;
using MyEverNote.BusinessLayer.Results;
using MyEverNote.Entities;
using MyEverNote.Entities.Messages;
using MyEverNote.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Filters;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private NoteManager noteManager = new NoteManager();
        private CategoryManager categoryManager = new CategoryManager();
        private EvernoteUserManager evernoteUserManager = new EvernoteUserManager();

        public ActionResult Index()
        {
            return View(noteManager.ListQueryable().Where(x=> x.IsDraft==false).OrderByDescending(x => x.ModifiedOn).ToList());
        }
        public ActionResult ByCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<Note> notes = noteManager.ListQueryable().Where(
                x => x.IsDraft == false && x.CategoryId == id).OrderByDescending(
                x => x.ModifiedOn).ToList();
            return View("Index", notes);
        }
        public ActionResult MostLiked()
        {
           
            return View("Index", noteManager.ListQueryable().OrderByDescending(x => x.LikeCount).ToList());

        }
        public ActionResult About()
        {
            return View();
        }
        [Auth]
        public ActionResult ShowProfile()
        {
            //EverNoteUser currentUser = Session["login"] as EverNoteUser;
           
            BusinessLayetResult<EverNoteUser> res = evernoteUserManager.GetUserById(CurrentSession.User.Id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel errorNotifyObj = new ErrorViewModel()
                {
                    Title = "Hata Oluştu",
                    Items = res.Errors
                };

                return View("Error", errorNotifyObj);
            }
            return View(res.Result);
        }
        [Auth]
        public ActionResult EditProfile()
        {
            
            
            BusinessLayetResult<EverNoteUser> res = evernoteUserManager.GetUserById(CurrentSession.User.Id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel errorNotifyObj = new ErrorViewModel()
                {
                    Title = "Hata Oluştu",
                    Items = res.Errors
                };

                return View("Error", errorNotifyObj);
            }
            return View(res.Result);
        }
        [Auth]
        [HttpPost]
        public ActionResult EditProfile(EverNoteUser model, HttpPostedFileBase ProfileImage)
        {
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                if (ProfileImage != null &&
            (
            ProfileImage.ContentType == "image/jpeg" ||
            ProfileImage.ContentType == "image/jpg" ||
            ProfileImage.ContentType == "image/png"))

                {
                    string filename = $"user_{model.Id}.{ProfileImage.ContentType.Split('/')[1]}";
                    ProfileImage.SaveAs(Server.MapPath($"~/images/{filename}"));
                    model.ProfileImageFilename = filename;

                }
                
                BusinessLayetResult<EverNoteUser> res = evernoteUserManager.UpdateProfile(model);
                if (res.Errors.Count > 0)
                {
                    ErrorViewModel errorNotifyObj = new ErrorViewModel()
                    {
                        Items = res.Errors,
                        Title = "Profil güncellenemedi",
                        RedirectingUrl = "/Home/EditProfile",

                    };
                    return View("Error", errorNotifyObj);
                }

                CurrentSession.Set<EverNoteUser>("login", res.Result);
                return RedirectToAction("ShowProfile");
            
        }

         

          return View(model);
    }
        [Auth]
        public ActionResult DeleteProfile()
        {
            
            
            BusinessLayetResult<EverNoteUser> res = evernoteUserManager.RemoveUserById(CurrentSession.User.Id);

            if (res.Errors.Count > 0)
            {
                ErrorViewModel errorNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Profil Silinemedi.",
                    RedirectingUrl = "/Home/ShowProfile"
                };

                return View("Error", errorNotifyObj);
            }

            Session.Clear();
            return RedirectToAction("Index");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                BusinessLayetResult<EverNoteUser> res = evernoteUserManager.LoginUser(model);
                if (res.Errors.Count > 0)
                {
                    foreach (var item in res.Errors)
                    {

                        if (res.Errors.Find(x => x.Code == ErrorMessageCode.UserIsNotActive) != null)
                        {
                            ViewBag.SetLink = "E-posta Gönder";
                        }
                        res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    }

                    return View(model);
                }
                CurrentSession.Set<EverNoteUser>("login", res.Result);
                return RedirectToAction("Index");
            }



            // yönlendirme
            //sessiona kullanıcı bilgi saklama
            return View();

        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {

               
                BusinessLayetResult<EverNoteUser> res = evernoteUserManager.RegisterUser(model);
                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(model);
                }

                OkViewModel notifyObj = new OkViewModel()
                {
                    Title = "kayit basarili",
                    RedirectingUrl = "/Home/Login",
                    
                };
                notifyObj.Items.Add("Lütfen eposta adresinize gönderdiğimiz aktivasyon linkine tıklayarak hesabınızı aktive edin.");

                return View("Ok", notifyObj); 
            }
            return View(model);

        }
        //kullanıcı username kontrol
        //kullanıcı eposta kontrol
        //kayit islemi
        //aktivasyon eposta gönderimi
        public ActionResult UserActivate(Guid id)
        {

           
            BusinessLayetResult<EverNoteUser> res = evernoteUserManager.ActivateUser(id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel errorNotifyObj = new ErrorViewModel()
                {
                    Title = "Geçersiz İşlem",
                    Items = res.Errors
                };

                return View("Error", errorNotifyObj);
            }

            OkViewModel okNotifyObj = new OkViewModel()
            {
                Title = "Hesap Aktifleştirildi",
                RedirectingUrl = "/Home/Login"
            };

            okNotifyObj.Items.Add("Hesabınız aktifleştirildi. Artık not paylaşabilir ve beğenme yapabilirsiniz.");
            return View("Ok", okNotifyObj);

        }
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}