using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NPOI.HPSF;
using NPOI.XSSF.UserModel;

namespace ExcelOp
{
    class Program
    {
        static void Main(string[] args)
        {
            var workbook = new XSSFWorkbook();

            var cellStyle = workbook.CreateCellStyle();
            var font = workbook.CreateFont();
            font.FontName = "宋体";
            font.FontHeightInPoints = 11;
            cellStyle.SetFont(font);

            var sheet = workbook.CreateSheet("text");
            var headRow = sheet.CreateRow(0);
            headRow.CreateCell(1).SetCellValue(123);

            var outputPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "text.xlsx");

            using (var file = new FileStream(outputPath, FileMode.Create))
            {
                workbook.Write(file);
            }

            System.Diagnostics.Process.Start(outputPath);
        }
    }
}
