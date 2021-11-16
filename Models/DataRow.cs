using System.Collections.Generic;

namespace Galytix.WebApi.Models
{
    public class DataRow
    {
        public string country { get; set; }
        
        public string variableId { get; set; }
        
        public string variableName { get; set; }
        
        public string lineOfBusiness { get; set; }

        public List<double?> values { get; set; }

    }
}
