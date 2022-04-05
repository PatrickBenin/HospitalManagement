using AMS.Models;
using AMS.Repository_Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Controllers
{
    public class TransactionController : Controller
    {
        public ITransactionRepository _transRepo;
        public IAccountRepository _accRepo;
        public TransactionController(ITransactionRepository transRepo, IAccountRepository accRepo)
        {
            _transRepo = transRepo;
            _accRepo = accRepo;
        }

    

        public IActionResult Credit()
        {
            var listcurrencies = _accRepo.GetCurrencies();
            ViewBag.CurrencySymbol = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(listcurrencies.Result, "CurrencyId", "CurrencySymbol");
            var listcredit = _transRepo.GetCreditDetails();
            return View(listcredit.Result);
        }

         public IActionResult SaveCredit(CreditDebitModel creditDebit)
        {
            var saveCredit = _transRepo.SaveCredit(creditDebit);
            return Json(saveCredit);
        }
        public IActionResult SaveDebit(CreditDebitModel creditDebit)
        {
            var saveDebit = _transRepo.SaveDebit(creditDebit);
            return Json(saveDebit);
        }

        public IActionResult Debit()
        {
            var listcurrencies = _accRepo.GetCurrencies();
            ViewBag.CurrencySymbol = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(listcurrencies.Result, "CurrencyId", "CurrencySymbol");

            var listdebit = _transRepo.GetDebitDetails();
            return View(listdebit.Result);
        }


        public IActionResult Exchange()
        {
            return View();
        }

        public IActionResult Loan()
        {
            var listcurrencies = _accRepo.GetCurrencies();
            ViewBag.CurrencySymbol = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(listcurrencies.Result, "CurrencyId", "CurrencySymbol");
            var listloans = _transRepo.GetLoanDetails();
            return View(listloans.Result);
        }

        [HttpPost]
        public JsonResult AutocompletAccountCode(string Prefix)
        {

            var listAccCode = _transRepo.GetAccountCode(Prefix);


            return Json(listAccCode);
        }
    }
}
