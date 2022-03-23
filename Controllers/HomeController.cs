using AMS.Models;
using AMS.Repository_Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Controllers
{
    public class HomeController : Controller
    {
        public IAccountRepository _accRepo { get; set; }
        public HomeController(IAccountRepository accRepo)
        {
            _accRepo = accRepo;
        }
        public IActionResult Index()
        {
            var listaccounts = _accRepo.GetAccountDetails();
            var listaccountsType = _accRepo.GetAccountTypes();
            ViewBag.AccountType= new SelectList(listaccountsType.Result, "AccountType", "AccountType");
            var listcurrencies = _accRepo.GetCurrencies();
            ViewBag.CurrencySymbol = new SelectList(listcurrencies.Result, "CurrencyId", "CurrencySymbol");
            return View(listaccounts.Result.ToList());
        }
        public IActionResult Currencies()
        {
            var listcurrencies = _accRepo.GetCurrencies();
            ViewBag.CurrencySymbol = new SelectList(listcurrencies.Result, "CurrencyId", "CurrencySymbol");
            ViewBag.CurrenciesType = new SelectList(listcurrencies.Result, "CurrencyId", "CurrencyType");
            return View(listcurrencies.Result.ToList());
        }

        public IActionResult GetCurrencyById(int? Id)
        {
            var listcurrencies = _accRepo.GetCurrencies();
            var Selectedcurrencies = listcurrencies.Result.Where(s => s.CurrencyId == Id);
            ViewBag.Currencies = new SelectList(listcurrencies.Result, "CurrencyId", "CurrencySymbol");
            return Json(Selectedcurrencies);
        }

        public IActionResult GetAccountById(int id)
        {
            AccountModel AccountbyDetCode = _accRepo.GetAccountDetailbyCode(id).Result;
             
            return Json(AccountbyDetCode);
        }

        

        [HttpPost]
        //public IActionResult SaveCurrency(int? CurrencyId, string CurrencyType, string CurrencySymbol, string USDExchangeRate)
        public IActionResult SaveCurrency(CurrenciesModel data)
        {
            
             
            if (!ModelState.IsValid)
            {
                return BadRequest("Enter required fields");
            }

            var result = _accRepo.SaveCurrencies(data);

            return Json(result);
        }

        
        [HttpPost]
        public IActionResult SaveAccount(AccountModel data)
        {

            //long size = data.files.Sum(f => f.Length);

            //// full path to file in temp location
            //var filePath = Path.GetTempFileName();

            //foreach (var formFile in data.files)
            //{
            //    if (formFile.Length > 0)
            //    {
            //        using (var stream = new FileStream(filePath, FileMode.Create))
            //        {
            //              formFile.CopyToAsync(stream);
            //        }
            //    }
            //}

            string uploadFolderPath = "~/Photo/";

            //string fileName = FileUpload1.FileName.ToString();
           
            //string filePath = HttpContext.Current.Server.MapPath(uploadFolderPath);
            //FileUpload1.SaveAs(filePath + "\\" + fileName);
            //ImageButton1.ImageUrl = "~/Image/" + "/" + FileUpload1.FileName.ToString();

            if (!ModelState.IsValid)
            {
                return BadRequest("Enter required fields");
            }

            var result = _accRepo.SaveAccount(data);

            return Json(result);
        }

    }
}
