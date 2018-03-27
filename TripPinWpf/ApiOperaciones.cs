using Microsoft.OData.SampleService.Models.TripPin;
//using Microsoft.OData.Service.Sample.TrippinInMemory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPinWpf
{
    public class ApiOperaciones
    {
        //public static Container Container { get; set; } = new Container(new Uri("http://services.odata.org/TripPinRESTierService/(S(dmhrqjuw30xcona4vkmri505))/"));
        public static DefaultContainer Container { get; set; } = new DefaultContainer(new Uri("http://services.odata.org/v4/(S(lqbvtwide0ngdev54adgc0lu))/TripPinServiceRW/"));
    }
    
}
    
