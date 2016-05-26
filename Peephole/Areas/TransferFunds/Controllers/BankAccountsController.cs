using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Peephole;
using Peephole.Areas.TransferFunds.Models;

namespace Peephole.Areas.TransferFunds.Controllers
{
    public class BankAccountsController : Controller
    {
        private Entities db = new Entities();

        // GET: TransferFunds/BankAccounts
        public ActionResult Index()
        {

            if (Session["USER_PID"] == null)
            {
                Response.Redirect("/Areas/Login/Login.aspx");
            }


            int? id = (int)Session["USER_PID"];


            var viewModel = db.BankAccount.Where(o => o.UserID == id).ToList().Join(db.BankAccountType,
                c => c.AccountType,
                cm => cm.Id,
                (c, cm) => new BankAccountModel
                {

                    AccountData = c,
                    AccountType = cm

                }
                );

            return this.RazorView(viewModel);
        }

        // GET: TransferFunds/BankAccounts/Details/5
        public ActionResult Details(long? id)
        {

            if (Session["USER_PID"] == null)
            {
                Response.Redirect("/Areas/Login/Login.aspx");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankAccount = db.BankAccount.Find(id);
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return this.RazorView(bankAccount);
        }

        // GET: TransferFunds/BankAccounts/Create
        public ActionResult Create()
        {
            if (Session["USER_PID"] == null)
            {
                Response.Redirect("/Areas/Login/Login.aspx");
            }

            SelectList selectList = new SelectList(db.BankAccountType, "Id", "Type");
            ViewBag.selectlist = selectList;
            return this.RazorView();
        }

        // POST: TransferFunds/BankAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountNumber,AccountType,UserID,AccountName")] BankAccount bankAccount)
        {
            if (Session["USER_PID"] == null)
            {
                Response.Redirect("/Areas/Login/Login.aspx");
            }


            if (ModelState.IsValid)
            {
                int? id = (int)Session["USER_PID"];
                bankAccount.UserID = (int)id;
                db.BankAccount.Add(bankAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return this.RazorView(bankAccount);
        }

        // GET: TransferFunds/BankAccounts/Edit/5
        public ActionResult Edit(long? id)
        {
            if (Session["USER_PID"] == null)
            {
                Response.Redirect("/Areas/Login/Login.aspx");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankAccount = db.BankAccount.Find(id);
            if (bankAccount == null)
            {
                return HttpNotFound();
            }

            SelectList selectList = new SelectList(db.BankAccountType, "Id", "Type");
            ViewBag.selectlist = selectList;
            return this.RazorView(bankAccount);
        }

        // POST: TransferFunds/BankAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountNumber,AccountType,UserID,AccountName,Balance")] BankAccount bankAccount)
        {
            if (Session["USER_PID"] == null)
            {
                Response.Redirect("/Areas/Login/Login.aspx");
            }

            if (ModelState.IsValid)
            {
                BankAccount CurrentAccount = db.BankAccount.Find(bankAccount.AccountNumber);
                CurrentAccount.AccountType = bankAccount.AccountType;
                CurrentAccount.AccountName = bankAccount.AccountName;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.RazorView(bankAccount);
        }

        // GET: TransferFunds/BankAccounts/Delete/5
        public ActionResult Delete(long? id)
        {
            if (Session["USER_PID"] == null)
            {
                Response.Redirect("/Areas/Login/Login.aspx");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BankAccount bankAccount = db.BankAccount.Find(id);

            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return this.RazorView(bankAccount);
        }

        // POST: TransferFunds/BankAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            if (Session["USER_PID"] == null)
            {
                Response.Redirect("/Areas/Login/Login.aspx");
            }

            BankAccount bankAccount = db.BankAccount.Find(id);
            db.BankAccount.Remove(bankAccount);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {

            if (Session["USER_PID"] == null)
            {
                Response.Redirect("/Areas/Login/Login.aspx");
            }

            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
