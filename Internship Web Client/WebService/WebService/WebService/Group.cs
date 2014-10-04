using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.UI.WebControls;

namespace WebService
{
    [DataContract]
    public class Group
    {
        [DataMember]
        public string groupName { get; set; }

        [DataMember]
        public DateTime earliestStartOfInternship { get; set; }
        
        [DataMember]
        public DateTime latestEndOfInternship { get; set; }

        [DataMember]
        public int workingDays { get; set; }

        [DataMember]
        public string groupNumber { get; set; }

       
    }
}