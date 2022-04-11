using AMS.Context;
using AMS.Models;
using AMS.Repository_Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Repository
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        public IConfiguration _Configuration;
        private readonly DapperContext _context;
        public DocumentTypeRepository(IConfiguration Configuration, DapperContext context)
        {
            _Configuration = Configuration;
            _context = context;
        }


        public async Task<List<DocumentTypeModel>> GetDocumentTypes()
        {
            using (var con = _context.CreateConnection())
            {
                var _listAccounts = con.Query<DocumentTypeModel>("PrGetDocumentypes", commandType: CommandType.StoredProcedure).ToList();

                return _listAccounts;
            }
        }

        public async Task<int> SaveDocumentType(DocumentTypeModel documentTypeModel)
        { 

            var param = new DynamicParameters();

            param.Add("@DocumentId", documentTypeModel.ID);
            param.Add("@DocumentType", documentTypeModel.DocumentType);
           
            using (var con = _context.CreateConnection())
            {
                int result = con.Execute("PrInsertUpsertDocumentType", param: param, commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}
