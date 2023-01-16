using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proxy_server.Models
{
    public class IpAddress
    {
        [Required(ErrorMessage = "Must not be empty.")]
        public string Ip { get; set; }
        [Required(ErrorMessage = "Must not be empty.")]
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

        public static bool Validate(IpAddress ipAddress)
        {
            ValidationContext context = new ValidationContext
            (ipAddress, null, null);
            List<ValidationResult> validationResults = new
            List<ValidationResult>();
            return Validator.TryValidateObject
            (ipAddress, context, validationResults, true);
        }

    }
}
