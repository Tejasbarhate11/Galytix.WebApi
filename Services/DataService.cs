using Galytix.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Galytix.WebApi.Services
{
    public class DataService
    {
        public List<DataRow> GetDataRows(string country, int? start=2008, int? end=2015)
        {
            List<DataRow> rows = new List<DataRow>();

            start = start - 2000 + 4;
            end = end - 2000 + 4;

            
            using (var reader = new System.IO.StreamReader("E:\\gwpByCountry.csv", Encoding.Default))
            {
                string[] headers = reader.ReadLine().Split(',');

                while (!reader.EndOfStream)
                {
                        
                    string[] row = reader.ReadLine().Split(',');
                       
                    if(String.Equals(country, row[0].ToString()))
                    {
                        DataRow data = new DataRow();

                        data.country = row[0];
                        data.variableId = row[1];
                        data.variableName = row[2];
                        data.lineOfBusiness = row[3];
                        data.values = new List<double?>();

                        for (int i = (int)start; i <= Math.Min((int)end, row.Length - 1); i++)
                        {
                            try
                            {
                                data.values.Add(Convert.ToDouble(row[i].ToString()));
                            }
                            catch (System.FormatException)
                            {
                                data.values.Add(null);
                            }
                        }
                        rows.Add(data);
                    }
                    
                }
            }
            return rows;
        }
    }
}

