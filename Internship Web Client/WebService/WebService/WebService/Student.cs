using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Runtime.Serialization;


namespace WebService
{
    [DataContract]
    public class Student 
    {
        [DataMember]
        public string firstName { set; get; }

        [DataMember]
        public string lastName{set; get;}

        [DataMember]
        public string groupNumber { set; get; }

        [DataMember]
        public string matriculationNumber { set; get; }

        [DataMember]
        public string password { set; get; }

        [DataMember]
        public bool isApplicationSend { set; get; }

        [DataMember]
        public bool isCompleted { set; get; }

        [DataMember]
        public DateTime dateFirstContact { set; get; }

        [DataMember]
        public DateTime dateApplicationSend { set; get; }

        [DataMember]
        public DateTime dateCompletionSend { set; get; }

        [DataMember]
        public bool applicationAccept { set; get; }

        [DataMember]
        public Internship internship { set; get; }

        [DataMember]
        public string backOfficeCommentApplication { set; get; }

        [DataMember]
        public string backOfficeCommentCompletion { set; get; }

        public Student() {

            internship = new Internship();

        }

    }
}