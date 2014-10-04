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
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;



namespace SilverlightApplication1
{
    public class form_VM : INotifyPropertyChanged
    {
        public EventHandler Navigatetologinpage;

        public form_VM()
    {
        commandhandler();
        student retrivedStudent = IsolatedStorageCacheManager<student>.Retrieve("studentData.xml");
    }

        private  string m_slastName;
        private string m_sfirstname;
        private string m_sgroupNo;
        private string m_smatriculationNo;
        private string m_scompanyName;
        private string m_sdepartment;
        private string m_scoach;
        private string m_scoachContact;
        private string m_sAdd1;
        private string m_sAdd2;
        private string m_sactivityDetails;
        private DateTime m_sstartDate;
        private DateTime m_sendDate;



        public string lastName
    {
        get { return m_slastName; }
        set
            {
                if (value != m_slastName)
                {
                    m_slastName = value;
                    Notify("lastName");
                }
            }
    }
        public string firstName
        {
            get { return m_sfirstname; }
            set 
            {
                if (value != m_sfirstname)
                {
                    m_sfirstname = value;
                    Notify("firstName");
                }

            }
        }
        public string groupNo
        {
            get { return m_sgroupNo; }
            set
            {
                if (value != m_sgroupNo)
                {
                    m_sgroupNo = value;
                    Notify("groupNo");
                }
            }

        }
        public string matriculationNo
        {
            get { return m_smatriculationNo; }
            set 
            {
                if (value != m_smatriculationNo)
                {
                    m_smatriculationNo = value;
                    Notify("matriculationNo");
                    
                }

            }
        }

        public string companyName
        {
            get { return m_scompanyName; }
            set
            {
                if (value != m_scompanyName)
                {
                    m_scompanyName = value;
                }
            }
        }
        public string department
        {
            get { return m_sdepartment; }
            set
            {
                if (value != m_sdepartment)
                {
                    m_sdepartment = value;
                }
            }
        }
        public string coach
        {
            get { return m_scoach; }
            set
            {
                if (value != m_scoach)
                {
                    m_scoach = value;
                }
            }
        }
        public string coachContact
        {
            get { return m_scoachContact; }
            set
            {
                if (value != m_scoachContact)
                {
                    m_scoachContact = value;
                }
            }
        }
        public string Add1
        {
            get { return m_sAdd1; }
            set
            {
                if (value != m_sAdd1)
                {
                    m_sAdd1 = value;
                }
            }
        }
        public string Add2
        {
            get { return m_sAdd2; }
            set
            {
                if (value != m_sAdd2)
                {
                    m_sAdd2 = value;
                }
            }
        }
        public string activityDetails
        {
            get { return m_sactivityDetails; }
            set
            {
                if (value != m_sactivityDetails)
                {
                    m_sactivityDetails = value;
                }
            }
        }
        public DateTime startDate
        {
            get { return m_sstartDate; }
            set
            {
                if (value != m_sstartDate)
                {
                    m_sstartDate = value;
                    Notify("startDate");
                }
            }
        }
        public DateTime endDate
        {
            get { return m_sendDate; }
            set
            {
                if (value != m_sendDate)
                {
                    m_sendDate = value;
                    Notify("endDate");
                }
            }
        }


        private RelayCommand m_osubmitCommand;
        public RelayCommand submitCommand
        {
            get { return m_osubmitCommand; }
            set
            {
                m_osubmitCommand = value;
            }
        }

        private void commandhandler()
        {
            m_osubmitCommand = new RelayCommand(subform);

        }

        private void subform()
        {

            if (string.IsNullOrEmpty(m_scompanyName) || string.IsNullOrEmpty(m_sdepartment) || string.IsNullOrEmpty(m_scoach) || string.IsNullOrEmpty(m_scoachContact) || string.IsNullOrEmpty(m_sAdd1) || string.IsNullOrEmpty(m_sAdd2) || string.IsNullOrEmpty(m_sactivityDetails))
            {
                MessageBox.Show("Please fill all the Details.!!", "Error", MessageBoxButton.OK);
            }
            else
            {

                TimeSpan dur = new TimeSpan();
                //DateTime dt1 = d1.DisplayDate;
                dur = m_sendDate - m_sstartDate;
                if (dur.Days > 90)
                {
                    MessageBox.Show("Internship Form Submitted Successfully", "Done", MessageBoxButton.OK);
                    //ServiceReference1.Helper helper = new ServiceReference1.Helper();
                    //ServiceReference1.WebServiceInternshipSoapClient myref = new ServiceReference1.WebServiceInternshipSoapClient();

                    student student = new student();

                    company m_company = new company();

                    internship m_internship = new internship();

                    student.firstName = m_sfirstname;
                    student.lastName = m_slastName;
                    student.groupNumber = m_sgroupNo;
                    student.matriculationNumber = m_smatriculationNo;
                    m_company.Company_Name = m_scompanyName;
                    m_company.Dapartment = m_sdepartment;
                    m_company.Coach_Name = m_scoach;
                    m_company.Coach_Phone = m_scoachContact;
                    m_company.Street_and_Number = m_sAdd1;
                    m_company.City = m_sAdd2;
                    m_company.Activity = m_sactivityDetails;

                    m_internship.company = m_company;
                    m_internship.start = m_sstartDate;
                    m_internship.end = m_sendDate;

                    student.internship_i = m_internship;

                    webservice saveform = new webservice();

                    saveform.save_student(student);

                    //helper.student = student;
                    Navigatetologinpage.Invoke(null, null);
                }
                else
                {
                    MessageBox.Show("The time duration of the intenship should be minimum 90 days", "Error", MessageBoxButton.OK);
                }
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(String propertyName )
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
