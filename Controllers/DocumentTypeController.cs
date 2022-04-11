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
    public class DocumentTypeController : Controller
    {
        public IDocumentTypeRepository _documentTypeRepo;

        public DocumentTypeController(IDocumentTypeRepository documentTypeRepo)
        {
            _documentTypeRepo = documentTypeRepo;
        }


        public IActionResult GetDocumentTypes()
        {
            var listauctions = _documentTypeRepo.GetDocumentTypes();
            return View(listauctions.Result);
        }
        [HttpPost]
        public IActionResult SaveDocumentType(DocumentTypeModel documentTypeModel)
        {
            var result = _documentTypeRepo.SaveDocumentType(documentTypeModel);
            return Json(result);
        }
        
    }
}
