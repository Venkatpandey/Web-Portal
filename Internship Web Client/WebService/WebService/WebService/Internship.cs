using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WebService;

namespace WebService
{
    [DataContract]
    public class Internship
    {
         [DataMember]
        public Company company;

         [DataMember]
        public Feedback feedback;

        [DataMember]
        public DateTime start, end;

        public Internship() {

            company = new Company();
            feedback = new Feedback();
        }
    }
}