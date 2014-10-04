using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Xml.Linq;
//using WebService;

namespace WebService
{
    /// <summary>
    /// Summary description for WebServiceInternship
    /// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[System.ComponentModel.ToolboxItem(false)]
    //// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceInternship 
    {

        private DB_StudentDataContext db;


        //[WebMethod]
        public void WebServiceInternshipStart()
        {
            db = new DB_StudentDataContext("C:\\Users\\Alexander\\Desktop\\Yass Lecture\\Visual Studio 2012\\Projects\\Web Service Yass\\Web Service Yass\\DB_Student.dbml");
            db.CreateDatabase();
        }


        private static TR_Group convertToTR_Group(Group g)
        {
            TR_Group tr_g = new TR_Group();

            tr_g.td_EarliestStartOfInternship = g.earliestStartOfInternship;
                            tr_g.td_GroupName = g.groupName;
                          tr_g.td_GroupNumber = g.groupNumber;
                          tr_g.td_WorkingDays = g.workingDays;

            return tr_g;
        }
        private static Group convertToGroup(TR_Group tr_g)
        {
            Group g = new Group();

            g.earliestStartOfInternship = tr_g.td_EarliestStartOfInternship;
                            g.groupName = tr_g.td_GroupName;
                          g.groupNumber = tr_g.td_GroupNumber;
                          g.workingDays = tr_g.td_WorkingDays;

            return g;
        }
        private static TR_Student convertToTR_Student(Student student){
            TR_Student tr_student = new TR_Student();
            tr_student.td_FirstName = student.firstName;
            tr_student.td_GroupNumber = student.groupNumber;
            tr_student.td_InternshipRating =student.internship.feedback.Internship_Rating;
            tr_student.td_IsApplicationSend = student.isApplicationSend;
            tr_student.td_IsCompleted = student.isCompleted;
            tr_student.td_LastName = student.lastName;
            tr_student.td_MatriculationNumber = student.matriculationNumber;
            tr_student.td_Password = student.password;
            tr_student.td_PIN = student.internship.company.PIN;
            tr_student.td_Start = student.internship.start;
            tr_student.td_StreetAndNumber = student.internship.company.Street_and_Number;
            tr_student.td_StudentComment = student.internship.feedback.Students_Comment;
            tr_student.td_Activity = student.internship.company.Activity;
            tr_student.td_City = student.internship.company.City;
            tr_student.td_CoachName = student.internship.company.Coach_Name;
            tr_student.td_CoachPhone = student.internship.company.Coach_Phone;
            tr_student.td_CompanyName = student.internship.company.Company_Name;
            tr_student.td_CompanyRating = student.internship.feedback.Company_Rating;
            tr_student.td_DateApplicationSend = student.dateApplicationSend;
            tr_student.td_DateCompletionSend = student.dateCompletionSend;
            tr_student.td_DateFirstContact = student.dateFirstContact;
            tr_student.td_Departmant = student.internship.company.Dapartment;
            tr_student.td_End = student.internship.end;

            return tr_student;
        }
        private static Student convertToStudent(TR_Student tr_student){
            Student student = new Student();
            student.firstName = tr_student.td_FirstName;
            student.groupNumber = tr_student.td_GroupNumber;
            student.internship.feedback.Internship_Rating =tr_student.td_InternshipRating;
            student.isApplicationSend = tr_student.td_IsApplicationSend;
            student.isCompleted = tr_student.td_IsCompleted;
            student.lastName = tr_student.td_LastName;
            student.matriculationNumber = tr_student.td_MatriculationNumber;
            student.password = tr_student.td_Password;
            student.internship.company.PIN = tr_student.td_PIN;
            student.internship.start = tr_student.td_Start;
            student.internship.company.Street_and_Number = tr_student.td_StreetAndNumber;
            student.internship.feedback.Students_Comment = tr_student.td_StudentComment;
            student.internship.company.Activity = tr_student.td_Activity;
            student.internship.company.City = tr_student.td_City;
            student.internship.company.Coach_Name = tr_student.td_CoachName;
            student.internship.company.Coach_Phone = tr_student.td_CoachPhone;
            student.internship.company.Company_Name = tr_student.td_CompanyName;
            student.internship.feedback.Company_Rating = tr_student.td_CompanyRating;
            student.dateApplicationSend = tr_student.td_DateApplicationSend;
            student.dateCompletionSend = tr_student.td_DateCompletionSend;
            student.dateFirstContact = tr_student.td_DateFirstContact;
            student.internship.company.Dapartment = tr_student.td_Departmant;
            student.internship.end = tr_student.td_End;

            return student;
        }
        private void saveDatabase()
        {
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter file = new StreamWriter(@"./DATABASE_LOG.txt"))
                {
                    file.WriteLine(ex.Message);
                }
            }
        }     
        private bool sendMail(string from, string emailAddress, string smtp, string message, string subject, int port, NetworkCredential credentials)
        {
            try
            {
                MailMessage msg = new MailMessage();

                msg.From = new MailAddress(from);
                msg.To.Add(new MailAddress(emailAddress));
                msg.Subject = subject;
                msg.Body = message;

                SmtpClient sc = new SmtpClient(smtp);
                sc.Port = port;
                sc.Credentials = credentials;
                sc.EnableSsl = true;
                sc.Send(msg);

            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(new FileStream("./LOG File", FileMode.Create)))
                {
                    writer.WriteLine("{0}", ex.Message);
                }

                return false;
            }

            return true;
        }

        
        public Group updateGroup(Group gr) {
           
            var tr = from g in db.TR_Groups
                     where g.td_GroupNumber == gr.groupNumber
                     select g;

            TR_Group tr_group = tr.First<TR_Group>();

            tr_group = convertToTR_Group(gr);

            saveDatabase();

            var ret = from f in db.TR_Groups
                      where f.td_GroupNumber == gr.groupNumber
                      select f;

            if(ret.Count<TR_Group>() < 0)
                return convertToGroup(ret.First<TR_Group>());
            else
                return default(Group);
        }


        public bool sendMailToGroup(string msg, string groupNumber) {
           
            IQueryable<TR_Student> st = from s in db.TR_Students
                     where s.td_GroupNumber == groupNumber
                     select s;

            bool ret = true;
            
            foreach (var s in st) {
                //Process sendmail = new Process();    
                if (!sendMail("FROM",
                                "E_MAIL",
                                "SMTP",
                                msg,
                                "SUBJECT", 
                                111,
                                new NetworkCredential("USERNAME","PASSWORD") )) 
                    ret = false;
            }

            return ret;
        }


        public bool sendMailToStudent(string msg, string matriculationNumber) {
            var stQry = from student in db.TR_Students
                        where student.td_MatriculationNumber == matriculationNumber
                        select student;
            
            if (sendMail( "FROM",
                            "TO",
                            "SMTP",
                            msg,
                            "SUBJECT",
                            111, //"PORT as int"
                            new NetworkCredential("USERNAME", "PASSWORD"))) 
                 return true;
            else
                return false;
        }


        public ObservableCollection<Student> getAllStudents() {

            IQueryable<TR_Student> st = from s in db.TR_Students
                                        select s;

            ObservableCollection<Student> students = new ObservableCollection<Student>();

            foreach(var s in st){
                students.Add(convertToStudent(s));
            }

            return students;
        }


        public bool setApplicationAcceptState(string msg, bool accept, string matriculationNumber) {

            var qry = from s in db.TR_Students
                      where s.td_MatriculationNumber == matriculationNumber
                      select s;
            qry.First<TR_Student>().td_InternshipAccept = accept;

            db.SubmitChanges();

           if(sendMail( "FROM",
                            "TO",
                            "SMTP",
                            msg,
                            "SUBJECT",
                            111, //"PORT as int"
                            new NetworkCredential("USERNAME", "PASSWORD")))
                return true;
           else
                return false;
        }


        public bool internshipComplitionState(string msg, bool complete, string matriculationNumber) {
            
            var qry = from s in db.TR_Students
                      where s.td_MatriculationNumber == matriculationNumber
                      select s;
            qry.First<TR_Student>().td_IsCompleted = complete;

            db.SubmitChanges();

           if(sendMail( "FROM",
                            "TO",
                            "SMTP",
                            msg,
                            "SUBJECT",
                            111, //"PORT as int"
                            new NetworkCredential("USERNAME", "PASSWORD")))
                return true;
           else
                return false;
        }
        

        public Helper loginStudent(string matriNo, string pwd) {

           var qry = from s in db.TR_Students
                      where s.td_MatriculationNumber == matriNo
                      select s;

           if (qry.First<TR_Student>() == default(TR_Student)) return default(Helper);
             

           if (qry.First<TR_Student>().td_DateFirstContact == default(DateTime)) {
                qry.First<TR_Student>().td_DateFirstContact = DateTime.Now;
                db.TR_Students.InsertOnSubmit(qry.First<TR_Student>());
                saveDatabase();
           }


            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(qry.First<TR_Student>().td_FirstName + qry.First<TR_Student>().td_MatriculationNumber);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                str.Append(hashBytes[i].ToString("X2"));
            }

            if (str.ToString() != qry.First<TR_Student>().td_Password) return default(Helper);

            Student st = convertToStudent(qry.First<TR_Student>());

            var qry2 = from d in db.TR_Groups
                      where d.td_GroupNumber == st.groupNumber
                      select d;

            Group gr = convertToGroup(qry2.First<TR_Group>());

            if(st != null)
                if(gr != null)
                    return new Helper{student=st,group=gr};
           
            return default(Helper);
        }

        

        public bool saveInternshipForm(Student student) {

            var qry = (from s in db.TR_Students
                      where s.td_MatriculationNumber == student.matriculationNumber
                      select s).FirstOrDefault<TR_Student>();

            if (qry == default(IQueryable<TR_Student>))
                return false;

            qry = convertToTR_Student(student);
            db.SubmitChanges();

            return true;
        }


        public ObservableCollection<Group> getAllGroups() {
 
            ObservableCollection<Group> grs = new ObservableCollection<Group>();

            var q = from tmp in db.TR_Groups
                    select tmp;
 
            foreach (var t in q)
                grs.Add(convertToGroup(t));

            return grs;
        }


        public bool createStudentGroup(Group g)
        {
            ///*Testing*/
            //Group g;
            //g = new Group();
            //g.earliestStartOfInternship = DateTime.Now;
            //g.latestEndOfInternship = DateTime.Now.AddYears(1);
            //g.groupNumber = "1001";
            //g.groupName = "Freaks";
            ///*END Testing*/

            if (g == default(Group)) return false;

            var qry = from gr in db.TR_Groups
                      where g.groupNumber == gr.td_GroupNumber
                      select gr;

            if ((qry.First<TR_Group>() == default(TR_Group)))
            {
                db.TR_Groups.InsertOnSubmit(convertToTR_Group(g));

                saveDatabase();
            }
            else
                return false;

            return true;
        }


        public ObservableCollection<Group> createStudentGroups(List<Group> groups) {


            foreach (Group g in groups)
            {
                if (!createStudentGroup(g))
                {
                    using (StreamWriter w = File.AppendText("logGroup.txt"))
                    {
                        w.WriteLine(g.groupNumber.ToString() + " Failed to save in database");
                    }
                }

            }

            return getAllGroups();   
        }


        public void manipulateStudents(List<Student> s) {
         
            foreach (Student tmp in s) {
                manipulateStudent(tmp);
            }

            return;
        }


        private Student manipulateStudent(Student s)
        {
            if (s != default(Student)) {

                var qry = from student in db.TR_Students
                          where student.td_MatriculationNumber == s.matriculationNumber
                          select student;

                if (qry.First<TR_Student>() == default(TR_Student))
                {
                    db.TR_Students.InsertOnSubmit(convertToTR_Student(s));
                    saveDatabase();
                    //Update existing Student
                    return default(Student);
                }

                else { 
                    //Add the new Student
                    TR_Student tmp = convertToTR_Student(s);
                    db.TR_Students.InsertOnSubmit(tmp);
                    saveDatabase();
                }
            
            }

            return default(Student);
        }

        //[WebMethod]
        //public bool createStudentsGroup(Xml studentsList, string msg)
        //{
        //    //XML File structure
        //    //<Student>
        //    //    <firstName>Abdullah</firstName>
        //    //    <lastName>F</lastName>
        //    //    <matriculationNr>yay10001234</matriculationNr>
        //    //    <groupNr>4</groupNr>
        //    //</Student>

        //    bool ret = true;

        //    XDocument doc = new XDocument(studentsList);

        //    if (studentsList == null) return false;
           
        //    //read the xml file and fill a table with the group
        //    var qry = from s in doc.Root.Elements("Student")
        //              select s;

        //    //Create the Database group
        //    foreach (var g in qry)
        //    {
        //        var tmpQry = from q in db.TR_Groups
        //                     where q.td_GroupNumber == g.Element("groupNr").ToString()
        //                     select q;

        //        if (tmpQry.FirstOrDefault<TR_Group>() != default(TR_Group))
        //        {
        //            TR_Group tmp = new TR_Group();
        //            tmp.td_GroupNumber = g.Element("groupNr").ToString();

        //            db.TR_Groups.InsertOnSubmit(tmp);
        //            saveDatabase();
        //            break;
        //        }

        //        break;
        //    }

        //    //Create the Database student
        //    foreach (var s in qry)
        //    {
        //        var tmpQry = from q in db.TR_Students
        //                     where q.td_MatriculationNumber == s.Element("matriculationNr").ToString()
        //                     select q;

        //        if (tmpQry.FirstOrDefault<TR_Student>() != default(TR_Student))
        //        {
        //            TR_Student tmp = new TR_Student();

        //            tmp.td_GroupNumber = s.Element("groupNr").ToString();
        //            tmp.td_FirstName = s.Element("firstName").ToString();
        //            tmp.td_LastName = s.Element("lastName").ToString();
        //            tmp.td_MatriculationNumber = s.Element("matriculationNr").ToString();
        //            tmp.td_IsApplicationSend = false;
        //            tmp.td_IsCompleted = false;

        //            MD5 md5 = System.Security.Cryptography.MD5.Create();
        //            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(tmp.td_FirstName + tmp.td_MatriculationNumber);
        //            byte[] hashBytes = md5.ComputeHash(inputBytes);
        //            StringBuilder str = new StringBuilder();
        //            for (int i = 0; i < hashBytes.Length; i++)
        //            {
        //                str.Append(hashBytes[i].ToString("X2"));
        //            }

        //            tmp.td_Password = str.ToString();


        //            db.TR_Students.InsertOnSubmit(tmp);
        //            saveDatabase();
        //            if (sendMail("FROM",
        //                   tmp.td_FirstName + "." + tmp.td_LastName + "@fh-heidelberg.de",
        //                   "SMTP",
        //                   msg,
        //                   "SUBJECT",
        //                   111, //"PORT as int"
        //                   new NetworkCredential("USERNAME", "PASSWORD")))
        //               ret = true;
        //            else
        //                ret = false;

        //            break;
        //        }

        //        break;
        //    }

        //    return ret;
        //}
    }
}
