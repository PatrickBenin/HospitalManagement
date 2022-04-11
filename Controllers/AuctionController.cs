using AMS.Context;
using AMS.Models;
using AMS.Repository_Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Controllers
{
    public class AuctionController : Controller
    {
        
        public IAuctionRepository _aucRepo;
        private IHostingEnvironment hostingEnv;

        public AuctionController(IAuctionRepository aucRepo,IHostingEnvironment env)
        {
            _aucRepo = aucRepo;
            this.hostingEnv = env;
        }


        public IActionResult Auctions()
        {
            var listauctions = _aucRepo.GetAuctionDetails();
            return View(listauctions.Result);
        }
        [HttpPost]
        public IActionResult SaveAuction(AuctionModel auctionmodel)
        {
            string path = string.Empty;

            var file = auctionmodel.RelatedDocument;
            int res = FileUpload_BL.UploadFile(file, hostingEnv, "Documents");

            var result = _aucRepo.SaveAuctions(auctionmodel);
            return Json(result); ;
        }
    }
}

 
