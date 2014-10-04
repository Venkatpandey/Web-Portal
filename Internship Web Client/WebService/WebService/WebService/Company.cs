using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebService
{
    [DataContract]
    public class Company
    {
        [DataMember]
        public string Company_Name { set; get; }

         [DataMember]
        public string Dapartment { set; get; }

         [DataMember]
        public string Street_and_Number { set; get; }

         [DataMember]
        public string City { set; get; }

         [DataMember]
        public string PIN { set; get; }

         [DataMember]
        public string Activity { set; get; }

         [DataMember]
        public string Coach_Name { set; get; }

         [DataMember]
        public string Coach_Phone { set; get; }
    }
}