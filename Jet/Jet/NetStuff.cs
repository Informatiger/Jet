using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Jet
{
    class NetStuff
    {
        public static IPAddress GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var interNetworkIps = new List<IPAddress>();
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    interNetworkIps.Add(ip) ;
                }
            }

            if (interNetworkIps.Count > 0)
                return interNetworkIps[0];
            
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
