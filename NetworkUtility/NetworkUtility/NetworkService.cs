using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SW.Payroll.NetworkUtility
{
    public class NetworkService
    {
        public string PingSent()
        {
            return "Ping Sent";
        }
        public int PingTimeOut(int x, int y)
        {
            return x + y;
        }
        public DateTime LastPingDate()
        {
            return DateTime.Now;
        }
        public PingOptions GetPingOptions()
        {
            return new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
        }
        public IEnumerable<PingOptions> MostRecentPings()
        {
            IEnumerable<PingOptions> pingOptions = new List<PingOptions>()
            {
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                },
                new PingOptions()
                {
                    DontFragment = false,
                    Ttl = 2
                },
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 3
                },
            };

            return pingOptions;
        }
    }
}
