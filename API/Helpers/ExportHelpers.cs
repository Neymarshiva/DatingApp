using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout.Borders;
using iText.Html2pdf;
using ClosedXML.Excel;

namespace API.Helpers
{
    public static class ExportHelpers
    {
        public static byte[] GetPdfStream()
        {
            byte[] bytes;
            try
            {
                var empRecord = new List<EmplyoeeList>();

                var emp1 = new EmplyoeeList
                {
                    Name = "Neymar",
                    Email = "Neymar@yopmail.com",
                    Mobile = 845887548754
                };
                var emp2 = new EmplyoeeList
                {
                    Name = "messi",
                    Email = "Neymar@yopmail.com",
                    Mobile = 845887548754
                };
                var emp3 = new EmplyoeeList
                {
                    Name = "test",
                    Email = "Neymar@yopmail.com",
                    Mobile = 845887548754
                };
                empRecord.Add(emp1);
                empRecord.Add(emp2);
                empRecord.Add(emp3);


                #region column Array
                string[] colNames = new string[]
                {
                    "Name",
                    "Email",
                    "Mobile"
                };

                #endregion

                MemoryStream ms = new MemoryStream();
                var writer = new PdfWriter(ms);
                var pdf = new PdfDocument(writer);
                var doc = new Document(pdf, PageSize.A4.Rotate());

                float[] columWidth = { 1, 5, 5, 5 };

                Table table = new Table(UnitValue.CreatePercentArray(columWidth));
                table.SetAutoLayout();
                PdfFont f = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                table.AddHeaderCell(new Paragraph("EmplyoeeRecord"))
                    .SetFont(f)
                    .SetFontSize(12)
                    .SetBold()
                    .SetFontColor(DeviceGray.BLACK)
                    .SetTextAlignment(TextAlignment.CENTER);

                table.AddHeaderCell(new Cell().SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Sl.No.")));

                for(int i =0;i < colNames.Length; i++)
                {
                    table.AddHeaderCell(new Cell().SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph(colNames[i])));
                }

                for(int counter = 0; counter < empRecord.Count; counter++)
                {
                    var records = empRecord[counter];

                    table.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph((counter + 1).ToString())));

                    var nameCell = new Cell();
                    nameCell.Add(new Paragraph(records.Name));
                    table.AddCell(nameCell);

                    var emailCell = new Cell();
                    emailCell.Add(new Paragraph(records.Email));
                    table.AddCell(emailCell);

                    var mobileCell = new Cell();
                    mobileCell.Add(new Paragraph((records.Mobile).ToString()));
                    table.AddCell(mobileCell);

                }

                doc.Add(table);
                doc.Close();
                bytes = ms.ToArray();
                return bytes;

            }
            catch (Exception ex)
            {               
                return null;
            }

        }
    }
}

public class EmplyoeeList
{
    public string Name { get; set; }
    public string Email { get; set; }
    public long Mobile { get; set; }
}