using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyEvernote.BusinessLayer;
using MyEverNote.BusinessLayer;
using MyEverNote.BusinessLayer.Results;
using MyEverNote.Entities;
using WebApplication1.Filters;

namespace WebApplication1.Views.Category
{
    [Auth]
    [AuthAdmin]
    public class EverNoteUserController : Controller
    {
        private EvernoteUserManager evernoteUserManager = new EvernoteUserManager();
        
        public ActionResult Index()
        {
            return View(evernoteUserManager.List());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EverNoteUser evernoteUser = evernoteUserManager.Find(x => x.Id == id.Value);
            if (evernoteUser == null)
            {
                return HttpNotFound();
            }
            return View(evernoteUser);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EverNoteUser evernoteUser)
        {

            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");

            if (ModelState.IsValid)
            {
                BusinessLayetResult<EverNoteUser> res = evernoteUserManager.Insert(evernoteUser);
                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(evernoteUser);
                }
                
                return RedirectToAction("Index");
            }

            return View(evernoteUser);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EverNoteUser evernoteUser = evernoteUserManager.Find(x => x.Id == id.Value);
            if (evernoteUser == null)
            {
                return HttpNotFound();
            }
            return View(evernoteUser);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EverNoteUser evernoteUser)
        {

            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");

            if (ModelState.IsValid)
            {
                BusinessLayetResult<EverNoteUser> res = evernoteUserManager.Update(evernoteUser);
                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(evernoteUser);
                }
                return RedirectToAction("Index");
            }
            return View(evernoteUser);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EverNoteUser evernoteUser = evernoteUserManager.Find(x => x.Id == id.Value);
            if (evernoteUser == null)
            {
                return HttpNotFound();
            }
            return View(evernoteUser);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EverNoteUser everNoteUser = evernoteUserManager.Find(x => x.Id == id);
            evernoteUserManager.Delete(everNoteUser);
            return RedirectToAction("Index");
        }

       
    }
}
