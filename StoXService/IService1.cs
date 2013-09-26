/* *
 * 
 *  Gekko Stocks Web Service - Interface
 *  Robert Petre
 *  
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StoXService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        // Service Operations
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetIndexes", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<string> GetIndexes();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetInfo/{index}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Company GetInfo(string index);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Search/{phrase}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Company> Search(string phrase);
    }   

    // Service Classes

    [DataContract]
    public class Company
    {
        [DataMember]
        public string Name
        {
            get;
            set;
        }
        [DataMember]
        public string Symbol
        {
            get;
            set;
        }
        [DataMember]
        public DateTime Datetime
        {
            get;
            set;
        }
        [DataMember]
        public double CurrentPrice
        {
            get;
            set;
        }
        [DataMember]
        public double ChangeValue
        {
            get;
            set;
        }
        [DataMember]
        public double ChangePercent
        {
            get;
            set;
        }
        [DataMember]
        public double PreviousClose
        {
            get;
            set;
        }
        [DataMember]
        public double Open
        {
            get;
            set;
        }
        [DataMember]
        public int Volume
        {
            get;
            set;
        }
        [DataMember]
        public double DayMinPrice
        {
            get;
            set;
        }
        [DataMember]
        public double DayMaxPrice
        {
            get;
            set;
        }
        [DataMember]
        public double YearMinPrice
        {
            get;
            set;
        }
        [DataMember]
        public double YearMaxPrice
        {
            get;
            set;
        }
    }
    
}
