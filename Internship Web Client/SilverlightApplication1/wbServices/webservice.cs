using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace SilverlightApplication1
{
    public class webservice
    {
        public student login_student(string matno, string pass)
        {

            student user_name = new student();
            //this is for valid user , whose application is not yet submitted.
            if (matno == "123456" && pass == "abcd")
            {
                user_name.firstName = "Venkat";
                user_name.lastName = "Pandey";
                user_name.matriculationNumber = "123456";
                user_name.password = "abcd";
                user_name.groupNumber = "201312";
                user_name.isCompleted = false;
            }
            //this is for valid user , whose application is submitted , hence diverte to feedback page.
            else if (matno == "654321" && pass == "abcd")
            {

                user_name.firstName = "Venkat";
                user_name.lastName = "Pandey";
                user_name.matriculationNumber = "654321";
                user_name.password = "abcd";
                user_name.groupNumber = "201312";
                user_name.internship_i = new internship();
                user_name.internship_i.start = new DateTime(2013, 12, 20);
                user_name.internship_i.end = new DateTime(2014, 08, 20);
                user_name.isCompleted = true;
            }
                // this is a invalid user.
            else
            {
                user_name = null;
            }
            

            return user_name;
        }

        public bool save_student(student savestudent)
        {
            
           
                //using (StreamWriter writers = new StreamWriter(new FileStream(@"C:\Users\Venkat Pandey\Documents\visual studio 2012\Projects\SilverlightApplication1\SilverlightApplication1\Xml\form.xml",FileMode.OpenOrCreate)))
                {
                    //System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(savestudent.GetType());
                    {
                       
                        ////System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Venkat Pandey\Documents\visual studio 2012\Projects\SilverlightApplication1\SilverlightApplication1\Xml\form.xml");
                        ////System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Venkat Pandey\Documents\visual studio 2012\Projects\SilverlightApplication1\SilverlightApplication1\Xml\form.xml");
                        
                        //writer.Serialize(Console.Out, savestudent);
                        //Console.WriteLine();
                        //Console.ReadLine();
                        ////file.Close();

                        
                        ////XmlSerializer xmlSerilizer = new XmlSerializer(savestudent.GetType());
                        ////StreamWriter sw = new StreamWriter(@"C:\Users\Venkat Pandey\Desktop\DB\venki.xml");
                        ////xmlSerilizer.Serialize(sw, savestudent);

                    }
                }

                //for storing and retrieving a single object

                IsolatedStorageCacheManager<student>.Store("studentData.xml", savestudent);
              
                return true;
            

        }
       


        public bool save_feedback(feedback_webServices savefeed)
        {
            IsolatedStorageCacheManager<feedback_webServices>.Store("feedData.xml", savefeed);
            feedback_webServices retrivedStudent = IsolatedStorageCacheManager<feedback_webServices>.Retrieve("feedData.xml");
            
            return true;
        }
    }
}
