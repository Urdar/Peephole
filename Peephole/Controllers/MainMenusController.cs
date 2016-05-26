using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Peephole;

namespace Peephole.Controllers
{
    public class MainMenusController : Controller
    {
        private Entities db = new Entities();

        // GET: MainMenus
        public ActionResult Index()
        {
            return this.RazorView(db.MainMenu.ToList().OrderBy(a => a.Priority));
        }

        // GET: MainMenus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainMenu mainMenu = db.MainMenu.Find(id);
            if (mainMenu == null)
            {
                return HttpNotFound();
            }
            return this.RazorView(mainMenu);
        }

        // GET: MainMenus/Create
        public ActionResult Create()
        {
            return this.RazorView();
        }

        // POST: MainMenus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ShowInMenu,AreaName,LinkText,ParentId,URL,Priority")] MainMenu mainMenu)
        {
            if (ModelState.IsValid)
            {
                db.MainMenu.Add(mainMenu);
                    db.SaveChanges();
                return RedirectToAction("Index");
            }

            return this.RazorView(mainMenu);
        }

        // GET: MainMenus1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainMenu mainMenu = db.MainMenu.Find(id);
            if (mainMenu == null)
            {
                return HttpNotFound();
            }
            return this.RazorView(mainMenu);
        }

        // POST: MainMenus1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ShowInMenu,AreaName,LinkText,ParentId,URL,Priority")] MainMenu mainMenu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mainMenu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return this.RazorView(mainMenu);
        }

        // GET: MainMenus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainMenu mainMenu = db.MainMenu.Find(id);
            if (mainMenu == null)
            {
                return HttpNotFound();
            }
            return this.RazorView(mainMenu);
        }

        public void UpdateOrder(int? id, int? toPosition)
        {
            if (id == null)
            {
           //     return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MainMenu mainMenu = db.MainMenu.Find(id);
            if (mainMenu == null)
            {
             //   return HttpNotFound();
            }
            else
            {
                mainMenu.Priority = toPosition;
                db.SaveChanges();
            }

        }

        // POST: MainMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MainMenu mainMenu = db.MainMenu.Find(id);
            db.MainMenu.Remove(mainMenu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
