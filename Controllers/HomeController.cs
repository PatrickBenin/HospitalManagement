using AMS.Context;
using AMS.Models;
using AMS.Repository_Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AMS.Controllers
{
    public class HomeController : Controller
    {
        public IAccountRepository _accRepo { get; set; }
        private IHostingEnvironment hostingEnv;
        public HomeController(IAccountRepository accRepo, IHostingEnvironment env)
        {
            _accRepo = accRepo;
            this.hostingEnv = env;
        }
        public IActionResult Index()
        {
            var listaccounts = _accRepo.GetAccountDetails();
            var listaccountsType = _accRepo.GetAccountTypes();
            ViewBag.AccountType = new SelectList(listaccountsType.Result, "AccountType", "AccountType");
            var listcurrencies = _accRepo.GetCurrencies();
            ViewBag.CurrencySymbol = new SelectList(listcurrencies.Result, "CurrencyId", "CurrencySymbol");
            var listDocumentTypes = _accRepo.GetDocumentType();
            ViewBag.DocumentTypes = new SelectList(listDocumentTypes.Result, "ID", "DocumentType");
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
        public IActionResult SaveAccount(AccountModel accountModel)
        {
            string path = string.Empty;

            var file = accountModel.files;
            int res = FileUpload_BL.UploadFile(file, hostingEnv, "Photo");

            var result = _accRepo.SaveAccount(accountModel);
            return Json(result);

        }

        [HttpPost]
        public IActionResult SaveDocument(AccontDocument documentTypeModel)
        {
            

            var file = documentTypeModel.docFile;
            int res = FileUpload_BL.UploadFile(file, hostingEnv, "Documents");

            var result = _accRepo.SaveAccountDocument(documentTypeModel);
            return Json(result);

        }

        [HttpGet]
        public ActionResult GetDocuments()
        {
            var result = _accRepo.GetUploadedDocument();
            return Json(result.Result);
        
        }
    }
}

