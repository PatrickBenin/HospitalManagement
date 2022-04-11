using AMS.Models;
using AMS.Repository_Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Controllers
{
    public class ExchangeController : Controller
    {
        public IExchangeRepository _exchangeRepository;

        public ExchangeController(IExchangeRepository exchangeRepository)
        {
            _exchangeRepository = exchangeRepository;
        }


        public IActionResult Index()
        {
            var listauctions = _exchangeRepository.GetExchangeDetails();
            return View(listauctions.Result);
        }

       
        [HttpPost]
        public IActionResult SaveExChange(ExchangeModel ExchangeModel)
        {
            var result = _exchangeRepository.SaveExchange(ExchangeModel);
            return Json(result);
        }
    }
}
