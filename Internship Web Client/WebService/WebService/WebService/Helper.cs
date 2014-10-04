using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI.WebControls;

//Mail
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization;

namespace WebService
{
     [DataContract] 
    public class Helper
    {
         [DataMember]
        public Student student { get; set; }

         [DataMember]
        public Group group { set; get; }

         public Helper() {
             student = new Student();
             group = new Group();
         }
    }
}