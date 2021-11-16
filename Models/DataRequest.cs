using System;
using System.Collections.Generic;
using System.Text;

namespace Galytix.WebApi.Models
{
    public class DataRequest
    {
        public string? country { get; set; }
        
        public string[] lob { get; set; }
        
        public int? start { get; set; }

        public int? end { get; set; }

    }
}
