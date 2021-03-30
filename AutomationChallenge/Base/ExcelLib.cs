using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace AutomationChallenge.Base
{
    public class DataCollection
    {
        public int rowNumber { get; set; }
        public string colName { get; set; }
        public string colValue { get; set; }
    }
    public class ExcelLib
    {
        static List<DataCollection> dataCol = new List<DataCollection>();

        /// <summary>
        /// Converts excel data into DataTable
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>DataTable</returns>
        public static DataTable ExcelToDataTable(string filename)
        {
            try
            {
                FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);
                IExcelDataReader dataReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                DataSet result = dataReader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });
                DataTableCollection table = result.Tables;
                DataTable resultTable = table["Sheet1"];
                return resultTable;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Converts datatable into collection
        /// </summary>
        /// <param name="filename"></param>
        public static void PopulateInCollection(string filename)
        {
            try
            {
                DataTable dataTable = ExcelToDataTable(filename);

                // Iterate through the row and columns of the table
                for (int row = 1; row < dataTable.Rows.Count; row++)
                {
                    for (int col = 0; col < dataTable.Columns.Count; col++)
                    {
                        DataCollection dtTable = new DataCollection()
                        {
                            rowNumber = row,
                            colName = dataTable.Columns[col].ColumnName,
                            colValue = dataTable.Rows[row - 1][col].ToString()
                        };

                        // Add all the row for each row
                        dataCol.Add(dtTable);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
         }

        /// <summary>
        /// Reads data based on Rowno and column value
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="columnName"></param>
        /// <returns>string</returns>
        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                // Retriving data using LINQ to reduce much of iterations
                string data = (from colData in dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();
                return data.ToString();
            }
            catch (Exception)
            {
                return null;
                
            }
        }
    }
   
}
