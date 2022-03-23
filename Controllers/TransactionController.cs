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

         


        public IActionResult Debit()
        {
            var listdebit = _transRepo.GetDebitDetails();
            return View(listdebit.Result);
        }


        public IActionResult Exchange()
        {
            return View();
        }

        public IActionResult Loan()
        {
            return View();
        }
    }
}
