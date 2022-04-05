using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AMS.Context
{
    public static class FileUpload_BL
    {
        public static int UploadFile(IFormFile fileobj, IHostingEnvironment hostingEnv,string path)
        {
            long size = 0;

            var file = fileobj;

            var filename = ContentDispositionHeaderValue

                            .Parse(file.ContentDisposition)

                            .FileName

                            .Trim('"');

            string FilePath = hostingEnv.WebRootPath + $@"\{path}\{filename}";

            size += file.Length;

            using (FileStream fs = System.IO.File.Create(FilePath))

            {

                file.CopyTo(fs);

                fs.Flush();

            }
            return 1;
        }
    }
}
