using AMS.Repository_Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Controllers
{
    public class HawalaController : Controller
    {
        public IHawalaRepository _hawalaRepository;

        public HawalaController(IHawalaRepository hawalaRepository)
        {
            _hawalaRepository = hawalaRepository;
        }

        public IActionResult Index()
        {
            var listHawala = _hawalaRepository.GetHawalaDetails();
            return View(listHawala.Result);
        }
    }
}
