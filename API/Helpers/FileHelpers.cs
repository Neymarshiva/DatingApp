using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public static class FileHelpers
    {

        public static string FileContentType(this string fileType) => (fileType.ToUpper())
            switch
        {
            ("DOC") => "application/msword",
            ("DOCX") => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
            ("PDF") => "application/pdf",
            ("XLS") => "application/vnd.ms-excel",
            ("XLSX") => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            ("CSV") => "text/csv",
            ("XML") => "text/xml",
            _ => "text/plain"
        };
    }
}
