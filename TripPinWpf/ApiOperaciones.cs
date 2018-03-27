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
        //public static Container Container { get; set; } = new Container(new Uri("http://services.odata.org/TripPinRESTierService/(S(bl4qoxizginrb5uv0llomwkr))/"));
        public static DefaultContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = new DefaultContainer(new Uri("http://services.odata.org/v4/(S(lqbvtwide0ngdev54adgc0lu))/TripPinServiceRW/"));
                }
                return container;
            }
        }

        private static DefaultContainer container;
    }

}
    
