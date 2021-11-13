using CsvHelper;
using Galytix.WebApi.Mappers;
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
        public List<DataRow> GetDataRows()
        {
            try
            {
                using (var reader = new System.IO.StreamReader("E:\\gwpByCountry.csv", Encoding.Default))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<DataMapper>();
                    var records = csv.GetRecords<DataRow>().ToList();
                    return records;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

