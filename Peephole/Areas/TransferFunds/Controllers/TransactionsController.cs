using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Peephole;
using System.Diagnostics;

namespace Peephole.Areas.TransferFunds.Controllers
{
    public class TransactionsController : Controller
    {
        private Entities db = new Entities();

        // GET: TransferFunds/Transactions
        public ActionResult Index()
        {

            if (Session["USER_PID"] == null)
            {
                Response.Redirect("/Areas/Login/Login.aspx");
            }


            return this.RazorView(db.Transaction.ToList());
        }

        // GET: TransferFunds/Transactions/Details/5
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
            Transaction transaction = db.Transaction.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return this.RazorView(transaction);
        }

        // GET: TransferFunds/Transactions/Create
        public ActionResult Create()
        {


            if (Session["USER_PID"] == null)
            {
                Response.Redirect("/Areas/Login/Login.aspx");
            }


            int? id = (int)Session["USER_PID"];

            //// Count how many accounts user has
            //var count = db.BankAccount.Where(o => o.UserID == iden).Count();

            //if (count > 0)
            //{
            //    // User has account, proceed
            //    SelectList selectList = new SelectList(db.BankAccount.Where(o => o.UserID == iden), "AccountNumber", "AccountNumber");
            //    ViewBag.FromAccount = selectList;
            //}
            //else {
            //    // No accounts, redirect to create account
            //    Response.Redirect("/TransferFunds/BankAccounts/Create");
            //}


            SelectList selectList = new SelectList(db.BankAccount.Where(o => o.UserID == id), "AccountNumber", "AccountNumber");
            ViewBag.FromAccount = selectList;

            return this.RazorView();
        }

        // POST: TransferFunds/Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Amount,FromAccount,ToAccount,Timestamp")] Transaction transaction)
        {
            if (Session["USER_PID"] == null)
            {
                Response.Redirect("/Areas/Login/Login.aspx");
            }

            BankAccount SourceAccount = db.BankAccount.Find(transaction.FromAccount);

            if (SourceAccount.Balance < transaction.Amount)
            {
        
                TempData["LowBalance"] = true;
            }

            if (transaction.Amount <= 0)
            {
          
                TempData["InvalidAmount"] = true;
            }

            if ((TempData["LowBalance"] != null) || (TempData["InvalidAmount"] != null))
            {
                // Error
                //return RedirectToAction("Create");
         
            } else {

                // Check if sufficient balance


                if (ModelState.IsValid)
                {

                    DateTime now = DateTime.Now;
                    transaction.Timestamp = now;
                    db.Transaction.Add(transaction);
                    db.SaveChanges();

                    // Update source account
                    //BankAccount SourceAccount = db.BankAccount.Find(transaction.FromAccount);
                    SourceAccount.Balance = SourceAccount.Balance - (decimal)transaction.Amount;
                    db.SaveChanges();

                    // Update target account
                    BankAccount TargetAccount = db.BankAccount.Find(transaction.ToAccount);
                    TargetAccount.Balance = TargetAccount.Balance + (decimal)transaction.Amount;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                    // return this.RazorView(transaction);

                }
            }



           

            return RedirectToAction("Create");
        }

        // GET: TransferFunds/Transactions/Edit/5
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
            Transaction transaction = db.Transaction.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return this.RazorView(transaction);
        }

        public Boolean ValidBalance(Decimal? amount, long account)
        {

            BankAccount SourceAccount = db.BankAccount.Find(account);

            if (SourceAccount.Balance < amount)
            {
                ViewBag.LowBalance = true;

            }
            if (amount <= 0)
            {
                ViewBag.InvalidAmount = true;
            }

            if ((ViewBag.LowBalance != null) || (ViewBag.InvalidAmount != null))
            {
                // Error
                return false;
            }

            return true;

        }

        // POST: TransferFunds/Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Amount,FromAccount,ToAccount, Timestamp")] Transaction transaction)
        {
            if (Session["USER_PID"] == null)
            {
                Response.Redirect("/Areas/Login/Login.aspx");
            }

            transaction.Timestamp = DateTime.Now;

            Debug.WriteLine("My debug string here " + DateTime.Now);

            if (ModelState.IsValid)
            {
                // Check if available balance > amount



                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();

                // Update balances

                return RedirectToAction("Index");
            }
            return this.RazorView(transaction);
        }

        // GET: TransferFunds/Transactions/Delete/5
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
            Transaction transaction = db.Transaction.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return this.RazorView(transaction);
        }

        // POST: TransferFunds/Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {

            Transaction transaction = db.Transaction.Find(id);
            db.Transaction.Remove(transaction);
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
