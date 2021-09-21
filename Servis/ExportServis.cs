﻿using Common;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using exportWord = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
//using Microsoft.Office.Interop.Excel.DataTable;

namespace Servis
{
    public class ExportServis : IExport
    {
        public void ExportToExcel(List<Kvar> kvarovi)
        {
            System.Data.DataTable dataTable = ConvertToDataTable(kvarovi);

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);
            // create a excel app along side with workbook and worksheet and give a name to it
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkBook = excelApp.Workbooks.Add();
            Excel._Worksheet xlWorksheet = excelWorkBook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            foreach (System.Data.DataTable table in dataSet.Tables)
            {
                //Add a new worksheet to workbook with the Datatable name
                Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add();
                excelWorkSheet.Name = table.TableName;
                // add all the columns
                for (int i = 1; i < table.Columns.Count + 1; i++)
                {
                    excelWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
                }
                // add all the rows
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    for (int k = 0; k < table.Columns.Count; k++)
                    {
                        excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                    }
                }
            }

            excelWorkBook.SaveAs(@"C:\Users\PTB\source\repos\RES\doc1.xlsx"); // -> this will do the custom
            excelWorkBook.Close();
            excelApp.Quit();
        }

        private static System.Data.DataTable ConvertToDataTable<Kvar>(List<Kvar> models)
        {

            // creating a data table instance and typed it as our incoming model 
            System.Data.DataTable dataTable = new System.Data.DataTable(typeof(Kvar).Name);
            //Get all the properties of that model
            //PropertyInfo[] Props = typeof(Kvar).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            PropertyInfo PropID = typeof(Kvar).GetProperty("Id", typeof(string));
            PropertyInfo PropEl = typeof(Kvar).GetProperty("ElektricniElement", typeof(string));
            PropertyInfo PropDat = typeof(Kvar).GetProperty("DatumKvara", typeof(DateTime));
            PropertyInfo PropDat2 = typeof(Kvar).GetProperty("DatumZatvaranjaKvara", typeof(DateTime));

            List<PropertyInfo> Props = new List<PropertyInfo>() { PropID, PropEl, PropDat, PropDat2 };

            // Loop through all the properties            
            // Adding Column name to our datatable
            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }
            // Adding Row and its value to our dataTable
            foreach (Kvar item in models)
            {
                var values = new object[Props.Count];
                for (int i = 0; i < Props.Count; i++)
                {
                    //inserting property values to datatable rows  
                    values[i] = Props[i].GetValue(item, null);
                }
                // Finally add value to datatable  
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        public void ExportToWord(Kvar kvar)
        {
            throw new NotImplementedException();
        }
    }
}
