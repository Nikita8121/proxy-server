using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proxy_server.Models
{
    public class IpAddress
    {
        public string Ip { get; set; }
        public string Port { get; set; }

        public IpAddress(string ip, string port)
        {
            Ip = ip;
            Port = port;
        }

        public bool IsIpAdressEqual(string ip, string port)
        {
            if(Ip == ip && Port == port) return true;

            return false;
        }

    }
}
