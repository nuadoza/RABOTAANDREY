using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR4
{
    public class Bus<T1, T2, T3, T4>
    {
        public T1 BusNumber { get; set; }
        public T2 DriverNameAndSurname { get; set; }
        public T3 RouteNumber { get; set; }
        public T4 OnTheRoute { get; set; }
        public Bus(T1 busNumber, T2 driverNameAndSurname, T3 routeNumber, T4 onTheRoute)
        {
            BusNumber = busNumber;
            DriverNameAndSurname = driverNameAndSurname;
            RouteNumber = routeNumber;
            OnTheRoute = onTheRoute;
        }
        void UpdateBusNumber(T1 newBusNumber)
        {
            BusNumber = newBusNumber;
        }
        void UpdateDriverNameAndSurname(T2 newDriverNameAndSurname)
        {
            DriverNameAndSurname = newDriverNameAndSurname;
        }
        void UpdateRouteNumber(T3 newRouteNumber)
        {
            RouteNumber = newRouteNumber;
        }
        void UpdateOnTheRoute(T4 newOnTheRoute)
        {
            OnTheRoute = newOnTheRoute;
        }
    }
}
