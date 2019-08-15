using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace AlgorithmTest
{
    public class ExcelUtility
    {

        public void CreateExcel(string filePath, string textFile )
        {
            SpreadsheetDocument spreadsheetDocument =
                SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook);

            // Add a WorkbookPart to the document.
            WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
            workbookpart.Workbook = new Workbook();

            // Add a WorksheetPart to the WorkbookPart.
            WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
            var sheetData = new SheetData();
            worksheetPart.Worksheet = new Worksheet(sheetData);

            

            // Add Sheets to the Workbook.
            Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());

            // Append a new worksheet and associate it with the workbook.
            Sheet sheet = new Sheet()
            {
                Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                SheetId = 1,
                Name = "mySheet"
            };
            sheets.Append(sheet);

            var cellIdex = 0;
            UInt32 rowIdex = 0;
            var row = new Row { RowIndex = ++rowIdex };
            string[] lines = File.ReadAllLines(textFile);
            foreach (string line in lines)
            {
               // string[] col = line.Split(new char[] {','});
                // process col[0], col[1], col[2]


                // Add sheet data
                foreach (var rowData in lines)
                {
                    cellIdex = 0;
                    row = new Row {RowIndex = ++rowIdex};
                    sheetData.Append(row);
                    foreach (var callData in rowData.Split(new char[] { ',' }))
                    {
                        var cell = CreateTextCell(ColumnLetter(cellIdex++),
                            rowIdex, callData ?? string.Empty);
                        row.AppendChild(cell);
                    }

                    
                }

            }

            workbookpart.Workbook.Save();

            // Close the document.
            spreadsheetDocument.Close();
        }


        private Cell CreateTextCell(string header, UInt32 index,string text)
        {
            var cell = new Cell
            {
                DataType = CellValues.InlineString,
                CellReference = header + index
            };

            var istring = new InlineString();
            var t = new Text { Text = text };
            istring.AppendChild(t);
            cell.AppendChild(istring);
            return cell;
        }

        private string ColumnLetter(int intCol)
        {
            var intFirstLetter = ((intCol) / 676) + 64;
            var intSecondLetter = ((intCol % 676) / 26) + 64;
            var intThirdLetter = (intCol % 26) + 65;

            var firstLetter = (intFirstLetter > 64)
                ? (char)intFirstLetter : ' ';
            var secondLetter = (intSecondLetter > 64)
                ? (char)intSecondLetter : ' ';
            var thirdLetter = (char)intThirdLetter;

            return string.Concat(firstLetter, secondLetter,
                thirdLetter).Trim();
        }

    }
}
