using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Peephole;

namespace Peephole.Areas.CustomerInfo.Controllers
{
    public class DefaultController : Controller
    {
        private Entities db = new Entities();

        // GET: CustomerInfo/Default
        public ActionResult Index()
        {
            return this.RazorView(db.Users.ToList());
        }

        // GET: CustomerInfo/Default/Details/5
        public ActionResult Details()
        {

            if (Session["USER_PID"] == null)
            {
                Response.Redirect("/Areas/Login/Login.aspx");
            }

            int? id = (int)Session["USER_PID"];

            //ViewBag.sessionID = Session.SessionID.ToString();
                   




            //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);



            Users users = db.Users.Find(id);

            if (users == null)
            {
                return HttpNotFound();
            }
            return this.RazorView(users);
        }

        // GET: CustomerInfo/Default/Create
        public ActionResult Create()
        {
            if (Session["USER_PID"] == null)
            {
                Response.Redirect("/Areas/Login/Login.aspx");
            }

            
            return this.RazorView();
        }

        // POST: CustomerInfo/Default/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Firstname,Lastname,Password,Email")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return this.RazorView(users);
        }

        // GET: CustomerInfo/Default/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return this.RazorView(users);
        }

        // POST: CustomerInfo/Default/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Firstname,Lastname,Password,Email")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.RazorView(users);
        }

        // GET: CustomerInfo/Default/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return this.RazorView(users);
        }

        // POST: CustomerInfo/Default/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users users = db.Users.Find(id);
            db.Users.Remove(users);
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
