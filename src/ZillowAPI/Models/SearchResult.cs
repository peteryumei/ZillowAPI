using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZillowAPIDemo.Models
{
    public class SearchResult
    {
        public string requestAddress { get; set; }
  
        public string requestCityStateZip { get; set; }

        public string returnCode { get; set; }

        public string returnMessgae { get; set; }

        public string zpid { get; set; }

        public string linkHomeDetails { get; set; }

        public string linkGraphs { get; set; }

        public string linkMap { get; set; }

        public string linkComparable { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zipcode { get; set; }

        public string latitude { get; set; }

        public string longitude { get; set; }

        public string zestimateAmount { get; set; }

        public string zestimateUpdateDate { get; set; }

        public string zestimate30daysChange { get; set; }

        public string zestimateLow { get; set; }

        public string percentile { get; set; }

        public string zestimateHigh { get; set; }

        public string zillowIndex { get; set; }

        public string linkOverview { get; set; }

        public string linkForSaleByOwner { get; set; }

        public string linkForSale { get; set; }

    }
}
