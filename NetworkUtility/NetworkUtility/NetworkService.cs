using NetworkUtility.NetworkUtility.DNS;
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
        private readonly IDNS _dNS;

        public NetworkService(IDNS dNS)
        {
            _dNS = dNS;
        }

        public string PingSent()
        {
            bool IsDnsSuccess = _dNS.SendDNS();
            if (IsDnsSuccess)
            {
                return "Ping Sent";
            }
            else 
            {
                return "Ping not send";
            }
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
