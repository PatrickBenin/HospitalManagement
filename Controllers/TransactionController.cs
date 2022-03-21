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
        public TransactionController(ITransactionRepository transRepo)
        {
            _transRepo = transRepo;
        }

        public IActionResult Credit()
        {
            var listcredit = _transRepo.GetCreditDetails();
            return View(listcredit);
        }

        public IActionResult Debit()
        {
            return View();
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
