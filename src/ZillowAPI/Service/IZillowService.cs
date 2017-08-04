using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZillowAPIDemo.Models;

namespace ZillowAPIDemo.Service
{
    public interface IZillowService
    {
        SearchResult HomeSearch(HomeAddress address);

        string HomeSearchJSON(HomeAddress address);

        string HomeSearchJSON(string address);

        string HomeSearchXML(HomeAddress address);
    }
}
