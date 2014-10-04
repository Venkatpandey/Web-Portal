using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;


namespace WebService
{
    [DataContract]
    public class Feedback
    {
         [DataMember]
        public int Company_Rating { set; get; }

         [DataMember]
        public int Internship_Rating { set; get; }

         [DataMember]
        public string Students_Comment { set; get; }
    }
}