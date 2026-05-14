using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC403.Models
{
    internal class OrderDetailModels
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string WeightType { get; set; }
        public int Weight { get; set; }
        public string Datetimes { get; set; }
    }
}
