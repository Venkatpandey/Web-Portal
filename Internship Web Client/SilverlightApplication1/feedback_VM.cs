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
    public class feedback_VM :INotifyPropertyChanged
    {
        public EventHandler Navigatetologinpage;

        public feedback_VM()
        {
            commandhandler();
            initialize();
        }
        
        private void initialize()
        {
           
           student retrivedStudent = IsolatedStorageCacheManager<student>.Retrieve("studentData.xml");
           startDate = retrivedStudent.internship_i.start;
            endDate = retrivedStudent.internship_i.end;
           
        }

      
        private int m_irate1;
        private int m_irate2;
        private string m_scomment;
        private DateTime m_sstartDate;
        private DateTime m_sendDate;
       
        public int rate1
        {
            get { return m_irate1; }
            set
            {
                if (value != m_irate1)
                {
                    m_irate1 = value;
                }
            }
        }
        public int rate2
        {
            get { return m_irate2; }
            set
            {
                if (value != m_irate2)
                {
                    m_irate2 = value;
                }
            }
        }
        public string comment

        {
            get { return m_scomment; }
            set
            {
                if (value != m_scomment)
                {
                    m_scomment = value;
                }
            }
        }

        private RelayCommand m_osubfeedCommand;

        public RelayCommand subfeedCommand
        {
            get { return m_osubfeedCommand; }
            set
            {
                m_osubfeedCommand = value;
            }
        }
        private void commandhandler()
        {
            m_osubfeedCommand = new RelayCommand(sendfeed);

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

        private void sendfeed()
        {
            if (string.IsNullOrEmpty(m_scomment))
            {
                MessageBox.Show("Please fill all the Details.!!", "Error", MessageBoxButton.OK);
            }

            else
            {
            feedback_webServices feedback = new feedback_webServices();

            feedback.Company_Rating = m_irate1;
            feedback.Internship_Rating = m_irate2;
            feedback.Students_Comment = comment;
            feedback.i_startDate = startDate;
            feedback.i_endDate = endDate;

            webservice savefeed = new webservice();

            savefeed.save_feedback(feedback);

            //feedback.Company_Rating = m_irate1;
            //feedback.Internship_Rating = m_irate2;
            //feedback.Students_Comment = m_scomment;

            MessageBox.Show("Thank you For your valuable Feedback !! ", "Done", MessageBoxButton.OK);
            Navigatetologinpage.Invoke(null, null);
        }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
