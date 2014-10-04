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
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace SilverlightApplication1
{
    public class    MainPage_VM
    {
        public EventHandler Navigatetoformpage;
        public EventHandler Navigatetofbpage;
        public MainPage_VM()
        {
            commandhandler();
           
        }

        private string m_smatriculationNo;
        private string m_spassword;

        public string matriculationNo
        {
            get { return m_smatriculationNo; }
            set
            {
                if (value != m_smatriculationNo)
                {
                    m_smatriculationNo = value;
                }
            }
        }
        public string password
        {
            get { return m_spassword; }
            set
            {
                if (value != m_spassword)
                {
                    m_spassword = value;
                }
            }
        }

        private RelayCommand m_ologin_clickCommand;

        public RelayCommand login_clickCommand
        {
            get { return m_ologin_clickCommand; }
            set
            {
                m_ologin_clickCommand = value;
            }
        }
        private void commandhandler()
        {
            m_ologin_clickCommand = new RelayCommand(executelogin);

            

        }


        private void executelogin()
        {
            //string m_smatno = m_smatriculationNo;
            //string m_spasswd = m_spassword;
            //string firstname = string.Empty;
            //string lastname = string.Empty;
            //string gno = string.Empty;
            //bool internship_accepted = false;
            //DateTime startdt = new DateTime();
           
            //DateTime enddt = new DateTime();

            //ServiceReference1.WebServiceInternshipSoapClient myref = new ServiceReference1.WebServiceInternshipSoapClient();
            //myref.loginStudentAsync("m1001240", "alex1001");
            //ServiceReference1.Helper lg = myref.loginStudent("m1001240", "alex1001");
           
            //myref.loginStudentCompleted += myref_loginStudentCompleted;

            webservice login = new webservice();
            student user_name= login.login_student(m_smatriculationNo, m_spassword);
            if (user_name == null)
            {
                MessageBox.Show("Invalid Username and Password", "Error", MessageBoxButton.OK);
            }
                //divert to form page
            else if (user_name.isCompleted == false)
            {
                Navigatetoformpage.Invoke(user_name, null);
            }
                //divert to feedbackpage
            else if (user_name.isCompleted == true)
            {

                Navigatetofbpage.Invoke(user_name, null);
            }

            
            

            //if (m_smatno == "123456" && m_spasswd == "abcd")
            //{

            //    // if internship is accecepted then 
            //    if (internship_accepted)
            //    {
            //       List<DateTime> dateinfo=new List<DateTime> ();
            //        dateinfo.Add(startdt);
            //        dateinfo.Add(enddt);


            //        Navigatetofbpage.Invoke(dateinfo,null);
            //    }
            //    else 
            //    {

            //       ServiceReference1.WebService1SoapClient b = new ServiceReference1.WebService1SoapClient();

            
            //    }

            // }

            //else
            //{
            //    MessageBox.Show("Invalid Username and Password", "Error", MessageBoxButton.OK);
            //}

            //this.navContent.Navigate(new Uri("Form", UriKind.Relative));




        }
        //public static ServiceReference1.Helper h;
        //void myref_loginStudentCompleted(object sender, ServiceReference1.loginStudentCompletedEventArgs e)
        //{

        //    //h = e.Result as ServiceReference1.Helper;
        //    //if(h == default(ServiceReference1.Helper))
        //    //{
        //    //    //Something went wrong
        //    //    MessageBox.Show("Invalid Username and Password", "Error", MessageBoxButton.OK);
        //    //}

        //    //h.student.matriculationNumber=m_smatriculationNo;
        //    //h.student.password = m_spassword;

        //    string m_smatno = m_smatriculationNo;
        //    string m_spasswd = m_spassword;
        //    string firstname = string.Empty;
        //    string lastname = string.Empty;
        //    string gno = string.Empty;
        //    ServiceReference1.Helper helper = new ServiceReference1.Helper();
        //    ServiceReference1.Student student = helper.student;
        //    bool internship_accepted;
        //    if (student != null)
        //    {
        //        internship_accepted = student.isCompleted;
        //    }

        //    else
        //    {
        //        internship_accepted = true;
        //    }
        //    DateTime startdt = new DateTime();
        //    DateTime enddt = new DateTime();



        //    // if internship is accecepted then 
           
        //        if (internship_accepted)
        //        {
        //            List<DateTime> dateinfo = new List<DateTime>();
        //            dateinfo.Add(startdt);
        //            dateinfo.Add(enddt);


        //            Navigatetofbpage.Invoke(dateinfo, null);
        //        }
        //        else
        //        {

        //            List<string> forminfo = new List<string>();
        //            forminfo.Add(lastname);
        //            forminfo.Add(firstname);
        //            forminfo.Add(m_smatriculationNo);
        //            forminfo.Add(gno);
        //            Navigatetoformpage.Invoke(forminfo, null);


        //        }
        //    }
           
    }


}
