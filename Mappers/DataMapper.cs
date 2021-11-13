using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper.Configuration;
using Galytix.WebApi.Models;

namespace Galytix.WebApi.Mappers
{
    public sealed class DataMapper : ClassMap<DataRow>
    {
        public DataMapper()
        {
            Map(x => x.country).Name("country");
            Map(x => x.variableId).Name("variableId");
            Map(x => x.variableName).Name("variableName");
            Map(x => x.lineOfBusiness).Name("lineOfBusiness");
            Map(x => x.Y2000).Name("Y2000");
            Map(x => x.Y2001).Name("Y2001");
            Map(x => x.Y2002).Name("Y2002");
            Map(x => x.Y2003).Name("Y2003");
            Map(x => x.Y2004).Name("Y2004");
            Map(x => x.Y2005).Name("Y2005");
            Map(x => x.Y2006).Name("Y2006");
            Map(x => x.Y2007).Name("Y2007");
            Map(x => x.Y2008).Name("Y2008");
            Map(x => x.Y2009).Name("Y2009");
            Map(x => x.Y2010).Name("Y2010");
            Map(x => x.Y2011).Name("Y2011");
            Map(x => x.Y2012).Name("Y2012");
            Map(x => x.Y2013).Name("Y2013");
            Map(x => x.Y2014).Name("Y2014");
            Map(x => x.Y2015).Name("Y2015");
        }
    }
}
