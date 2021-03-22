using API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IDownloadFileServices
    {
        Task<FileExportModel> GetExportFileStream(string fileType);
    }
}
