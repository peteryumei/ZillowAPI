using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZillowAPIDemo.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Xml;
using System.Text.Encodings.Web;

namespace ZillowAPIDemo.Service
{
    class ZillowService: IZillowService
    {
        public ZillowService()
        {

        }

        public SearchResult HomeSearch(HomeAddress address)
        {
            SearchResult result = new SearchResult();
            using (var client = new HttpClient())
            {

                try
                {
                    String url = "http://www.zillow.com/webservice/GetSearchResults.htm?zws-id=X1-ZWz1dyb53fdhjf_6jziz&address=" + address.StreetAddress + "&citystatezip=" + address.City + ", " + address.State + ", " + address.Zipcode;

                    var response = client.GetAsync(url).Result;
                    var responseContent = response.Content;
                    var responseString = responseContent.ReadAsStringAsync().Result;
                    var doc = new XmlDocument();
                    doc.LoadXml(responseString);

                    string jsonResponse = JsonConvert.SerializeXmlNode(doc);
                    JObject json = JObject.Parse(jsonResponse);
                    //dynamic results = JsonConvert.DeserializeObject<dynamic>(jsonResponse);

                    //Another option is to use XPath to get values from XML document
                    result.requestAddress = (string)json["SearchResults:searchresults"]["request"]["address"];
                    result.requestCityStateZip = (string)json["SearchResults:searchresults"]["request"]["citystatezip"];       
                    result.returnCode = (string)json["SearchResults:searchresults"]["message"]["code"];
                    result.returnMessgae = (string)json["SearchResults:searchresults"]["message"]["text"];
                    if (result.returnCode != "0")
                        return result;
                    result.zpid = (string)json["SearchResults:searchresults"]["response"]["results"]["result"]["zpid"];
                    result.linkHomeDetails = (string)json["SearchResults:searchresults"]["response"]["results"]["result"]["links"]["homedetails"];
                    result.linkGraphs = (string)json["SearchResults:searchresults"]["response"]["results"]["result"]["links"]["graphsanddata"];
                    result.linkMap = (string)json["SearchResults:searchresults"]["response"]["results"]["result"]["links"]["mapthishome"];
                    result.linkComparable = (string)json["SearchResults:searchresults"]["response"]["results"]["result"]["links"]["comparables"];
                    result.StreetAddress = (string)json["SearchResults:searchresults"]["response"]["results"]["result"]["address"]["street"];
                    result.Zipcode = (string)json["SearchResults:searchresults"]["response"]["results"]["result"]["address"]["zipcode"];
                    result.City = (string)json["SearchResults:searchresults"]["response"]["results"]["result"]["address"]["city"];
                    result.State = (string)json["SearchResults:searchresults"]["response"]["results"]["result"]["address"]["state"];
                    result.latitude = (string)json["SearchResults:searchresults"]["response"]["results"]["result"]["address"]["latitude"];
                    result.longitude = (string)json["SearchResults:searchresults"]["response"]["results"]["result"]["address"]["longitude"];
                    result.zestimateAmount = (string)json["SearchResults:searchresults"]["response"]["results"]["result"]["zestimate"]["amount"]["#text"];
                    result.zestimateUpdateDate = (string)json["SearchResults:searchresults"]["response"]["results"]["result"]["zestimate"]["last-updated"];
                    result.zestimate30daysChange = (string)json["SearchResults:searchresults"]["response"]["results"]["result"]["zestimate"]["valueChange"]["#text"];
                    result.zestimateLow = (string)json["SearchResults:searchresults"]["response"]["results"]["result"]["zestimate"]["valuationRange"]["low"]["#text"];
                    result.zestimateHigh = (string)json["SearchResults:searchresults"]["response"]["results"]["result"]["zestimate"]["valuationRange"]["high"]["#text"];
                    result.percentile = (string)json["SearchResults:searchresults"]["response"]["results"]["result"]["zestimate"]["percentile"];
                    result.zillowIndex = (string)json["SearchResults:searchresults"]["response"]["results"]["result"]["localRealEstate"]["region"]["zindexValue"];
                    result.linkOverview = (string)json["SearchResults:searchresults"]["response"]["results"]["result"]["localRealEstate"]["region"]["links"]["overview"];
                    result.linkForSaleByOwner = (string)json["SearchResults:searchresults"]["response"]["results"]["result"]["localRealEstate"]["region"]["links"]["forSaleByOwner"];
                    result.linkForSale = (string)json["SearchResults:searchresults"]["response"]["results"]["result"]["localRealEstate"]["region"]["links"]["forSale"];
                    return result;
        }
                catch (Exception ex)
                {
                    //TODO log error here and throw the error back to controller
                    throw ex;
                }
}
        }

        public string HomeSearchJSON(HomeAddress address)
        {
            SearchResult result = new SearchResult();
            using (var client = new HttpClient())
            {
                try
                { 
                    String url = "http://www.zillow.com/webservice/GetSearchResults.htm?zws-id=X1-ZWz1dyb53fdhjf_6jziz&address=" + WebUtility.HtmlEncode(address.StreetAddress + "&citystatezip=" + address.City + ", " + address.State + ", " + address.Zipcode);
                    var response = client.GetAsync(url).Result;
                    var responseContent = response.Content;
                    var responseString = responseContent.ReadAsStringAsync().Result;
                    var doc = new XmlDocument();
                    doc.LoadXml(responseString);
                    string jsonResponse = JsonConvert.SerializeXmlNode(doc);

                    return jsonResponse;
                }
                catch (Exception ex)
                {
                    //TODO log error here and throw the error back to controller
                    throw ex;
                }
            }
        }

        public string HomeSearchJSON(string address)
        {
            SearchResult result = new SearchResult();
            using (var client = new HttpClient())
            {
                try
                {
                    String url = "http://www.zillow.com/webservice/GetSearchResults.htm?zws-id=X1-ZWz1dyb53fdhjf_6jziz&" + address.Replace("?", "");
                    var response = client.GetAsync(url).Result;
                    var responseContent = response.Content;
                    var responseString = responseContent.ReadAsStringAsync().Result;
                    var doc = new XmlDocument();
                    doc.LoadXml(responseString);
                    string jsonResponse = JsonConvert.SerializeXmlNode(doc);
                    return jsonResponse;
                }
                catch (Exception ex)
                {
                    //TODO log error here and throw the error back to controller
                    throw ex;
                }
            }
        }

        public string HomeSearchXML(HomeAddress address)
        {
            SearchResult result = new SearchResult();
            using (var client = new HttpClient())
            {
                try
                {
                    String url = "http://www.zillow.com/webservice/GetSearchResults.htm?zws-id=X1-ZWz1dyb53fdhjf_6jziz&address=" + WebUtility.HtmlEncode(address.StreetAddress + "&citystatezip=" + address.City + ", " + address.State + ", " + address.Zipcode);
                    var response = client.GetAsync(url).Result;
                    var responseContent = response.Content;
                    var responseString = responseContent.ReadAsStringAsync().Result;
                    return responseString;
                }
                catch (Exception ex)
                {
                    //TODO log error here and throw the error back to controller
                    throw ex;
                }
            }
        }
    }
}
