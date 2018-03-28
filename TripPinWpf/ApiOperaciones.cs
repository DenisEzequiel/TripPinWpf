using Microsoft.OData.SampleService.Models.TripPin;
using System;

namespace TripPinWpf
{
    public class ApiOperaciones
    {
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
    
