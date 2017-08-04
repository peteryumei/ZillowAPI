using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZillowAPIDemo.Models
{
    public class HomeAddress
    {
        public string StreetAddress { get; set; }

        public string City{ get; set; }

        public string State { get; set; }

        public string Zipcode { get; set; }
    }
}
