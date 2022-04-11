using AMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Repository_Interfaces
{
    public interface IDocumentTypeRepository
    {
        public Task<List<DocumentTypeModel>> GetDocumentTypes();
        public Task<int> SaveDocumentType(DocumentTypeModel documentTypeModel);
    }
}
