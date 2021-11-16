using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galytix.WebApi.Models;
using Galytix.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Galytix.WebApi.Controllers
{
    [ApiController]
    [Route("/api/gwp/avg")]
    public class CountryGwpController : ControllerBase
    {
     
        [HttpPost]
        public ActionResult RetrieveData([FromBody] DataRequest dataRequest)
        {
            //VALIDATIONS
            if (dataRequest == null)
            {
                return BadRequest();
            }

            if(dataRequest.country.CompareTo("")==0 || dataRequest.country == null)
            {
                return BadRequest("Please provide country name");
            }

            if (dataRequest.lob.Count() == 0)
            {
                return BadRequest("No line of Business provided");
            }

            if (dataRequest.start == null)
            {
                return BadRequest("Please provide start year");
            }

            if (dataRequest.end == null)
            {
                return BadRequest("Please provide end year");
            }

            if (dataRequest.end < dataRequest.start)
            {
                return BadRequest("Invalid start and end year");
            }

            //RETREIVING DATA FROM CSV FILE

            var _dataService = new DataService();

            var result = _dataService.GetDataRows(dataRequest.country, dataRequest.start, dataRequest.end);

            //VALIDATING
            if (result.Count() == 0)
            {
                return BadRequest("No data found for the specified country");
            }

            //LOGIC
            Dictionary<string, double> dict = new Dictionary<string, double>();

            foreach(string _lob in dataRequest.lob)
            {
                dict[_lob] = 0.0;
            }

            foreach(DataRow x in result)
            {
                if (dict.ContainsKey(x.lineOfBusiness))
                {
                    int c = 0;
                    
                    foreach(double? val in x.values)
                    {
                        if (val != null)
                        {
                            c++;
                            dict[x.lineOfBusiness] += (double)val;
                        }
                    }

                    if (c != 0)
                    {
                        dict[x.lineOfBusiness] = dict[x.lineOfBusiness] / c;
                        dict[x.lineOfBusiness] = Math.Round(dict[x.lineOfBusiness], 1);
                    }
                }
            }

            return new JsonResult(dict);
        }
    }
}
