
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
     
        [HttpGet]
        public ActionResult Get()
        {
            var _dataService = new DataService();
            return Ok(_dataService.GetDataRows());
        }

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

            //RETREIVING DATA FROM CSV FILE

            var _dataService = new DataService();

            var rawData = _dataService.GetDataRows();

            //FILTERING DATA
            List<DataRow> result = new List<DataRow>();

            foreach (DataRow x in rawData)
            {
                if (x.country.CompareTo(dataRequest.country)==0)
                {
                    result.Add(x);
                }
            }

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
                    int count = 0;
                    if (x.Y2008 != null)
                    {
                        count++;
                        dict[x.lineOfBusiness] = dict[x.lineOfBusiness] + (double) x.Y2008;

                    }

                    if (x.Y2009 != null)
                    {
                        count++;
                        dict[x.lineOfBusiness] = dict[x.lineOfBusiness] + (double)x.Y2009;

                    }

                    if (x.Y2010 != null)
                    {
                        count++;
                        dict[x.lineOfBusiness] = dict[x.lineOfBusiness] + (double)x.Y2010;

                    }

                    if (x.Y2011 != null)
                    {
                        count++;
                        dict[x.lineOfBusiness] = dict[x.lineOfBusiness] + (double)x.Y2011;

                    }

                    if (x.Y2012 != null)
                    {
                        count++;
                        dict[x.lineOfBusiness] = dict[x.lineOfBusiness] + (double)x.Y2012;

                    }

                    if (x.Y2013 != null)
                    {
                        count++;
                        dict[x.lineOfBusiness] = dict[x.lineOfBusiness] + (double)x.Y2013;

                    }

                    if (x.Y2014 != null)
                    {
                        count++;
                        dict[x.lineOfBusiness] = dict[x.lineOfBusiness] + (double)x.Y2014;

                    }

                    if (x.Y2015 != null)
                    {
                        count++;
                        dict[x.lineOfBusiness] = dict[x.lineOfBusiness] + (double)x.Y2015;

                    }

                    if (count != 0)
                    {
                        dict[x.lineOfBusiness] = dict[x.lineOfBusiness] / count;
                        dict[x.lineOfBusiness] = Math.Round(dict[x.lineOfBusiness], 1);
                    }

                }
            }

            return new JsonResult(dict);
        }
    }
}
