using ExcelDataReader;
using Playwright_Pom_Struct.Test_DataClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Pom_Struct.Utilities
{
    public  class LoginDataRead
    {
        public static List<EAText> ReadLoginDataText(string excelFilePath, string sheetName)

        {

            List<EAText> excelDataList = new List<EAText>();

            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);



            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))

            {

                using (var reader = ExcelReaderFactory.CreateReader(stream))

                {

                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()

                    {

                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()

                        {

                            UseHeaderRow = true,

                        }

                    });



                    var dataTable = result.Tables[sheetName];



                    if (dataTable != null)

                    {

                        foreach (DataRow row in dataTable.Rows)

                        {

                            EAText excelData = new EAText

                            {

                                UserName = GetValueOrDefault(row, "username"),
                                Password = GetValueOrDefault(row, "password")

                            };
                            excelDataList.Add(excelData);
                        }

                    }

                    else

                    {

                        Console.WriteLine($"Sheet '{sheetName}' not found in the Excel file.");

                    }

                }

            }
            return excelDataList;

        }
        static string ? GetValueOrDefault(DataRow row, string columnName)

        {
            Console.WriteLine(row + "  " + columnName);

            return row.Table.Columns.Contains(columnName) ? row[columnName]?.ToString() : null;
        }
    }
}
