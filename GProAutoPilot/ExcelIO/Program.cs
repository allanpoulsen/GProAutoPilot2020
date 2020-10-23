using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;

namespace ExcelIO
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Lets open the existing excel file and read through its content . Open the excel using openxml sdk
                using (SpreadsheetDocument doc = SpreadsheetDocument.Open("GPRO Version 6 - Rob.xlsx", false))
                {
                    //create the object for workbook part  
                    WorkbookPart workbookPart = doc.WorkbookPart;
                    Sheets thesheetcollection = workbookPart.Workbook.GetFirstChild<Sheets>();

                    Sheet thesheet = (Sheet)thesheetcollection.GetFirstChild<Sheet>();

                    SheetData thesheetdata = (SheetData)thesheet.GetFirstChild<SheetData>();

                }
            }
            catch (Exception)
            {

            }
        }
    }
}
