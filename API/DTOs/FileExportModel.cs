using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class FileExportModel
    {
        public Stream stream { get; set; }
        public string FileName { get; set; }
    }
}
