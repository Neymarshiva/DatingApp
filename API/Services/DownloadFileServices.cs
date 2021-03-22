using API.DTOs;
using API.Helpers;
using API.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class DownloadFileServices : IDownloadFileServices
    {
        public async Task<FileExportModel> GetExportFileStream(string fileType)
        {
            MemoryStream fs = null;
            string fileName = "SampleFile";

            switch (fileType.ToUpper())
            {
                case "PDF":
                    fs = new MemoryStream(ExportHelpers.GetPdfStream());
                    break;
                case "XLS":
                    fs = new MemoryStream();
                    break;
                case "XLSX":
                    fs = new MemoryStream();
                    break;
                case "CSV":
                    fs = new MemoryStream();
                    break;
                default:
                    fs = new MemoryStream();
                    break;

            }

            return new FileExportModel { 
                FileName = fileName,
                stream = fs
            };
        }
    }
}
