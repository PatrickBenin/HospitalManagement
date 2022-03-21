using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Credit()
        {
            return View();
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
