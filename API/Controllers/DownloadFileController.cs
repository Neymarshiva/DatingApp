using API.Helpers;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class DownloadFileController : BaseApiController
    {
        private readonly IDownloadFileServices _downloadServices;

        public DownloadFileController(IDownloadFileServices downloadServices)
        {
            _downloadServices = downloadServices;
        }


        [HttpGet("downloadFile/{fileType}")]
        public async Task<FileStreamResult> ExportFile(string fileType)
        {
            var result = await _downloadServices.GetExportFileStream(fileType);
            if (result != null)
            {
                return File(result.stream, fileType.FileContentType(), result.FileName);
            }

            return File(new MemoryStream(Encoding.UTF8.GetBytes("File Error")), fileType.FileContentType(), "SampleFile");
        }
    }
}
