using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC403.Models
{
    internal class OrderModels
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string OrderNumber { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public string Note { get; set; }
        public int NetWeight { get; set; }
        public string Status { get; set; }
    }
}
